using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class EnemyController : MonoBehaviour
{
    //NavMeshAgent nma;
    float newPositionTimer = 0;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the reference to the NavMeshAgent on this gameObject.
        //nma = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // This is an example of using float variables and Time.deltaTime
        // to track how much time has passed (i.e. it is a timer).
        // newPositionTimer = newPositionTimer - Time.deltaTime;
        // if (newPositionTimer < 0)
        // {
        //     newPositionTimer = Random.Range(1, 15);
        //     // Compute a random position and assign it to the NavMeshAgent.
        //     Vector3 randomPosition = RandomNavmeshLocation(Random.Range(5, 10));
        //     nma.SetDestination(randomPosition);
        // }
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(gameObject.transform.forward);
        float rotYAmount = Random.Range(-1f, 0);
        //float rotYAmount = Random.Range(0, 360);
        gameObject.transform.Rotate(0, rotYAmount, 0);
    }

    // This function will find a random position located on the NavMesh. I wouldn't
    // worry about understanding it at this point. But you can use it to compute
    // random positions on a NavMesh.
    // public Vector3 RandomNavmeshLocation(float radius)
    // {
    //     Vector3 randomDirection = Random.insideUnitSphere * radius;
    //     randomDirection += transform.position;
    //     NavMeshHit hit;
    //     Vector3 finalPosition = Vector3.zero;
    //     if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
    //     {
    //         finalPosition = hit.position;
    //     }
    //     return finalPosition;
    // }

    private void OnTriggerEnter(Collider other) {
         if (other.CompareTag("Player"))
        {
            gm.IncrementScore();
            Destroy(gameObject);
            
            Debug.Log("hhh");

        }
    }

}