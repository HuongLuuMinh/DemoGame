using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UseJoinStick : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;

    [SerializeField] Spawn spawn;

    public float speed;

    private bool isEnableJoyStick;
    Vector2 joyStickVal;
    
    // Update is called once per frame
    void Update()
    {
        if (!spawn.isSpawnState())
        {
            if (isEnableJoyStick)
            {
                navMeshAgent.destination = new Vector3(
                    transform.position.x + joyStickVal.x * speed,
                    transform.position.y,
                    transform.position.z + joyStickVal.y * speed);
            }
        }
        
    }
    public void OnUp()
    {
        isEnableJoyStick = false;
        joyStickVal = Vector2.zero;
    }
    public void OnDown()
    {
        isEnableJoyStick = true;
    }
    public void OnSet(Vector2 value)
    {
        if(isEnableJoyStick)
        {
            joyStickVal = value;
        }
    }
    public bool isEnableJoStickState()
    {
        return isEnableJoyStick;
    }
}
