using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puase : MonoBehaviour
{
    public GameObject pause;
    CameraController mouse;
    // Start is called before the first frame update
    void Start()
    {
        pause.SetActive(false);
        mouse = FindObjectOfType<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pause.SetActive(true);
            mouse.mouseSenstivity = 0.0f;
            return;
        }    
    }
    public void Pausepress()
    {
            Time.timeScale = 0;
            pause.SetActive(true);
            mouse.mouseSenstivity = 0.0f;
    }
    public void back()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
        mouse.mouseSenstivity = 5.0f;
        return;
        
    }
}
