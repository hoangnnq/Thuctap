using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InanimateEnemy : Enemy
{
    public float speed = 2;
    public bool canMove = true;
    public bool vertical;
    Rigidbody2D myRigid;
    //public InanimateEnemy(float speed, bool canMove, bool isVertical, int dmg) : base(speed, canMove, isVertical, dmg)
    //{
    //}

    private void Start()
    {
        eSpeed = speed;
        eCanMove = canMove;
        eVertical = vertical;
        myRigid = GetComponent<Rigidbody2D>();
        Move(myRigid);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            base.PlayerCollisionEnter(collision);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ChangeDir(collision, myRigid, transform);
    }

}
