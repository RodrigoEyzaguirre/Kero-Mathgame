using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeFollow : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
    }


    void Update()
    {
        Follow();
    }

    void Follow()
    {
        Vector2 playerPos = player.transform.position;

        Vector2 direction = new Vector2(
            playerPos.x - transform.position.x,
            playerPos.y - transform.position.y
            );

        transform.up = direction;
    }
}
