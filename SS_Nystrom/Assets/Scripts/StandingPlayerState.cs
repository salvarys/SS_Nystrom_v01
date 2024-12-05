using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingPlayerState : IPlayerState
{
    public void Enter(Player player)
    {
        Debug.Log("Entering State: Standing");
        player.mCurrentState = this;
    }

    public void Execute(Player player)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // transition to jump
            JumpingPlayerState jumpingState = new JumpingPlayerState();
            jumpingState.Enter(player);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            DuckingPlayerState duckingState = new DuckingPlayerState();
            duckingState.Enter(player);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            FlamePlayerState flameState = new FlamePlayerState();
            flameState.Enter(player);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            CloakPlayerState cloakState = new CloakPlayerState();
            cloakState.Enter(player);
        }
    }
}
