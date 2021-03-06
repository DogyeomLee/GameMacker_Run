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

    [Header("text")]
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;        
    public GameObject text4;

    [Header("OnscreenController")]
    public Joystick leftJoystick;
    public GameObject Minimap;
    public GameObject onScreenControls;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        text1.SetActive(false);
        text2.SetActive(false);
        text3.SetActive(false);
        text4.SetActive(false);

        switch (Application.platform)
        {
            case RuntimePlatform.Android:
                onScreenControls.SetActive(true);
                break;
            case RuntimePlatform.WebGLPlayer:
            case RuntimePlatform.WindowsEditor:
                onScreenControls.SetActive(false);
                break;
        }
    
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

        float x1 = leftJoystick.Horizontal;
        float z1 = leftJoystick.Vertical;
        Vector3 move1 = transform.right * x1 + transform.forward * z1;
        controller.Move(move1 * maxSpeed * Time.deltaTime);


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
            mySFX.PlayOneShot(hurt);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "text1")
        {
            text1.SetActive(true);
            text2.SetActive(false);
            text3.SetActive(false);
            text4.SetActive(false);
        }
        if (other.gameObject.tag == "text2")
        {
            text2.SetActive(true);
            text1.SetActive(false);
            text3.SetActive(false);
            text4.SetActive(false);
        }
        if (other.gameObject.tag == "text3")
        {
            text3.SetActive(true);
            text1.SetActive(false);
            text2.SetActive(false);
            text4.SetActive(false);
        }
        if (other.gameObject.tag == "text4")
        {
            text3.SetActive(false);
            text1.SetActive(false);
            text2.SetActive(false);
            text4.SetActive(true);
        }

    }
    public void OnAButton_Pressed()
    {
        if (isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2.0f * gravity);
        }
    }
    public void OnMapButton_Pressed()
    {
        Minimap.SetActive(!Minimap.activeInHierarchy);
    }
    public void SaveButton_Pressed()
    {
       GameSaveManager.Instance().SaveGame(transform);
    }
    public void LoadButton_Pressed()
    {
        GameSaveManager.Instance().LoadGame(transform);
    }

}
