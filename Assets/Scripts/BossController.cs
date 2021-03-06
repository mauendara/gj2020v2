﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public float jumpForce, jumpCD, jump, xforce;
    public int HP = 5;
    public float playerTriggerDistance = 0f;
    public float bossSpeed = 5f;
    public float bossThrowX = 1f;
    public float bossThrowY = 4f;

    private bool isChasing = true;
    private float aquireRate = 0.65f;
    private Rigidbody2D rb;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float playerDistanceMagnitude = (transform.position - target.position).sqrMagnitude;
        if (playerDistanceMagnitude <= playerTriggerDistance && isChasing)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, bossSpeed * Time.fixedDeltaTime);
        }
        if (playerDistanceMagnitude <= 3)
        {
            Vector3 throwForce = target.position.x - transform.position.x <= 0 ? new Vector3(-bossThrowX, bossThrowY, 0f) : new Vector3(bossThrowX, bossThrowY, 0f);
            target.GetComponent<Rigidbody2D>().AddForce(throwForce);
            transform.GetComponent<Rigidbody2D>().AddForce(new Vector3(-throwForce.x*0.55f, throwForce.y*0.5f));
            if (isChasing)
            {
                isChasing = false;
                StartCoroutine(WaitToAttack());
            }

        }

    }

    private void JumpLeft()
    {
        rb.AddForce(new Vector2(-xforce, jumpForce));
    }

    private void JumpRigth()
    {
        rb.AddForce(new Vector2(xforce, jumpForce));
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("proyectilNoDamage"))
        {
            if (HP < 8)
            {
                HP++;
                transform.localScale += new Vector3(0.1F, 0.1F, 0);
            }
            else
            {
                transform.gameObject.SetActive(false);
                
            }
        }
        if (col.gameObject.tag.Equals("proyectilDamage"))
        {
            if (HP > 0)
            {
                Destroy(col.gameObject);
                HP--;
                transform.localScale -= new Vector3(0.1F, 0.1F, 0);
            }
            else if (HP == 0)
            {
                Destroy(col.gameObject);
                transform.gameObject.SetActive(false);
            }
        }
        if (col.gameObject.tag.Equals("proyectilDestroy"))
        {
            transform.gameObject.SetActive(false);
        }
        if (col.gameObject.tag.Equals("bossPlataformL"))
        {
            JumpLeft();
        }
        if (col.gameObject.tag.Equals("bossPlataformR"))
        {
            JumpRigth();
        }

    }

    private IEnumerator WaitToAttack()
    {

        if (!isChasing)
        {
            yield return new WaitForSeconds(aquireRate);
            isChasing = true;
        }

    }
}