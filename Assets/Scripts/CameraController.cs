﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;    
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x-offset.x, player.transform.position.y - offset.y, transform.position.z);
    }
}
