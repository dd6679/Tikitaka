using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NK_Score : MonoBehaviour
{
    public static NK_Score ScoreManager;
    Text scoreText;
    int score = 0;
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            if (score >= 0)
            {
                score = value;
                // 점수 저장하기
                PlayerPrefs.SetInt("Score", score);
            }
        }
    }
    private void Awake()
    {
        ScoreManager = this;

        score = PlayerPrefs.GetInt("Score", 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = Score.ToString();
    }
}
