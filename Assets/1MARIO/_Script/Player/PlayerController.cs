using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField] float speed = 5;
    [SerializeField] float jumpheight = 20;
    [SerializeField] RuntimeAnimatorController jumpAni, dieAni;
    RuntimeAnimatorController idlerunAni;
    bool faceright = true;
    Rigidbody2D myRigid;
    Animator myAni;
    Collider2D myColli;
    bool grounded = true;
    float timenow;
    public bool isMoveLeft, isMoveRight, isMoveUp;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        myRigid = this.GetComponent<Rigidbody2D>();
        myAni = this.GetComponent<Animator>();
        myColli = this.GetComponent<Collider2D>();
        idlerunAni = myAni.runtimeAnimatorController;
        timenow = GameController.instance.TimeDesHp;
    }

    void FixedUpdate()
    {
        if (GameController.instance.Hp == 0)
        {
            myAni.runtimeAnimatorController = dieAni;
            StartCoroutine(ChangeAniDie(1.5f));
            return;
        }
        if (GameController.instance.TimeDesHp > timenow)
        {
            timenow += Time.deltaTime;
        }

        Move();

        ChekckHit(transform.position);

        Jump();

        Fire();
    }

    IEnumerator ChangeAniDie(float time)
    {
        yield return new WaitForSeconds(time);
        this.gameObject.SetActive(false);
        GameController.instance.Score = 0;
        SceneManager.LoadScene(0);
    }

    void ChekckHit(Vector2 pos)
    {
        RaycastHit2D[] hits = new RaycastHit2D[4];
        myColli.Cast(Vector2.down, hits, 0.3f);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider == null)
            {
                continue;
            }
            else
            {
                grounded = true;
                myAni.runtimeAnimatorController = idlerunAni;
                if (hit.collider.tag == "Thorn" && timenow >= GameController.instance.TimeDesHp)
                {
                    timenow = 0;
                    GameController.instance.Hp--;
                }
                return;
            }
        }
        myAni.runtimeAnimatorController = jumpAni;
        if (myRigid.velocity.y > 0)
        {
            myAni.SetBool("isup", true);
        }
        else
        {
            myAni.SetBool("isup", false);
        }

    }

    void Move()
    {
        float move = 0;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            move = Input.GetAxis("Horizontal");
        }
        else
        {
            if (isMoveLeft)
            {
                move = -1;
            }
            else if (isMoveRight)
            {
                move = 1;
            }
        }
        myRigid.velocity = new Vector2(move * speed, myRigid.velocity.y);
        if (myAni.runtimeAnimatorController == idlerunAni)
        {
            myAni.SetFloat("speed", Mathf.Abs(move));
        }

        if (move > 0 && !faceright || move < 0 && faceright)
        {
            flip();
        }
    }

    void flip()
    {
        faceright = !faceright;
        this.transform.localScale *= new Vector2(-1, 1);
    }

    void Jump()
    {
        if ((Input.GetAxisRaw("Vertical") == 1 || isMoveUp) && grounded == true)
        {
            myRigid.velocity = new Vector2(myRigid.velocity.x, jumpheight);
            myAni.runtimeAnimatorController = jumpAni;
            grounded = false;
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            GameController.instance.Score++;
            collision.gameObject.SetActive(false);
        }
    }
}
