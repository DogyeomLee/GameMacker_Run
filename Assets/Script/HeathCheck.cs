using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HeathCheck : MonoBehaviour
{
    public Transform playerSpawnPoint;
    public GameObject player;
    public Slider bar;
    public TMP_Text Healthbar;
    public int healthValue = 100;

    private int statingHealthValue;
    void Start()
    {
        statingHealthValue = healthValue;
    }

    // Update is called once per frame
    void Update()
    {
        if(healthValue != statingHealthValue)
        {
            statingHealthValue = healthValue;
            bar.value = healthValue;
            OnValueChanged();   
        }
        if(healthValue <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    public void TakeDamage(int damage)
    {
        healthValue -= damage;
        if(healthValue < 0)
        {
            healthValue = 0;
        }
        

    }
    public void OnValueChanged()
    {
        Healthbar.text = bar.value.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Enemy"))
        {
            TakeDamage(20);
            if (healthValue <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
