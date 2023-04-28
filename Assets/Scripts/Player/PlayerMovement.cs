using Scripts.Gameloop;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace Scripts.Player
{
	public class PlayerMovement : MonoBehaviour
	{
		
		
		public enum inpotMethods
		{
			keyboard, 
			mouse,
			gui
		}

		//enums uppercase
		[Header("Input Method")]
		public inpotMethods inputMethod = inpotMethods.keyboard;

		[SerializeField]
		private InputAction playerControlls;

		[SerializeField]
		private Transform targetPin;

		[Header("Walking Params")]

		[SerializeField]
		private float stepSize;

		[SerializeField]
		private float rotateSpeed;

		[SerializeField]
		private Animator characterAnimator;

		[SerializeField]
		private AudioSource characterAudioSource;

		private NavMeshAgent navMeshAgent;
		private Vector3 lastPosition = Vector3.zero;

		private void OnEnable()
		{
			playerControlls.Enable();
		}
		private void OnDisable()
		{
			playerControlls.Disable();
		}

		private void Awake()
		{
			navMeshAgent = GetComponent<NavMeshAgent>();
			lastPosition = transform.position;
		}
		
		private void Update()
		{
			updateCharacterAnimationSound();
			
			//solve this if
			//if (PopupSystem.Instance.activePopup) return;

			if (inputMethod == inpotMethods.keyboard)
			{
				updateKeyboardMovement();
			}
			else if (inputMethod == inpotMethods.mouse)
			{
				updateMouseMovement();
			}
			else if (inputMethod == inpotMethods.gui)
			{
				updateGuiMovement();
			}
		}

		private void updateCharacterAnimationSound()
		{
			//speed on ground ignoring y
			Vector3 tpos = new Vector3(transform.position.x, 0, transform.position.z);
			Vector3 lpos = new Vector3(lastPosition.x, 0, lastPosition.z);
			float speed = Vector3.Distance(tpos, lpos) / Time.deltaTime;
			lastPosition = transform.position;
			characterAnimator.SetBool("Run", speed > 0.01);
			characterAudioSource.enabled = speed > 0.01;
		}
		private void updateKeyboardMovement()
		{
			transform.Rotate(new Vector3(0f, playerControlls.ReadValue<Vector2>().x * rotateSpeed, 0f), Space.Self);

			navMeshAgent.updateRotation = false;
			navMeshAgent.destination = transform.position + (transform.forward * playerControlls.ReadValue<Vector2>().y * stepSize);
		}
		private void updateMouseMovement()
		{
			if (Input.GetMouseButtonDown(0))
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;

				if (Physics.Raycast(ray, out hit, Mathf.Infinity))
				{
					if (hit.transform.tag != "WalkTarget")
						return;

					navMeshAgent.updateRotation = true;
					navMeshAgent.destination = hit.point;
					targetPin.position = hit.point;
					targetPin.GetComponent<ParticleSystem>().Emit(40);
				}
			}
		}
		private void updateGuiMovement()
		{
			transform.Rotate(new Vector3(0f, GuiInput.Instance.getAxies().x * rotateSpeed, 0f), Space.Self);
			navMeshAgent.updateRotation = false;
			navMeshAgent.destination = transform.position + (transform.forward * GuiInput.Instance.getAxies().y * stepSize);
		}
		/*--*/

	}
}
