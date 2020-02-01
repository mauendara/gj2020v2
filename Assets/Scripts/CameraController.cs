using System.Collections;
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
    void LateUpdate()
    {
<<<<<<< HEAD
        transform.position = new Vector3(player.transform.position.x - offset.x, transform.position.y, transform.position.z);
=======
        transform.position = player.transform.position + offset;
>>>>>>> 57450712e0eb56ae113927edda760f327357e13e
    }
}
