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
    float timeComeOut = 4;
    float speedBeforeDef;

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

    private void Update()
    {
        timeComeOut -= Time.deltaTime;
        if (timeComeOut <= 0 && myAni.GetBool("isDef")) 
        {
            myAni.SetBool("isDef", false);
            eSpeed = speedBeforeDef;
            Move(myRigid);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            collision.gameObject.SetActive(false);
            PlayAniDie(myAni);
            Invoke("ObjActive", 0.3f);
        }
        if (!collision.collider.CompareTag("Player"))
        {
            return;
        }
        if (!myAni.GetBool("isDef"))
        {
            if (collision.transform.position.y > transform.position.y)
            {
                myAni.SetBool("isDef", true);
                speedBeforeDef = eSpeed;
                eSpeed = 0;
                Move(myRigid);
            }
            else
            {
                PlayerCollisionEnter(collision);
            }
        }
        else
        {
            if (collision.transform.position.x > transform.position.x )
            {
                eSpeed = -speed * 2;
            }
            else
            {
                eSpeed = speed * 2;
            }
            Move(myRigid); 
            PlayerCollisionEnter(collision);
        }
        timeComeOut = 4;
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
        speedBeforeDef = -speedBeforeDef;
        ChangeDir(collision, myRigid,transform);
    }
}
