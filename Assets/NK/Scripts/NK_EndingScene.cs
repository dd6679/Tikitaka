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
        // 1�� �������� �� �гξ� ����, 100�� ����
    }
}
