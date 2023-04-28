using System.Collections;
using UnityEngine;

public class HintParticles : MonoBehaviour
{
    [SerializeField]
    private Transform treasureChestParent;

    void Start()
    {
        StartCoroutine(findVisibleChest());
    }

/*    void Update()
    {
        findVisibleChest();
    }*/

    private IEnumerator findVisibleChest()
    {
        while (true)
        {
            foreach (Transform chest in treasureChestParent)
            {
                if (chest.gameObject.activeSelf)
                {
                    transform.LookAt(chest);
                }
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
