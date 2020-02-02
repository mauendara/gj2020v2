using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitProcessScript : MonoBehaviour
{
    [SerializeField] string nextScene;
    [SerializeField] int maxChecksExpected;
    private bool isPlayerOver;
    public int numberOfChecks;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerOver = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerOver = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        isPlayerOver = false;
        numberOfChecks = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (isPlayerOver)
        {
            Debug.Log(nextScene);
            if (Input.GetKeyDown(KeyCode.R)&&numberOfChecks==maxChecksExpected)
            {
                //Change scene
                SceneManager.LoadScene(nextScene);
            }
        }
    }
}
