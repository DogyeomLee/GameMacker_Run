using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip gun;
    public AudioSource mySFX;
    public GameObject Bullet;
    public Transform FirePos;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {

            Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation);

            Bullet.transform.position = FirePos.transform.position;

            mySFX.PlayOneShot(gun);
        }
    }
    public void fire()
    {

        Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation);

        Bullet.transform.position = FirePos.transform.position;

        mySFX.PlayOneShot(gun);
    }
}
