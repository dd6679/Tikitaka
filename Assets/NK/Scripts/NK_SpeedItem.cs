using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_SpeedItem : MonoBehaviour
{
    public float speed = 30f;
    public float holdingTime = 3;
    float currentTime = 0;
    GameObject player;
    float localSpeed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        localSpeed = SY_PlayerMove.speed;
        SY_PlayerMove.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (holdingTime < currentTime)
        {
            SY_PlayerMove.speed = localSpeed;
            Destroy(gameObject);
        }
    }
}
