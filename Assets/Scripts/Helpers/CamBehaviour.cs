using UnityEngine;

namespace Scripts.Helpers.cam
{
    [ExecuteInEditMode]
    public class CamBehaviour : MonoBehaviour
    {

        public enum CamStates
        {
            notSet,
            firstPerson,
            topDown
        }
        public CamStates CamState = CamStates.topDown;
        private CamStates CamStateOld = CamStates.notSet;

        [SerializeField]
        private Transform Player;

        [SerializeField]
        private Camera tpCamera;

        [SerializeField]
        private Camera fpCamera;

        [Header("camera offset east west")]
        public float CamOffsetx = 20f;
        [Header("camera offset north south")]
        public float CamOffsetz = 20f;
        [Header("camera offset up down")]
        public float CamOffsety = 20f;

        private void Start()
        {
            transform.LookAt(Player.position);
        }
        void Update()
        {
            if (CamStateOld != CamState)
            {
                if (tpCamera)
                    tpCamera.enabled = CamState == CamStates.topDown;
                if (fpCamera)
                    fpCamera.enabled = CamState == CamStates.firstPerson;
                CamStateOld = CamState;
            }
            //transform.LookAt(Player.position);
            Vector3 camPos = new Vector3(Player.position.x + CamOffsetx, Player.position.y + CamOffsety, Player.position.z + CamOffsetz);
            transform.position = Vector3.Lerp(transform.position, camPos, Time.deltaTime * 5);

            //transform.position = camPos;
        }
    }
}