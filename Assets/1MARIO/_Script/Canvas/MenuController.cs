using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject objResume;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Prefs.SceneLevel != 0)
        {
            objResume.SetActive(true);
        }
        else if (objResume.activeInHierarchy)
        {
            objResume.SetActive(false);
        } 
    }

}
