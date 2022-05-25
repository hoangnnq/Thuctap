using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherEnemy : AnimalEnemy
{
    public float speed = 4;
    public bool canMove = true;
    public bool vertical;
    public string strAniDieOther = "Mushroom-die Animation";
    Rigidbody2D myRigid;
    Animator myAni;

    //public OtherEnemy(float speed, bool canMove, bool isVertical, int dmg, string strAniDieOther) : base(speed, canMove, isVertical, dmg, strAniDieOther)
    //{
    //}

    private void Start()
    {

        eSpeed = speed;
        eCanMove = canMove;
        eVertical = vertical;
        strAniDie = strAniDieOther;
        myRigid = GetComponent<Rigidbody2D>();
        myAni = GetComponent<Animator>();
        Move(myRigid);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Player"))
        {
            return;
        }
        ChangeDir(collision.collider, myRigid, transform);
        if (collision.transform.position.y > transform.position.y || collision.collider.CompareTag("Bullet"))
        {
            PlayAniDie(myAni);
            Invoke("ObjActive", 0.3f);
        }
        else
        {
            base.PlayerCollisionEnter(collision);
        }
    }

    void ObjActive()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ChangeDir(collision, myRigid, transform);
    }
}
