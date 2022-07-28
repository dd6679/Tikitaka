using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class NK_Rank : MonoBehaviour
{
    public int rankCount = 5;
    public float rankTime = 10;
    public List<GameObject> panels = new List<GameObject>();

    float currentTime = 0;
    int count = 0;
    Text rankText;
    Dictionary<string, int> rank = new Dictionary<string, int>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < rankCount; i++)
        {
            panels[i].SetActive(false);
            if (PlayerPrefs.HasKey((i + 1) + "BestUser") && rank.ContainsKey((i + 1) + "BestUser") == false)
            {
                rank.Add(PlayerPrefs.GetString((i + 1) + "BestUser"), PlayerPrefs.GetInt((i + 1) + "BestScore"));
            }
        }

        if (rank.ContainsKey(PlayerPrefs.GetString("CurrentUserName")) == false)
            rank.Add(PlayerPrefs.GetString("CurrentUserName"), PlayerPrefs.GetInt("Score"));
        else
            rank[PlayerPrefs.GetString("CurrentUserName")] = PlayerPrefs.GetInt("Score");

        rank = rank.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

        foreach (KeyValuePair<string, int> i in rank)
        {
            if (count < 5)
            {
                GameObject rankPanel = panels[count];
                rankPanel.transform.parent = transform;
                rankText = rankPanel.GetComponentInChildren<Text>();
                rankText.text = (count + 1) + "            " + i.Key + "            " + i.Value;
                PlayerPrefs.SetString((count + 1) + "BestUser", i.Key);
                PlayerPrefs.SetInt((count + 1) + "BestScore", i.Value);
                count++;
            }
        }
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime++;
        if (count < 5 && currentTime > rankTime)
        {
            panels[count].SetActive(true);
            count++;
            currentTime = 0;
        }
    }
}
