using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    public CharacterController controller;

    [Header("Movement")]
    public float maxSpeed = 5.0f;
    public float gravity = -30.0f;
    public float jumpheight = 3.0f;
    public Vector3 velocity;

    [Header("Ground Detection")]
    public Transform groundCheck;
    public float groundRadius = 0.5f;
    public LayerMask groundMask;
    public bool isGrounded;

    [Header("Audio")]
    public AudioSource mySFX;
    public AudioClip jump;
    public AudioClip hurt;

    [Header("Healthbar")]

    public Slider hpbar;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundMask);

        if (isGrounded && velocity.y < 0.0f)
        {
            velocity.y = - 2.0f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * maxSpeed * Time.deltaTime);

        if(Input.GetButton("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2.0f * gravity);
            mySFX.PlayOneShot(jump);
        }
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
        {
            maxSpeed = 9.0f;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift) && isGrounded)
        {
            maxSpeed = 5.0f;
        }

    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            HealthCheck();
            hpbar.value -= 10;
            mySFX.PlayOneShot(hurt);
        }
    }
    public void HealthCheck()
    {
        hpbar.value -= 10f;
        if (hpbar.value <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
