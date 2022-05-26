using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BrickCoin : MonoBehaviour
{
    public GameObject popup;
    public GameObject coin;
    public int quantitymax = 1;
    public bool isCherry = false;
    List<GameObject> coins = new List<GameObject>();
    int number = 0;
    Vector2 poscoin;
    // Start is called before the first frame update
    void Start()
    {
        poscoin = popup.transform.position;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Player"))
        {
            return;
        }
        if (collision.transform.position.y + collision.collider.bounds.size.y < transform.position.y && number < quantitymax)
        {
            number++;
            if (number == quantitymax)
            {
                popup.SetActive(false);
            }
            if (isCherry)
            {
                GameObject cherry = Instantiate(coin, poscoin, Quaternion.identity);
                cherry.transform.DOMoveY(poscoin.y + 1, 4).SetSpeedBased();
            }
            else
            {
                ReCoins();
            }
            return;
        }
    }

    void ReCoins()
    {
        bool chk = false;
        foreach (GameObject item in coins)
        {
            if (item.activeInHierarchy)
            {
                continue;
            }
            item.transform.position = poscoin;
            item.SetActive(true);
            chk = true;
            MoveCoin(item);
            break;
        }
        if (!chk)
        {
            GameObject c = Instantiate(coin, poscoin, Quaternion.identity);
            c.transform.SetParent(transform);
            coins.Add(c);
            MoveCoin(c);
        }
    }

    void MoveCoin(GameObject obj)
    {
        obj.transform.DOMoveY(poscoin.y + 2, 4).SetSpeedBased();
        GameController.instance.Score++;
        CanvasController.instance.CheckScore();
        StartCoroutine(EnableCoin(obj));
    }

    IEnumerator EnableCoin(GameObject obj)
    {
        yield return new WaitForSeconds(1f);
        obj.SetActive(false);
    }
}
