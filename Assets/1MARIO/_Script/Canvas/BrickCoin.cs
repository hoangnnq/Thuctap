using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BrickCoin : MonoBehaviour
{
    [SerializeField] GameObject popup;
    [SerializeField] GameObject coin;
    [SerializeField] int quantitymax = 1;
    List<GameObject> coins = new List<GameObject>();
    int d = 0;
    Vector2 poscoin;
    // Start is called before the first frame update
    void Start()
    {
        poscoin = popup.transform.position;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && collision.transform.position.y < transform.position.y && d < quantitymax)
        {
            d++;
            if (d == quantitymax)
            {
                popup.SetActive(false);
            }
            ReCoins();
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
        StartCoroutine(EnableCoin(obj));
    }

    IEnumerator EnableCoin(GameObject obj)
    {
        yield return new WaitForSeconds(1f);
        obj.SetActive(false);
    }
}
