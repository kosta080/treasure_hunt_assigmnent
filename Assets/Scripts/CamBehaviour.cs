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

	private void Start()
	{
        transform.LookAt(Player.position);
    }
	void Update()
    {

        //transform.LookAt(Player.position);
        Vector3 camPos = new Vector3(Player.position.x + CamOffsetx, Player.position.y + CamOffsety, Player.position.z + CamOffsetz);
        transform.position = Vector3.Lerp(transform.position, camPos, Time.deltaTime*5);

        //transform.position = camPos;
    }
}
