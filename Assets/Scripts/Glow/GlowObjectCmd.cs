using UnityEngine;
using System.Collections.Generic;

public class GlowObjectCmd : MonoBehaviour
{
	public Color GlowColor;
	public float LerpFactor = 10;
	
	private bool Enabled { get; set; }

	public Renderer[] Renderers
	{
		get;
		private set;
	}

	public Color CurrentColor
	{
		get { return _currentColor; }
	}

	private Color _currentColor;
	private Color _targetColor;

	void Start()
	{
		Renderers = GetComponentsInChildren<Renderer>();
		GlowController.RegisterObject(this);
	}

	public void Select()
	{
		_targetColor = GlowColor;
		Enabled = true;
	}

	public void Deselect()
	{
		_targetColor = Color.black;
		Enabled = true;
	}

	private void OnDestroy()
	{
		GlowController.UnregisterObject(this);
	}

	/// <summary>
	/// Update color, disable self if we reach our target color.
	/// </summary>
	private void Update()
	{
		if (!Enabled) return;
		
		_currentColor = Color.Lerp(_currentColor, _targetColor, Time.deltaTime * LerpFactor);

		if (_currentColor.Equals(_targetColor))
		{
			Enabled = false;
		}
	}
}
