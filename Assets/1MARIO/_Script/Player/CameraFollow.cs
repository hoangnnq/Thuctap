using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject player;
    [SerializeField] float minX, minY, maxX, maxY;
    // Start is called before the first frame update
    void Start()
    {
        player = GameController.instance.Player;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 temp = new Vector3(player.transform.position.x, player.transform.position.y,-10);

            if (temp.x < minX)
            {
                temp.x = minX;
            }
            if (temp.x > maxX)
            {
                temp.x = maxX;
            }
            if (temp.y < minY)
            {
                temp.y = minY;
            }
            if (temp.y > maxY)
            {
                temp.y = maxX;
            }
            transform.position = temp;
        }
        
    }
}
