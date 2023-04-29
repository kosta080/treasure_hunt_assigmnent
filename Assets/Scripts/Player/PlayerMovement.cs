using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Scripts.Player
{
	public class PlayerMovement : MonoBehaviour
	{
		public enum InputMethods
		{
			none,
			keyboard,
			mouse,
			gui
		}

		[Header("Input Method")]
		public InputMethods InputMethod = InputMethods.keyboard;

		private InputMethods oldInputMethod = InputMethods.none;

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

		[SerializeField]
		[Range(0,0.20f)]
		private float topTouchGap;
		[SerializeField]
		[Range(0, 0.20f)]
		private float leftTouchGap;
		[SerializeField]
		[Range(0, 0.20f)]
		private float rightTouchGap;

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
			if (oldInputMethod != InputMethod)
			{
				GuiInput.Instance.showGI(InputMethod == InputMethods.gui);
				oldInputMethod = InputMethod;
			}
			updateCharacterAnimationSound();
			
			//solve this if
			//if (PopupSystem.Instance.activePopup) return;

			if (InputMethod == InputMethods.keyboard)
			{
				updateKeyboardMovement();
			}
			else if (InputMethod == InputMethods.mouse)
			{
				updateMouseMovement();
			}
			else if (InputMethod == InputMethods.gui)
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
				//ignore screen edges Screen.height is used for left and right edges intentionally because the UI is scaling according to height.
				float sh = Screen.height;
				float sw = Screen.width;
				if (Input.mousePosition.y > sh * (1 - topTouchGap))
				{
					Debug.Log("out 1");
					return;
				}
				if (Input.mousePosition.x < sh * leftTouchGap)
				{
					Debug.Log("out 2");
					return;
				}
				if (Input.mousePosition.x > sw - (sh * rightTouchGap))
				{
					Debug.Log("out 3");
					return;
				}

				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;

				if (Physics.Raycast(ray, out hit, Mathf.Infinity))
				{
					Debug.Log(hit.transform.name);
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
