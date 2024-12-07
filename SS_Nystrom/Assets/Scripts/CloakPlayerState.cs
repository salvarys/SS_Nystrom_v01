using UnityEngine;

public class CloakPlayerState : IPlayerState
{
    private Player mPlayer;
    private Renderer playerRenderer; 
    private bool isCloaked;          

    public void Enter(Player player)
    {
        Debug.Log("Cloak On");
        mPlayer = player;

        playerRenderer = player.GetComponent<Renderer>();

        playerRenderer.enabled = true;
        isCloaked = false;

        player.mCurrentState = this; 
    }

    public void Execute(Player player)
    {
        if (Input.GetKeyDown(KeyCode.C)) 
        {
            if (isCloaked)
            {
                playerRenderer.enabled = true;
                isCloaked = false;
                Debug.Log("Cloak Off - Player is now visible.");
                StandingPlayerState standingState = new StandingPlayerState();
                standingState.Enter(player);
            }
            else
            {
                playerRenderer.enabled = false;
                isCloaked = true;
                Debug.Log("Cloak On - Player is now invisible.");
            }

    
        }
    }
}
