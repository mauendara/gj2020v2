using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLigthController : MonoBehaviour
{
    public Light ligth;
    private Vector2 move;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 move = Vector2.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move.x = Input.GetAxis ("Horizontal");

        if (move.x < 0) 
		{
            ligth.transform.eulerAngles = new Vector3 (0, -90, 0);
        }
        else if (move.x > 0)
        {
            ligth.transform.eulerAngles = new Vector3 (0, 90, 0);
        } 
    }
}
