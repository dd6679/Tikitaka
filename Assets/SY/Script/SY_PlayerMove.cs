using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SY_PlayerMove : MonoBehaviour
{
    public static float speed = 15;
    //public float maxSpeed = 8;
    public float jumpPower;
    public ParticleSystem explosion;
    public SY_PlayerMove player;
    public static bool isJump;
    public float dieTime = 2;
    float currentTime = 0;
    AudioSource audioSource;
    float alpha = 0.5f;

    Gradient gradient = new Gradient();
    Rigidbody rigid;
    TrailRenderer trail;

    

    // Start is called before the first frame update
    private void Awake()
    {
        
        isJump = false;

        rigid = GetComponent<Rigidbody>();
        trail = GetComponent<TrailRenderer>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }
   
    public float gravity = -9.81f;
    float yVelocity;
    void FixedUpdate()
    {
        if (GameManager.Instance.m_state != GameManager.GameState.Playing)
        {
            // -> 처리하지 못하게 하자.
            return;
        }

        // 사용자 입력에 따라
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(h, 0, v);
        rigid.AddForce(movement * speed);

        // 1. y속도에 중력을 계속 더하고 싶다.
        yVelocity += gravity * Time.deltaTime;
       // 2. 만약 사용자가 점프버튼을 누르면 y속도에 뛰는 힘을 대입하고 싶다.
       if (Input.GetButtonDown("Jump") && !isJump)
       {
           isJump = true;
           rigid.velocity = jumpPower * Vector3.up;
       }
       
       if (rigid.velocity.y < 0)
       {
           //rigid.velocity += Vector3.down * Time.deltaTime;
           rigid.velocity += Vector3.up * gravity * Time.deltaTime;
           // * 중력은 떨어지는 속도를 크게 해줄 때 사용 ( 중력 연산을 두번 받는 다고 생각하면 됨 )
       }
       else if (rigid.velocity.y > 0 && !Input.GetButton("Jump"))
       {
           rigid.velocity += Vector3.up * gravity * Time.deltaTime;
           // 점프하여 올라가는 상태의 y축 운동량(velocity)를 급격하게 깎아주기 위해서 사용
       }

        // 만약에 플레이어가 점프를 하면
        if (isJump)
        {
            // Yellow 로 표시
            gradient.SetKeys
            (
                new GradientColorKey[] { new GradientColorKey(Color.yellow, 0.0f) },
                new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
            );
        }
        else
        {
            // 그렇지 않으면, Grey로 표시
            gradient.SetKeys(
               new GradientColorKey[] { new GradientColorKey(Color.grey, 0.0f) },
               new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
           );
        }
        trail.colorGradient = gradient;
    }


    private void OnCollisionEnter(Collision collision)
    {
        // 적과 충돌하면 팅겨 나가기
        if (collision.gameObject.tag == "Enemy")
        {
            Vector3 direction = Vector3.up + transform.position - collision.gameObject.transform.position;
            direction.Normalize();
            direction = (direction * 500);
            gameObject.GetComponent<Rigidbody>().AddForce(direction);
            audioSource.Play();
            //(explosion, transform.position, Quaternion.identity);
        }
        if (collision.gameObject.tag == "GoalKeeper")
        {
            Vector3 direction = -collision.gameObject.transform.forward;
            direction.Normalize();
            direction = (direction * 1000);
            gameObject.GetComponent<Rigidbody>().AddForce(direction);
            audioSource.Play();
        }
        if (collision.gameObject.tag == "Floor")
        {
            isJump = false;
        }

        // 골을 넣으면 씬 전환
        if (collision.gameObject.tag == "Goal")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            GameManager.Instance.nextPanel.SetActive(true);
        }

        // 해골과 충돌하면 3초 후 죽음
        if (collision.gameObject.tag == "Skull")
        {
            currentTime++;
            if (currentTime > dieTime)
            {
                NK_Life.LifeManager.Life--;
                currentTime = 0;
                Destroy(collision.gameObject);
            }
        }
    }
}

