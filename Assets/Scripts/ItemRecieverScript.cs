using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRecieverScript : MonoBehaviour
{
    [SerializeField]string expectedObject;
    int isOverExpectedObject;
    private Transform player;
    private GameObject exit;
    public bool hasRecievedItem;
    // Start is called before the first frame update
    void Start()
    {
        isOverExpectedObject = 0;
        hasRecievedItem = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        exit = GameObject.FindGameObjectWithTag("Exit");
    }

    // Update is called once per frame
    void Update()
    {
        if (isOverExpectedObject==1)
        {
            //RecieveObject
            hasRecievedItem = true;
            isOverExpectedObject++;
            Debug.Log(isOverExpectedObject);
            exit.GetComponent<ExitProcessScript>().numberOfChecks++;
            //IfPossibleGiveObjectToPlayer
            try {
                transform.GetChild(0).transform.parent = player;
            }
            catch (UnityException ex){}
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == expectedObject && isOverExpectedObject <= 1)
        {
            isOverExpectedObject = 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == expectedObject && isOverExpectedObject<=1)
        {
            isOverExpectedObject = 0;
        }
    }
}
