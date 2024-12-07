using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangPlayerColorState : IPlayerState
{
    private Player mPlayer;
    private Renderer playerRenderer; // Renderer to change colors
    private Color[] colors = { Color.red, Color.blue, Color.green, Color.yellow }; // Array of colors
    private int currentColorIndex = 0; // Tracks the current color

    public void Enter(Player player)
    {
        Debug.Log("Entered Change Player Color State");

        mPlayer = player;

        // Get the Renderer component for the player
        playerRenderer = player.GetComponent<Renderer>();
        if (playerRenderer == null)
        {
            Debug.LogError("Renderer not found on the player object!");
            return;
        }

        // Set the initial color when entering this state
        playerRenderer.material.color = colors[currentColorIndex];

        // Assign the current state to the player
        player.mCurrentState = this;
    }

    public void Execute(Player player)
    {
        if (playerRenderer == null)
        {
            Debug.LogError("Renderer is missing, cannot change colors.");
            return;
        }

        // Change color when "D" is pressed
        if (Input.GetKeyDown(KeyCode.D))
        {
            currentColorIndex = (currentColorIndex + 1) % colors.Length; // Cycle to the next color
            playerRenderer.material.color = colors[currentColorIndex];  // Apply the color
            Debug.Log("Changed color to: " + colors[currentColorIndex]);
        }

        // Return to standing state when "S" is pressed
        if (Input.GetKeyDown(KeyCode.S))
        {
            StandingPlayerState standingState = new StandingPlayerState();
            standingState.Enter(player);
            Debug.Log("Returning to Standing State");
        }
    }
}
