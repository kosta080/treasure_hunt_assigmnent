using Scripts.Gameloop;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace Scripts.Player
{
	public class PlayerMovement : MonoBehaviour
	{
		
		public enum inpotMethods{keyboard, mouse}

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
		private GameObject StartPosition;

		[SerializeField]
		private float levelGimensionsX;	
		[SerializeField]
		private float levelGimensionsZ;


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
		}
		
		private void Update()
		{
			//Calculate actual speed to determine which animation of the character to play
			float speed = Vector3.Distance(transform.position, lastPosition) / Time.deltaTime;
			lastPosition = transform.position;
			characterAnimator.SetBool("Run", speed > 0.01);

			if (PopupSystem.Instance.activePopup) return;

			if (inputMethod == inpotMethods.keyboard)
			{
				transform.Rotate(new Vector3(0f, playerControlls.ReadValue<Vector2>().x * rotateSpeed, 0f), Space.Self);

				navMeshAgent.updateRotation = false;
				navMeshAgent.destination = transform.position + (transform.forward * playerControlls.ReadValue<Vector2>().y * stepSize);
			}

			if (inputMethod == inpotMethods.mouse)
			{
				if (Input.GetMouseButtonDown(0))
				{
					Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
					RaycastHit hit;

					if (Physics.Raycast(ray, out hit, Mathf.Infinity))
					{
						//Debug.Log("<color=red>"+ hit.point + "</color>");
						navMeshAgent.updateRotation = true;
						navMeshAgent.destination = hit.point;
						targetPin.position = hit.point;
						targetPin.GetComponent<ParticleSystem>().Emit(40);
					}
				}

			}
		}

	}
}
