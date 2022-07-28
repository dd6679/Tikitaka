using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_Box : MonoBehaviour
{
    public ParticleSystem explosion;

    private GameObject itemType;
    private int itemSize = 5;

    // Start is called before the first frame update
    void Start()
    {
        if (NK_SpawnManager.boxCount <= 5)
        {
            itemType = Instantiate(Resources.Load("Items/item" + NK_SpawnManager.boxCount) as GameObject);
        }
        else
        {
            int randomItem = Random.Range(0, 10);
            if (randomItem < 5)
            {
                // 코인 추가
                itemType = Instantiate(Resources.Load("Items/item4") as GameObject);
            }
            else
            {
                // 아이템 추가
                itemType = Instantiate(Resources.Load("Items/item" + Random.Range(1, itemSize + 1)) as GameObject);
            }
        }

        itemType.SetActive(false);
        itemType.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Player")
        {
            itemType.SetActive(true);
            Destroy(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
    }
}
