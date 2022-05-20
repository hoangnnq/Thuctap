using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{

    [SerializeField] Slider hp;
    [SerializeField] Text txtLevel;
    [SerializeField] Text txtScore;
    // Start is called before the first frame update
    void Start()
    {
        hp.maxValue = GameController.instance.MaxHp;
        txtLevel.text = "Level: " + Prefs.SceneLevel.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        CheckHighScore();
        hp.value = GameController.instance.Hp;
    }
    void CheckHighScore()
    {
        if (Prefs.HighScore < GameController.instance.Score + Prefs.SumScore)
        {
            Prefs.HighScore = GameController.instance.Score + Prefs.SumScore;
            txtScore.text = "High Score: " + Prefs.HighScore;
            return;
        }
        txtScore.text = "Score: " + (GameController.instance.Score + Prefs.SumScore);
    }

    public void MoveLeft()
    {
        PlayerController.instance.isMoveLeft = true;
    }
    public void MoveRight()
    {
        PlayerController.instance.isMoveRight = true;
    }
    public void MoveUp()
    {
        PlayerController.instance.isMoveUp = true;
    }

    public void UnmoveLeft()
    {
        PlayerController.instance.isMoveLeft = false;
    }
    public void UnmoveRight()
    {
        PlayerController.instance.isMoveRight = false;
    }
    public void UnmoveUp()
    {
        PlayerController.instance.isMoveUp = false;
    }
}
