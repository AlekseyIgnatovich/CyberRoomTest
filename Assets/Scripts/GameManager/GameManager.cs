using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public GameSettings GameSettings;
	public DataModel DataModel;
	public UIManager UiManager;
	
	private BaseGameState _gameState;

	void Start()
	{
		DataModel = new DataModel();
		UiManager = new UIManager(GameSettings.GuiSettings);
		
		SwitchState(GameState.Menu);
	}

	public void SwitchState(GameState state) //Todo: убрать свитч
	{
		if (_gameState != null)
		{
			_gameState.Exit(); 
		}

		switch (state)
		{
			case GameState.Menu:
				_gameState = new MainMenuState(this);
				break;
			case GameState.Gammeplay:
				_gameState = new GameplayState(this);
				break;
			default:
				Debug.LogError("Unexpected state");
				break;
		}
		
		_gameState.Enter();
	}
	
}
