using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    [HideInInspector] public float eSpeed ;
    [HideInInspector] public bool eCanMove;
    [HideInInspector] public bool eVertical;


    //public Enemy(float speed, bool canMove, bool isVertical, int dmg)
    //{
    //    eSpeed = speed;
    //    eCanMove = canMove;
    //    eVertical = isVertical;
    //    eDamage = dmg;
    //}

    public void ChangeDir(Collider2D collision, Rigidbody2D myRigid, Transform myTranf)
    {
        if (collision.CompareTag("ChangeDir") || collision.CompareTag("Player"))
        {
            myTranf.localScale *= new Vector2(-1, 1);
            eSpeed = -eSpeed;
            Move(myRigid);
        }
    }

    public virtual void Move(Rigidbody2D myRigid)
    {
        if (eCanMove)
        {
            if (eVertical)
            {
                myRigid.velocity = new Vector2(0, eSpeed);
            }
            else
            {
                myRigid.velocity = new Vector2(eSpeed, 0);
            }
        }
    }

    public virtual void PlayerCollisionEnter(Collision2D collision)
    {
        if (collision.transform.localScale.x > 1)
        {
            collision.transform.DOScale(new Vector3(1, 1, 1), 1);
        }
        else
        {
            GameController.instance.Hp--;
            CanvasController.instance.CheckHP();
        }
    }

    public void OnDestroy()
    {
        transform.DOKill();
    }
}
