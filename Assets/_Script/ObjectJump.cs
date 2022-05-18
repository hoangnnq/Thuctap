using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectJump : MonoBehaviour
{
    [SerializeField] float height = 12;
    Animator myAni;
    SpriteRenderer mySpriteRenderer;
    Sprite img;
    // Start is called before the first frame update
    void Start()
    {
        myAni = this.GetComponent<Animator>();
        mySpriteRenderer = this.GetComponent<SpriteRenderer>();
        img = mySpriteRenderer.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            myAni.Play("ObjJump Animation");
            collision.rigidbody.velocity = new Vector2(collision.rigidbody.velocity.x, height); 
            //Invoke("enableAnimator", 2);
            //collision.relativeVelocity
        }
    }

    void enableAnimator()
    {
        mySpriteRenderer.sprite = img;
    }
}
