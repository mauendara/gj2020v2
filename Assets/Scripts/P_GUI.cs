using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class P_GUI : MonoBehaviour {
    public Sprite[] elementsSprite;
    public Image[] elementsImages;
    public int health = 3;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("powerUP"))
        {
            print(col.gameObject.name);
            switch (col.gameObject.name)
            {
                case "Moon":
                    elementsImages[6].gameObject.SetActive(true);
                    Destroy(col.gameObject);
                    break;
                case "Tree":
                    elementsImages[4].gameObject.SetActive(true);
                    Destroy(col.gameObject);
                    break;
                case "Sun":
                    elementsImages[3].gameObject.SetActive(true);
                    Destroy(col.gameObject);
                    break;
                case "Skull":
                    elementsImages[5].gameObject.SetActive(true);
                    Destroy(col.gameObject);
                    break;
            }
        }
        if (col.gameObject.tag.Equals("treasure"))
        {

        }
        if (col.gameObject.tag.Equals("P_projectile") || col.gameObject.tag.Equals("P_enemy"))
        {
            health--;
            if (health == 0)
            {
                SceneManager.LoadScene("level1");
            }
            else
            {
                elementsImages[health].sprite = elementsSprite[1];
            }
        }
    }
}
