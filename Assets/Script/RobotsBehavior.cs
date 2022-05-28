using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotsBehavior : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    private bool isradar;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindObjectOfType<PlayerBehaviour>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(isradar == true)
        {
            agent.speed = 2;
            agent.SetDestination(player.position);
        }
        else if(isradar == false)
        {
            agent.speed = 0;
            isradar = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isradar = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isradar = false;
        }
    }
}
