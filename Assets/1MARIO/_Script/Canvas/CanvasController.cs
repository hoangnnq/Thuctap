using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public static CanvasController instance;
    public Slider hp;
    public Text txtLevel;
    public Text txtScore;
    public GameObject Notify;
    public Text txtDieYourScore;
    public Text txtNotify;
    public GameObject CompleteLv;
    public Button btnNext;
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
        txtScore.text = "Score: " + Prefs.SumScore.ToString();
    }


    public void CheckHP()
    {
        hp.value = GameController.instance.Hp;
        if (hp.value == 0)
        {
            PlayerController.instance.AniDie();
            txtDieYourScore.text = "Your Score: " + (GameController.instance.Score + Prefs.SumScore);
            txtNotify.text = "You are die!";
            Notify.SetActive(true);
        }
    }

    public void VisiableCompleteLv()
    {
        CompleteLv.SetActive(true);
        btnNext.onClick.AddListener(NextLv); 
    }

    void NextLv()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void win()
    {
        Notify.SetActive(true);
        txtDieYourScore.text = "Your Score: " + Prefs.SumScore;
        txtNotify.text = "You are win!";
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
