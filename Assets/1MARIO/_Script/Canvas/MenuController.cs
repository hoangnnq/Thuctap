using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject objResume;
    public Text highScore;
    // Start is called before the first frame update
    void Start()
    {
        if (Prefs.SceneLevel != 0)
        {
            objResume.SetActive(true);
        }
        else if (objResume.activeInHierarchy)
        {
            objResume.SetActive(false);
        }
        highScore.text = "High Score : " + Prefs.HighScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

}
