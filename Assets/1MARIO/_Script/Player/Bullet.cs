using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D myRigid = GetComponent<Rigidbody2D>();
        if (GameController.instance.Player.GetComponent<SpriteRenderer>().flipX)
        {
            myRigid.velocity = new Vector2(-5, 0);
        }
        else
        {
            myRigid.velocity = new Vector2(-5, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
