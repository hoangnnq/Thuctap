using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisiableGround : MonoBehaviour
{
    [SerializeField] GameObject objFalse;
    [SerializeField] GameObject effect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            objFalse.SetActive(false);
            effect.transform.position = transform.position;
            effect.SetActive(true);
            Invoke("enableeffect", 1);
            this.gameObject.SetActive(false);
        }
    }

    void enableeffect()
    {
        effect.SetActive(false);
    }
}
