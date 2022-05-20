using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] float PosLimit = 2;
    [SerializeField] string strAniDie;
    public bool canMove;
    SpriteRenderer enemy;
    Animator myAni;
    Vector2 pos;
    void Start()
    {
        pos = this.transform.position;
        enemy = this.GetComponent<SpriteRenderer>();
        myAni = this.GetComponent<Animator>();

        if (canMove)
        {
            transform.DOMoveX(pos.x + PosLimit, speed).SetSpeedBased().SetLoops(-1, LoopType.Yoyo).OnStepComplete(() =>
            {
                PosLimit = -PosLimit;
                enemy.flipX = !enemy.flipX;
            });
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Player" )
        {
            return;
        }
        if (this.tag == "Enemy")
        {
            if (collision.transform.position.y > transform.position.y)
            {
                GameController.instance.Score += 2;
                myAni.Play(strAniDie);
                Invoke("ObjActive", 0.3f);
            }
            else
            {
                GameController.instance.Hp--;
            }
        }
        else if (this.tag == "EnemyNotDestroy")
        {
            GameController.instance.Hp--;
        }
    }
    void ObjActive()
    {
        this.gameObject.SetActive(false);
    }
}
