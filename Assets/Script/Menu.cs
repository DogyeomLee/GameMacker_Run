using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    public GameObject loadMenuHolder;
    public GameObject optionsMenuHolder;
    public GameObject KeyMapHolder;
    public Toggle invertY;

    public AudioMixer masterMixer;
    public Slider audioSlider1;
    public Slider audioSlider2;
    public Slider audioSlider3;



    public void AudioControl1()
    {
        float sound = audioSlider1.value;
        masterMixer.SetFloat("Master", sound);
    }
    public void AudioControl2()
    {
        float sound = audioSlider2.value;
        masterMixer.SetFloat("Music", sound);
    }
    public void AudioControl3()
    {
        float sound = audioSlider3.value;
        masterMixer.SetFloat("SFX", sound);
    }
    // Start is called before the first frame update
    void Start()
    {
        loadMenuHolder.SetActive(false);
        optionsMenuHolder.SetActive(false);
        KeyMapHolder.SetActive(false);
    }

    // Update is called once per frame
    public void OnstartButton_Click()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void OnquitButton_Click()
    {
        Application.Quit();
    }
    public void OptionMenu()
    {
        loadMenuHolder.SetActive(false);
        optionsMenuHolder.SetActive(true);
    }
    public void BackMenu()
    {
        loadMenuHolder.SetActive(false);
        optionsMenuHolder.SetActive(false);
    }
    public void KeyMenu()
    {
        loadMenuHolder.SetActive(false);
        optionsMenuHolder.SetActive(true);
        KeyMapHolder.SetActive(true);
    }
    public void KeyBackMenu()
    {
        loadMenuHolder.SetActive(false);
        optionsMenuHolder.SetActive(true);
        KeyMapHolder.SetActive(false);
    }
    public void LoadMenu()
    {
        loadMenuHolder.SetActive(true);
        optionsMenuHolder.SetActive(false);
    }
    public void ToggleAudioVolume()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }
}
