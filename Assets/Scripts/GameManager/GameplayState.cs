using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayState : BaseGameState
{
	private GameplayScreen _gameplayScreen;
	private InputController _inputController;
	private BuildingsManager _buildingsManager;
	private Stock _stock;
	
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
		_stock = new Stock(_gameManager.GameSettings);
		
		_gameplayScreen = _gameManager.UiManager.ShowView<GameplayScreen>();
		_gameplayScreen.Init(_gameManager.DataModel, _gameManager.GameSettings, _stock);

		_inputController = GameObject.FindObjectOfType<InputController>();
		_inputController.OnClickedBuilding += OnSelectBuilding;
		
		_buildingsManager = GameObject.FindObjectOfType<BuildingsManager >();
		_buildingsManager.Init(_gameManager.GameSettings, _gameManager.DataModel, _stock);
	}

	private void OnSelectBuilding(Building building)
	{
		var presenter = new ResourceBuildingPresenter(_gameManager.GameSettings.ResourceSettings, _gameManager.DataModel, _gameManager.UiManager, building);

		Debug.LogError("OnSelectBuilding");
	}

	public override void Exit()
	{
		_gameplayScreen.Close();
		GameObject.Destroy(_inputController.gameObject);
		base.Exit();
	}
}
