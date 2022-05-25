using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public static CanvasController instance;
    [SerializeField] Slider hp;
    [SerializeField] Text txtLevel;
    [SerializeField] Text txtScore;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        hp.maxValue = GameController.instance.MaxHp;
        hp.value = float.MaxValue;
        txtLevel.text = "Level: " + Prefs.SceneLevel.ToString();
    }


    public void CheckHP()
    {
        hp.value = GameController.instance.Hp;
        if (hp.value == 0)
        {
            PlayerController.instance.AniDie();
        }
    }
    public void CheckScore()
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
    public void Fire()
    {
        PlayerController.instance.isFire = true;
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
    public void UnFire()
    {
        PlayerController.instance.isFire = false;
    }
}
