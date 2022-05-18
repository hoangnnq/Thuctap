using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] float jumpheight = 10;
    [SerializeField] RuntimeAnimatorController jumpAni,dieAni;
    RuntimeAnimatorController idlerunAni;
    bool faceright = true;
    Rigidbody2D myRigid;
    Animator myAni;
    Collision2D myColli;
    int grounded = 0;
    float timenow;
    // Start is called before the first frame update
    void Start()
    {
        myRigid = this.GetComponent<Rigidbody2D>();
        myAni = this.GetComponent<Animator>();
        myColli = this.GetComponent<Collision2D>();

        idlerunAni = myAni.runtimeAnimatorController;
        timenow = GameController.instance.TimeDesHp;
    }

    void FixedUpdate()
    {
        CheckDie();
        if (GameController.instance.TimeDesHp > timenow)
        {
            timenow += Time.deltaTime;
        }

        Move();

        ChekckHit(transform.position);

        Fire();
    }
    void CheckDie()
    {
        if (GameController.instance.Hp == 0)
        {
            myAni.runtimeAnimatorController = dieAni;
            StartCoroutine(ChangeAniDie(2));
        }
    }

    IEnumerator ChangeAniDie(float time)
    {
        yield return new WaitForSeconds(time);
        this.gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }

    void ChekckHit(Vector2 pos)
    {
        RaycastHit2D hitdown = Physics2D.Raycast(new Vector2(pos.x, pos.y - 0.7f), Vector2.down, 0.3f);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - 0.7f), Vector2.down, Color.green);
        if (hitdown.collider == null)
        {
            //Debug.Log("empty");
        }
        else
        {
            //Debug.Log(hitdown.collider.tag + " " + grounded);
            if (myAni.runtimeAnimatorController == jumpAni)
            {
                grounded = 0;
                myAni.runtimeAnimatorController = idlerunAni;
            }
            else if (hitdown.collider.tag == "Thorn" && timenow >= GameController.instance.TimeDesHp)
            {
                timenow = 0;
                GameController.instance.Hp--;
            }
            Jump();
        }

    }

    void Move()
    {
        float move = Input.GetAxis("Horizontal");
        myRigid.velocity = new Vector2(move * speed , myRigid.velocity.y);
        if (myAni.runtimeAnimatorController == idlerunAni)
        {
            myAni.SetFloat("speed", Mathf.Abs(move));
        }
        else if(myAni.runtimeAnimatorController == jumpAni)
        {
            if (myRigid.velocity.y > 0)
            {
                myAni.SetBool("isup", true);
            }
            else
            {
                myAni.SetBool("isup", false);
            }
        }

        if (move > 0 && !faceright)
        {
            flip();
        }
        else if (move <0 && faceright)
        {
            flip();
        }
    }

    void flip()
    {
        faceright = !faceright;
        this.transform.localScale *= new Vector2(-1,1);
    }

    void Jump()
    {
        //Debug.Log(grounded);
        if (Input.GetAxisRaw("Vertical") == 1 && grounded == 0)
        {
            myRigid.velocity = new Vector2(myRigid.velocity.x, jumpheight);
            myAni.runtimeAnimatorController = jumpAni;
            grounded = 1;
        }
    }

    void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //ra dan + hieu ung

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Brick" && collision.transform.position.y > transform.position.y)
        {
            collision.gameObject.SetActive(false);

        }
        if (collision.collider.tag == "Coin")
        {
            GameController.instance.Score++;
            collision.gameObject.SetActive(false);
        }
    }
}
