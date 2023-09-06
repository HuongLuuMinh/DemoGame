using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class NetworkPlayer : NetworkBehaviour
{
    [SerializeField] private NetworkCharacterControllerPrototype MoveCharacter;

    public override void FixedUpdateNetwork()
    {
        if (GetInput(out NetworkInputData data))
        {
            data.direction.Normalize();
            MoveCharacter.Move(5 * data.direction * Runner.DeltaTime);
        }
        else
        {
            MoveCharacter.StopMove();
        }
    }
}
