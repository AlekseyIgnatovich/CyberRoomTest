using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBuildingComponent : MonoBehaviour
{
    protected Data _data;
    protected GameSettings _gameSettings;
    
    public void Init(Data data, GameSettings gameSettings)
    {
        _data = data;
        _gameSettings = gameSettings;
    }
}
