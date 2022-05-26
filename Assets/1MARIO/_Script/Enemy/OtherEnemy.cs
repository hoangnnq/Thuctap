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
        if (collision.collider.CompareTag("Bullet"))
        {
            EnemyDie(collision.gameObject);
        }
        if (collision.collider.CompareTag("Player"))
        {
            ChangeDir(collision.collider, myRigid, transform);
            if (collision.transform.position.y > transform.position.y)
            {
                EnemyDie();
            }
            else
            {
                base.PlayerCollisionEnter(collision);
            }
        }
    }

    void EnemyDie(GameObject obj = null)
    {
        if (obj != null)
        {
            obj.SetActive(false);
        }
        PlayAniDie(myAni);
        DG.Tweening.DOVirtual.DelayedCall(0.3f, ObjActive);
        //=Invoke("ObjActive", 0.3f);
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
