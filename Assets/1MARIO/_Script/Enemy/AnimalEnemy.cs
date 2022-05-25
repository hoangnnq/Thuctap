using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalEnemy : Enemy
{

    [HideInInspector] public string strAniDie;

    //public AnimalEnemy(float speed, bool canMove, bool isVertical, int dmg, string strAniDie) : base(speed, canMove, isVertical, dmg)
    //{
    //    this.strAniDie = strAniDie;
    //}
    public void PlayAniDie(Animator myAni)
    {
        myAni.Play(strAniDie);
        GameController.instance.Score += 2;
        CanvasController.instance.CheckScore();
    }
}
