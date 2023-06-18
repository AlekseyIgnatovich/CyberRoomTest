using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayState : BaseGameState
{
	private GameplayScreen _gameplayScreen; //Todo: to presenter 
	private InputController _inputController;
	private BuildingsManager _buildingsManager;

	public GameplayState(GameManager gameManager) : base(gameManager)
	{
	}

	public override void Enter()
	{
		base.Enter();

		SceneManager.LoadSceneAsync(Constants.GameplaySceneName).completed += OnSceneLoaded;
	}

	private void OnSceneLoaded(AsyncOperation obj) //Todo: не очень
	{
		_gameplayScreen = _gameManager.UiManager.ShowView<GameplayScreen>();
		_gameplayScreen.Init(_gameManager.Data, _gameManager.GameSettings);

		_inputController = GameObject.FindObjectOfType<InputController>();
		_inputController.OnClickedBuilding += OnBuildingSelected;

		_buildingsManager = GameObject.FindObjectOfType<BuildingsManager>();
		_buildingsManager.Init(_gameManager.Data, _gameManager.GameSettings);

		_gameManager.Data.OnMoneyChanged += OnMoneyChanged;
	}

	private void OnMoneyChanged(int money)
	{
		if (money >= _gameManager.GameSettings.WinConditions.Money)
		{
			var presenter = new WinWindowPresenter(_gameManager.UiManager);
			presenter.OnClose += ExitToMenu;
		}
	}

	private void ExitToMenu()
	{
		_gameManager.Data.Clear();
		_gameManager.SwitchState(GameState.Menu);
	}

	private void OnBuildingSelected(Building building)
	{
		switch (building.BuildingType)
		{
			case BuildingType.Resources:
				new ResourceBuildingPresenter(_gameManager.GameSettings.ResourceSettings, _gameManager.UiManager, (ResourcesBuilding)building);
				break;
			case BuildingType.Craft:
				new CraftBuildingPresenter(_gameManager.GameSettings.ResourceSettings, _gameManager.UiManager, (CraftBuilding)building);
				break;
			case BuildingType.Market:
				new MarketBuildingPresenter(_gameManager.GameSettings.ResourceSettings, _gameManager.Data, _gameManager.UiManager);
				break;
			default:
				Debug.LogError($"Unsupported building type: {building.BuildingType}");
				break;
		}
	}
}
