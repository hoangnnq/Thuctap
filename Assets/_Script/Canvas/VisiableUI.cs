using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VisiableUI : MonoBehaviour
{
    public void Visiableui(GameObject visiableui)
    {
        visiableui.SetActive(!visiableui.activeInHierarchy);
    }

    public void LoadLevel(int indexScene)
    {
        SceneManager.LoadScene(indexScene);
    }

    public void SelectPlayer(int iPlayer)
    {
        Prefs.SelectPlayer = iPlayer;
    }

    public void CompletePlayer()
    {
        LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
