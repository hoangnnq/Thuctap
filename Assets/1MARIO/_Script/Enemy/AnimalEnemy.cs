using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalEnemy : Enemy
{

    [HideInInspector] public string strAniDie;

    public void PlayAniDie(Animator myAni)
    {
        myAni.Play(strAniDie);
        GameController.instance.Score += 2;
        CanvasController.instance.CheckScore();
    }
}
