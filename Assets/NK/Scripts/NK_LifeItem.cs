using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_LifeItem : MonoBehaviour
{
    public float holdingTime = 3;
    float currentTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        // 생명 증가
        NK_Life.LifeManager.Life++;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (holdingTime < currentTime)
        {
            Destroy(gameObject);
        }
    }
}
