using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_SpawnManager : MonoBehaviour
{
    // 필요속성 : 아이템타입, 아이템저장소
    public GameObject randomBoxFactory;
    public List<GameObject> randomBoxPool = new List<GameObject>();
    public int itemPoolSize = 10;
    public static int boxCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        // 랜덤 아이템을 만들어 오브젝트 풀에 넣어놓음
        for (int i = 0; i < itemPoolSize; i++)
        {
            GameObject randomBox = Instantiate(randomBoxFactory);
            randomBoxPool.Add(randomBox);
            randomBox.SetActive(false);
        }
        StartCoroutine("EnableObject");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.m_state != GameManager.GameState.Playing)
        {
            // -> 처리하지 못하게 하자.
            return;
        }

        Transform player = GameObject.Find("Player").transform;
        // 플레이어가 움직이는 값을 가져와 랜덤으로 위치 지정
/*        Vector3 pos = new Vector3(player.position.x, 0.5f, player.position.z)
            + new Vector3(Random.Range(5, -5), 0, Random.Range(5,-5));*/
        Vector3 pos = new Vector3(player.position.x, player.position.y - 0.5f, player.position.z)
    + new Vector3(Random.Range(5, -5), 0, Random.Range(5, -5));
        randomBoxPool[0].transform.position = pos;
    }

    IEnumerator EnableObject()
    {
        if (GameManager.Instance.m_state != GameManager.GameState.Playing)
        {
            // -> 처리하지 못하게 하자.
            yield return 0;
        }
        yield return new WaitForSeconds(5f);
        if (randomBoxPool.Count > 0)
        {
            randomBoxPool[0].SetActive(true);
            randomBoxPool.RemoveAt(0);
            boxCount++;
        }
        StartCoroutine("EnableObject");
    }
}
