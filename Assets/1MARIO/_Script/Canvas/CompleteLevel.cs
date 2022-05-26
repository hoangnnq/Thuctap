using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour
{
    public int maxLv = 10;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Prefs.SumScore += GameController.instance.Score;
            if (Prefs.SceneLevel == maxLv)
            {
                CanvasController.instance.win();
                return;
            }
            Prefs.SceneLevel++;
            CanvasController.instance.VisiableCompleteLv();
        }
    }
}
