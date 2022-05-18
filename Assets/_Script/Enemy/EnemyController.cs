using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] float TimeChangePos = 1;
    [SerializeField] float PosLimit = 2;
    float timenow = 0;
    SpriteRenderer enemy;
    Vector2 pos;
    void Start()
    {
        pos = this.transform.position;
        enemy = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangePos(); 
        transform.DOMoveX(pos.x + PosLimit, speed).SetSpeedBased();
    }
    void ChangePos()
    {
        timenow += Time.deltaTime;
        if (timenow > TimeChangePos)
        {
            PosLimit = -PosLimit;
            timenow = 0;
            enemy.flipX = !enemy.flipX;
        }
    }
}
