using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow Instance;
    public Transform player;
    public Vector3 offset;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Update()
    {
        if(player!=null)
        transform.position = new Vector3(player.position.x + offset.x,  offset.y, offset.z); // Camera follows the player with specified offset position
    }
}
