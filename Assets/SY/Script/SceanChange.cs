using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceanChange : MonoBehaviour
{
    public void Change()
    {
        SceneManager.LoadScene("PlayScene2");
    }
}