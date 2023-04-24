using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform Player;


    void Update()
    {

        transform.LookAt(Player.position);
        Vector3 camPos = new Vector3(Player.position.x - 20f, Player.position.y + 20f , Player.position.z + 20f);
        transform.position = camPos;
    }
}
