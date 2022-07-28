using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_SizeItem : MonoBehaviour
{
    public float size = 10f;
    public float holdingTime = 3;
    float currentTime = 0;
    GameObject player;
    Vector3 localsize;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        localsize = player.transform.localScale;
        player.transform.localScale = new Vector3(size, size, size);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (holdingTime < currentTime)
        {
            player.transform.localScale = localsize;
            Destroy(gameObject);
        }
    }
}
