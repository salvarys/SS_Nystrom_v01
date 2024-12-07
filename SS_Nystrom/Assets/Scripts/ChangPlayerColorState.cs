using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangPlayerColorState : IPlayerState
{
    private Player mPlayer;
    private Renderer playerRenderer; 
    private Color[] colors = { Color.red, Color.blue, Color.green, Color.yellow }; 
    private int currentColorIndex = 0; 

    public void Enter(Player player)
    {
        Debug.Log("Entered Change Player Color State");

        mPlayer = player;

        playerRenderer = player.GetComponent<Renderer>();
 
        playerRenderer.material.color = colors[currentColorIndex];


        player.mCurrentState = this;
    }

    public void Execute(Player player)
    {
        if (playerRenderer == null)
        {
            Debug.LogError("Renderer is missing, cannot change colors.");
            return;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            currentColorIndex = (currentColorIndex + 1) % colors.Length; 
            playerRenderer.material.color = colors[currentColorIndex]; 
            Debug.Log("Changed color to: " + colors[currentColorIndex]);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            StandingPlayerState standingState = new StandingPlayerState();
            standingState.Enter(player);
            Debug.Log("Returning to Standing State");
        }
    }
}
