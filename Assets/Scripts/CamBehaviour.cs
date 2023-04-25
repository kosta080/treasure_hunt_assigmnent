using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CamBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform Player;

    [Header("camera offset east west")]
    public float CamOffsetx = 20f;
    [Header("camera offset north south")]
    public float CamOffsetz = 20f;
    [Header("camera offset up down")]
    public float CamOffsety = 20f;

    
    void Update()
    {

        transform.LookAt(Player.position);
        Vector3 camPos = new Vector3(Player.position.x + CamOffsetx, Player.position.y + CamOffsety, Player.position.z + CamOffsetz);
        transform.position = camPos;
    }
}
