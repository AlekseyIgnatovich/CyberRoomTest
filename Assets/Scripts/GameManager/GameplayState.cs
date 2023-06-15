using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayState : BaseGameState
{
	private GameplayScreen _gameplayScreen;
	private InputController _inputController;
	
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
		_gameplayScreen.Init(_gameManager.DataModel);

		var inputControllerObject = new GameObject("InputController");
		_inputController = inputControllerObject.AddComponent<InputController>();
		_inputController.OnClickedBuilding += OnSelectBuilding;
	}

	private void OnSelectBuilding(Building building)
	{
		Debug.LogError("OnSelectBuilding");
	}

	public override void Exit()
	{
		_gameplayScreen.Close();
		GameObject.Destroy(_inputController.gameObject);
		base.Exit();
	}
}
