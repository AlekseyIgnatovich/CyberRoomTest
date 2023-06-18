using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinWindow : UIBaseView
{
	public event Action OnClosed;
	
	[SerializeField] private Button _closeButton;

	void Awake()
	{
		_closeButton.onClick.AddListener(() =>
		{
			OnClosed?.Invoke();
			Close();
		});
	}
}
