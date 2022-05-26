using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D myRigid;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnEnable()
    {
        if (myRigid == null)
        {
            myRigid = GetComponent<Rigidbody2D>();
        }
        Move();
    }

    void Move()
    {
        if (GameController.instance.Player.GetComponent<SpriteRenderer>().flipX)
        {
            myRigid.velocity = new Vector2(-6, 0);
        }
        else
        {
            myRigid.velocity = new Vector2(6, 0);
        }
    }
}

