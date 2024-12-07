using UnityEngine;

public class CloakPlayerState : IPlayerState
{
    private Player mPlayer;
    private Renderer playerRenderer; // Used to control visibility
    private bool isCloaked;          // Tracks if the player is currently cloaked

    public void Enter(Player player)
    {
        Debug.Log("Cloak On");
        mPlayer = player;

        // Get the Renderer component for visibility control
        playerRenderer = player.GetComponent<Renderer>();

        // Ensure player starts visible
        playerRenderer.enabled = true;
        isCloaked = false;

        player.mCurrentState = this; // Update player's state
    }

    public void Execute(Player player)
    {
        if (Input.GetKeyDown(KeyCode.C)) // Toggle visibility on key press
        {
            if (isCloaked)
            {
                // Turn visible
                playerRenderer.enabled = true;
                isCloaked = false;
                Debug.Log("Cloak Off - Player is now visible.");
                StandingPlayerState standingState = new StandingPlayerState();
                standingState.Enter(player);
            }
            else
            {
                // Turn invisible
                playerRenderer.enabled = false;
                isCloaked = true;
                Debug.Log("Cloak On - Player is now invisible.");
            }

    
        }
    }
}
