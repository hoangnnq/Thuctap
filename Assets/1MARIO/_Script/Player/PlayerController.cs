using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float speed = 5;
    public float jumpHeight = 20;
    public GameObject bullet;
    public RuntimeAnimatorController jumpAni, dieAni;
    public bool isMoveLeft, isMoveRight, isMoveUp, isFire;


    List<GameObject> lstBullet = new List<GameObject>();
    RuntimeAnimatorController idleRunAni;
    Rigidbody2D myRigid;
    Animator myAni;
    Collider2D myColli;
    SpriteRenderer mySpire;
    bool grounded = true;
    float thornCounter;
    public LayerMask groundLayer;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
        myAni = GetComponent<Animator>();
        myColli = GetComponent<Collider2D>();
        mySpire = GetComponent<SpriteRenderer>();

        idleRunAni = myAni.runtimeAnimatorController;
    }

    void FixedUpdate()
    {
        if(GameController.instance.Hp == 0)
        {
            return;
        }
        if (isCollisionThorn)
        {
            thornCounter -= Time.fixedDeltaTime;
            if(thornCounter <= 0)
            {
                GameController.instance.Hp--;
                CanvasController.instance.CheckHP();
                thornCounter = GameController.instance.TimeDesHp;
            }
        }

        Move();

        CheckHit(transform.position);

        Jump();

        Fire();
    }

    public void AniDie()
    {
        myAni.runtimeAnimatorController = dieAni;
        StartCoroutine(ChangeAniDie(1.5f));
        return;
    }


    IEnumerator ChangeAniDie(float time)
    {
        yield return new WaitForSeconds(time);
        this.gameObject.SetActive(false);
        GameController.instance.Score = 0;
    }

    void CheckHit(Vector2 pos)
    {
        var hit = Physics2D.BoxCast(transform.position, new Vector2(0.4f, 0.1f), 0, Vector2.zero, 1, groundLayer);
        if(hit.collider != null)
        {
            grounded = true;
            myAni.runtimeAnimatorController = idleRunAni;
        }
        else
        {
            grounded = false;
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
    }

    void Move()
    {
        float move = 0;
        if (Input.GetAxis("Horizontal") != 0)
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
        if (myAni.runtimeAnimatorController == idleRunAni)
        {
            myAni.SetFloat("speed", Mathf.Abs(move));
        }

        if (move > 0 && mySpire.flipX || move < 0 && !mySpire.flipX)
        {
            flip();
        }
    }

    void flip()
    {
        mySpire.flipX = !mySpire.flipX;
    }

    void Jump()
    {
        if ((Input.GetAxisRaw("Vertical") == 1 || isMoveUp) && grounded == true)
        {
            myRigid.velocity = new Vector2(myRigid.velocity.x, jumpHeight);
            myAni.runtimeAnimatorController = jumpAni;
        }
    }

    void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space) || isFire)
        {
            isFire = false;
            Vector2 posBullet = new Vector2(transform.position.x, transform.position.y + myColli.bounds.size.y);
            //ra dan + hieu ung
            if (mySpire.flipX)
            {
                posBullet = new Vector2(transform.position.x - myColli.bounds.size.x, posBullet.y);
            }
            else
            {
                posBullet = new Vector2(transform.position.x + myColli.bounds.size.x, posBullet.y);
            }
            bool chk = false;
            foreach (GameObject item in lstBullet)
            {
                if (item.activeInHierarchy)
                {
                    continue;
                }
                item.transform.position = posBullet;
                item.SetActive(true);
                chk = true;
                StartCoroutine(EnableBullet(item, 3));
                break;
            }
            if (!chk)
            {
                GameObject b = Instantiate(bullet, posBullet, Quaternion.identity);
                lstBullet.Add(b);
                StartCoroutine(EnableBullet(b, 3));
            }
        }
    }

    IEnumerator EnableBullet(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        obj.SetActive(false);
    }

    bool isCollisionThorn;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Thorn"))
        {
            isCollisionThorn = true;
            thornCounter = GameController.instance.TimeDesHp;
        }
        if (transform.localScale.x > 1 && collision.collider.CompareTag("Brick") && 
            collision.transform.position.y > transform.position.y + myColli.bounds.size.y)
        {
            //hieu ung no gach
            collision.gameObject.GetComponent<ParticleSystem>().Play(true);
            //collision.gameObject.SetActive(false);
            StartCoroutine(EffectBrick(collision.gameObject, 0.2f));
        }
    }
    IEnumerator EffectBrick(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        obj.SetActive(false);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Thorn"))
        {
            isCollisionThorn = false;
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            grounded = false;
            GameController.instance.Score++;
            CanvasController.instance.CheckScore();
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Medicine") && transform.localScale.x < 2)
        {
            transform.DOScale(new Vector3(1.5f, 1.5f, 1), 1);
            collision.gameObject.SetActive(false);
        }
    }
}
