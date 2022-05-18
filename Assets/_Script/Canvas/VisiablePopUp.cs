using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//http://dotween.demigiant.com/documentation.php
public class VisiablePopUp : MonoBehaviour
{
    [SerializeField] GameObject popup;
    [SerializeField] GameObject coin;
    [SerializeField] int chammax = 1;
    int d = 0;
    float coiny;
    Collider2D mycoli;
    // Start is called before the first frame update
    void Start()
    {
        coiny = coin.transform.position.y + 1;
        mycoli = this.GetComponent<Collider2D>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && collision.transform.position.y < transform.position.y && d < chammax)
        {
            d++;
            popup.SetActive(false);
            coin.SetActive(true);
            coin.transform.DOMoveY(coiny, 4).SetSpeedBased();
            return;
        }
    }
}
