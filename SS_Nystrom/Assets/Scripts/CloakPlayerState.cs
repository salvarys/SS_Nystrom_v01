using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloakPlayerState : IPlayerState
{
    Player mPlayer;
    Rigidbody rbPlayer;

    public void Enter(Player player)
    {
        Debug.Log("Cloak On");
        rbPlayer = player.GetComponent<Rigidbody>();

        player.mCurrentState = this;
    }


    public void Execute(Player player)
    {
        if (Input.GetKey(KeyCode.C))
        {
            StandingPlayerState standingState = new StandingPlayerState();
            standingState.Enter(player);
        }
    }
}
