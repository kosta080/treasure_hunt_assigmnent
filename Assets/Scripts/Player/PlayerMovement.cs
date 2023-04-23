using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace Scripts.Player
{
	public class PlayerMovement : MonoBehaviour
	{
		public enum inpotMethods{keyboard, mouse}
		public inpotMethods inputMethod = inpotMethods.keyboard;

		[SerializeField]
		private Transform target;

		[SerializeField]
		private InputAction playerControlls;

		[SerializeField]
		private float runSpeed;

		private NavMeshAgent navMeshAgent;

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
			//navMeshAgent.destination = target.position;

			if (inputMethod == inpotMethods.keyboard)
			{
				transform.Rotate(new Vector3(0f, playerControlls.ReadValue<Vector2>().x * 5f, 0f), Space.Self);

				navMeshAgent.updateRotation = false;
				navMeshAgent.destination = transform.position + (transform.forward * playerControlls.ReadValue<Vector2>().y * runSpeed);
			}

			if (inputMethod == inpotMethods.mouse)
			{
				if (Input.GetMouseButtonDown(0))
				{
					RaycastHit hit;

					if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
					{
						navMeshAgent.updateRotation = true;
						navMeshAgent.destination = hit.point;
					}
				}
			}
		}
	}
}
