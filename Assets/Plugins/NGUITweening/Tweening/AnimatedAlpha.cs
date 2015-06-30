//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2014 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Makes it possible to animate alpha of the widget or a panel.
/// </summary>

[ExecuteInEditMode]
public class AnimatedAlpha : MonoBehaviour
{
	[Range(0f, 1f)]
	public float alpha = 1f;

	CanvasGroup _canvasGroup;
	Image _image;

	void OnEnable ()
	{
		_canvasGroup = GetComponent<CanvasGroup>();
		_image = GetComponent<Image>();

		LateUpdate();
	}

	void LateUpdate ()
	{
		if (_canvasGroup != null) _canvasGroup.alpha = alpha;
		if (_image != null) 
		{
			var color = _image.color;
			color.a = alpha;
			_image.color = color;
		}
	}
}
