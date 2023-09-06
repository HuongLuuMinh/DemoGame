using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveCharacter : MonoBehaviour
{
    [SerializeField] NavMeshAgent NavMeshAgent;

    [SerializeField] Spawn spawn;
    
    public float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        if (!spawn.isSpawnState())
        {
            if (x != 0 || y != 0)
            {
                NavMeshAgent.destination = new Vector3(transform.position.x + x * moveSpeed,
                    transform.position.y,
                    transform.position.z + y * moveSpeed);
            }
        } 
    }
    /*public void Move(Vector3 vector)
    {
        Vector3 newPos = new Vector3(transform.position.x + vector.x, transform.position.y, transform.position.z + vector.z);
        NavMeshAgent.destination = newPos;
    }*/
}
