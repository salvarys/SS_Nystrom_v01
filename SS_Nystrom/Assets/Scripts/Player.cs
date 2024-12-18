using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public IPlayerState mCurrentState;

    private void Awake()
    {
        mCurrentState = new StandingPlayerState();  
    }

    private void Update()
    {
        mCurrentState.Execute(this);
    }
}
