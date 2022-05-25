using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [SerializeField] List<GameObject> ListPlayer;

    public GameObject Player;
    public int MaxHp = 1;
    public int Hp ;

    public int Score = 0;

    public float TimeDesHp = 2;
    // Start is called before the first frame update
    void Awake()
    {
        Hp = MaxHp;
        Player = ListPlayer[Prefs.SelectPlayer];
        Player.SetActive(true);
        if (GameController.instance != null)
        {
            return;
        }
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
