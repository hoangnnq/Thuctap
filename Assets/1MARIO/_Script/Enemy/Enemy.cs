using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed;
    private bool vertical;
    private int damage;
    private int score;

    public Enemy(float speed, bool vertical, int damage, int score = 1)
    {
        this.speed = speed;
        this.vertical = vertical;
        this.damage = damage;
        this.score = score;
    }

    public float Speed { get => speed; set => speed = value; }
    public bool Vertical { get => vertical; set => vertical = value; }
    public int Damage { get => damage; set => damage = value; }
    public int Score { get => score; set => score = value; }
}
