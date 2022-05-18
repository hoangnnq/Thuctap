using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{

    [SerializeField] Slider hp;
    [SerializeField] Text score;
    // Start is called before the first frame update
    void Start()
    {
        hp.maxValue = GameController.instance.MaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + GameController.instance.Score;
        hp.value = GameController.instance.Hp;
        CheckPlayer();

    }
    void CheckPlayer()
    {
        if (!GameController.instance.Player.activeInHierarchy)
        {
            //end
        }
    }

}
