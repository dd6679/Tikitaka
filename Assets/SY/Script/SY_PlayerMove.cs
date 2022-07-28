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
            // -> ó������ ���ϰ� ����.
            return;
        }

        // ����� �Է¿� ����
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(h, 0, v);
        rigid.AddForce(movement * speed);

        // 1. y�ӵ��� �߷��� ��� ���ϰ� �ʹ�.
        yVelocity += gravity * Time.deltaTime;
       // 2. ���� ����ڰ� ������ư�� ������ y�ӵ��� �ٴ� ���� �����ϰ� �ʹ�.
       if (Input.GetButtonDown("Jump") && !isJump)
       {
           isJump = true;
           rigid.velocity = jumpPower * Vector3.up;
       }
       
       if (rigid.velocity.y < 0)
       {
           //rigid.velocity += Vector3.down * Time.deltaTime;
           rigid.velocity += Vector3.up * gravity * Time.deltaTime;
           // * �߷��� �������� �ӵ��� ũ�� ���� �� ��� ( �߷� ������ �ι� �޴� �ٰ� �����ϸ� �� )
       }
       else if (rigid.velocity.y > 0 && !Input.GetButton("Jump"))
       {
           rigid.velocity += Vector3.up * gravity * Time.deltaTime;
           // �����Ͽ� �ö󰡴� ������ y�� ���(velocity)�� �ް��ϰ� ����ֱ� ���ؼ� ���
       }

        // ���࿡ �÷��̾ ������ �ϸ�
        if (isJump)
        {
            // Yellow �� ǥ��
            gradient.SetKeys
            (
                new GradientColorKey[] { new GradientColorKey(Color.yellow, 0.0f) },
                new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
            );
        }
        else
        {
            // �׷��� ������, Grey�� ǥ��
            gradient.SetKeys(
               new GradientColorKey[] { new GradientColorKey(Color.grey, 0.0f) },
               new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
           );
        }
        trail.colorGradient = gradient;
    }


    private void OnCollisionEnter(Collision collision)
    {
        // ���� �浹�ϸ� �ð� ������
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

        // ���� ������ �� ��ȯ
        if (collision.gameObject.tag == "Goal")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            GameManager.Instance.nextPanel.SetActive(true);
        }

        // �ذ�� �浹�ϸ� 3�� �� ����
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

