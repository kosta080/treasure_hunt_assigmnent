using UnityEngine;

namespace Scripts.Helpers
{
    public class generateMashColliders : MonoBehaviour
    {
        void Start()
        {
            foreach (Transform childObject in transform)
            {
                Mesh mesh = childObject.gameObject.GetComponent<MeshFilter>().mesh;

                if (mesh != null)
                {
                    MeshCollider meshCollider = childObject.gameObject.AddComponent<MeshCollider>();
                    meshCollider.sharedMesh = mesh;
                }
            }
        }

    }
}
