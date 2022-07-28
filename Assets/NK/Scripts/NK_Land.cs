using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_Land : MonoBehaviour
{
    public float fspeed = 5;
    public float freq = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = fspeed * Mathf.Sin(Time.time * freq) * freq;
        Vector3 dir = new Vector3(0, x, 0);
        transform.position += dir * Time.deltaTime;
    }
}
