using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SY_CameraMove : MonoBehaviour
{

    public Transform playerTransform;
    public Vector3 Offset;



    // Start is called before the first frame update
    void Awake()
    {
        

       
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = playerTransform.position + Offset;
    }
}
