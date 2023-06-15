using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGameState
{
    protected GameManager _gameManager;
    
    public BaseGameState(GameManager gameManager)
    {
	    _gameManager = gameManager;
    }
    
    public virtual void Enter() { }

    public virtual void Exit(){ }
    
}
