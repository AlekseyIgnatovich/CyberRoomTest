using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayState : BaseGameState
{
	private InputController _inputController;
	private BuildingsManager _buildingsManager;

	private GameplayScreenController _gameplayScreen;
	private ResourceBuildingController _resourceBuilding;
	private CraftBuildingController _craftBuilding;
	private MarketBuildingController _marketBuilding;
	
	public GameplayState(GameManager gameManager) : base(gameManager)
	{
	}

	public override void Enter()
	{
		base.Enter();

		SceneManager.LoadSceneAsync(Constants.GameplaySceneName).completed += OnSceneLoaded;
	}

	private void OnSceneLoaded(AsyncOperation obj)
	{
		_gameplayScreen = new GameplayScreenController(_gameManager);

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
			var presenter = new WinWindowController(_gameManager.UiManager);
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
				_resourceBuilding = new ResourceBuildingController(_gameManager.GameSettings.ResourceSettings,
					_gameManager.UiManager, building.GetComponent<ResourceComponent>());
				break;
			case BuildingType.Craft:
				_craftBuilding = new CraftBuildingController(_gameManager.GameSettings.ResourceSettings,
					_gameManager.UiManager, building.GetComponent<CraftComponent>());
				break;
			case BuildingType.Market:
				_marketBuilding = new MarketBuildingController(_gameManager.GameSettings.ResourceSettings,
					_gameManager.Data, _gameManager.UiManager);
				break;
			default:
				Debug.LogError($"Unsupported building type: {building.BuildingType}");
				break;
		}
	}
}
