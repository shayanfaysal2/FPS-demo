using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public Animator anim;
    private NavMeshAgent agent;
    private Transform player;

    public Slider healthbar;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        healthbar.value = healthbar.maxValue;

        anim.SetBool("isMoving", true);
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position);

        if (Vector3.Distance(transform.position, player.position) < 2)
        {
            anim.SetTrigger("attack");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (healthbar.value > 0)
            {
                healthbar.value--;
            }
            
            if (healthbar.value <= 0)
            {
                anim.SetTrigger("die");
                agent.isStopped = true;
                healthbar.gameObject.SetActive(false);
                Destroy(collision.gameObject);
            }
        }
    }
}
