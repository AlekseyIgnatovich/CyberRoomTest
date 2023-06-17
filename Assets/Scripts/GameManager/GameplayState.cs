using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayState : BaseGameState
{
	private GameplayScreen _gameplayScreen;
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

	private void OnSceneLoaded(AsyncOperation obj)  //Todo: не очень
	{
		_gameplayScreen = _gameManager.UiManager.ShowView<GameplayScreen>();
		_gameplayScreen.Init(_gameManager.Data, _gameManager.GameSettings);

		_inputController = GameObject.FindObjectOfType<InputController>();
		_inputController.OnClickedBuilding += OnBuildingSelected;
		
		_buildingsManager = GameObject.FindObjectOfType<BuildingsManager >();
		_buildingsManager.Init(_gameManager.Data, _gameManager.GameSettings);
	}

	private void OnBuildingSelected(Building building)
	{
		if (building.BuildingType == BuildingType.Resources)//Todo: switch
		{
			new ResourceBuildingPresenter(_gameManager.GameSettings.ResourceSettings,
				_gameManager.Data, _gameManager.UiManager, (ResourcesBuilding)building);
		}
		else if (building.BuildingType == BuildingType.Craft)
		{
			new CraftBuildingPresenter(_gameManager.GameSettings.ResourceSettings,
				_gameManager.Data, _gameManager.UiManager, (CraftBuilding)building);
		}
		else if (building.BuildingType == BuildingType.Market)
		{
			new MarketBuildingPresenter(_gameManager.GameSettings.ResourceSettings,
				_gameManager.Data, _gameManager.UiManager);
		}
	}

	public override void Exit()
	{
		_gameplayScreen.Close();
		GameObject.Destroy(_inputController.gameObject);
		base.Exit();
	}
}
