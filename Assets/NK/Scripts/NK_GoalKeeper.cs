using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_GoalKeeper : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpSpeed = 7.0f;
    public float range = 10.0f;
    Transform target;
    Rigidbody rigid;
    float xPosition;
    float yPosition;
    float zPosition;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
        rigid = GetComponent<Rigidbody>();
        xPosition = transform.position.x;
        yPosition = transform.position.y;
        zPosition = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = ClampPosition(transform.localPosition);
    }

    private void FixedUpdate()
    {
        //transform.localPosition = ClampPosition(transform.localPosition);

        // 골키퍼 사정 거리로 공이 들어오고 플레이어가 점프를 하면 골키퍼가 점프하도록
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= range && SY_PlayerMove.isJump)
        {
            //transform.position += Vector3.up * jumpSpeed * Time.deltaTime;
            rigid.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }
        else
        {
            // 플레이어 방향으로 x좌표만 움직이게 함
            Vector3 direction = new Vector3(target.position.x - xPosition, 0, 0);
            direction.Normalize();
            rigid.position += direction * moveSpeed * Time.deltaTime;

        }
    }

    public Vector3 ClampPosition(Vector3 position)
    {
        return new Vector3
            (
            Mathf.Clamp(position.x, xPosition - 4, xPosition + 4),
            Mathf.Clamp(position.y, yPosition, yPosition + 2), zPosition
            );
    }
}
