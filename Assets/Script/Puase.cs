using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puase : MonoBehaviour
{
    bool IsPause;
    public GameObject pause;
    CameraController mouse;
    // Start is called before the first frame update
    void Start()
    {
        IsPause = false;
        pause.SetActive(false);
        mouse = FindObjectOfType<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            IsPause = true;
            pause.SetActive(true);
            mouse.mouseSenstivity = 0.0f;
            return;
        }
    }
    public void back()
    {
        Time.timeScale = 1;
        IsPause = false;
        pause.SetActive(false);
        mouse.mouseSenstivity = 5.0f;
        return;
        
    }
}
