using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamePlayerState : IPlayerState
{
    private Player mPlayer;
    private Rigidbody rbPlayer;
    private ParticleSystem particleSystem;
    private bool isPlaying; 

    public void Enter(Player player)
    {
        Debug.Log("Flame On");
        mPlayer = player;
        rbPlayer = player.GetComponent<Rigidbody>();
        particleSystem = rbPlayer.GetComponent<ParticleSystem>();
        particleSystem.Stop(); 
        isPlaying = false;   
        player.mCurrentState = this;
    }

    public void Execute(Player player)
    {
        if (Input.GetKeyDown(KeyCode.F)) 
        {
            if (isPlaying)
            {
                particleSystem.Stop();
                isPlaying = false;
                Debug.Log("Particles Stopped");
           
            }
            else
            {
                particleSystem.Play();
                isPlaying = true;
                Debug.Log("Particles Playing");

            }
            StandingPlayerState standingState = new StandingPlayerState();
            standingState.Enter(player);
        }

    }
}