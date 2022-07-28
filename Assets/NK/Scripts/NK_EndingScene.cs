using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NK_EndingScene : MonoBehaviour
{
    public Text topScoreText;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        topScoreText.text = "Top Score : " + PlayerPrefs.GetInt("TopScore");
        scoreText.text = "My Score : " + PlayerPrefs.GetInt("Score");
    }

    // Update is called once per frame
    void Update()
    {
        // 1초 간격으로 한 패널씩 띄우기, 100씩 차이
    }
}
