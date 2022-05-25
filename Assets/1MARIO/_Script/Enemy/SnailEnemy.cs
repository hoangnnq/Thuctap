using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailEnemy : AnimalEnemy
{
    public float speed = 4;
    public bool canMove = true;
    public bool vertical;
    public string strAniDieSnail = "OcSen-die Animation";
    public string strAniDef = "OcSen-def Animation";

    Rigidbody2D myRigid;
    Animator myAni;

    //public SnailEnemy(float speed, bool canMove, bool isVertical, int dmg, string strAniDieSnail, string strAniDef) : base(speed, canMove, isVertical, dmg, strAniDieSnail)
    //{
    //    eDamage = 1;
    //    this.strAniDef = strAniDef;
    //}


    // Start is called before the first frame update
    void Start()
    {
        eSpeed = speed;
        eCanMove = canMove;
        eVertical = vertical;
        strAniDie = strAniDieSnail;
        myRigid = GetComponent<Rigidbody2D>();
        myAni = GetComponent<Animator>();
        Move(myRigid);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (collision.transform.position.y > transform.position.y)
            {
                myAni.SetBool("isDef", true);
                eSpeed *= 2f;
                Move(myRigid);
                Invoke("ObjRun", 4);
            }
            else
            {
                PlayerCollisionEnter(collision);
            }
        }
        if (collision.collider.CompareTag("Bullet"))
        {
            PlayAniDie(myAni);
            Invoke("ObjActive", 0.3f);
        }
    }

    void ObjRun()
    {
        myAni.SetBool("isDef", false);
        eSpeed /= 2f;
        Move(myRigid);
    }

    void ObjActive()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Move(myRigid);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ChangeDir(collision, myRigid,transform);
    }
}
