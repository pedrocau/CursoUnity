//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2014 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;

/// <summary>
/// Makes it possible to animate the widget's width and height using Unity's animations.
/// </summary>

[ExecuteInEditMode]
public class AnimatedWidget : MonoBehaviour
{
	public float width = 1f;
	public float height = 1f;

	RectTransform mWidget;

	void OnEnable ()
	{
		mWidget = GetComponent<RectTransform>();

		LateUpdate();
	}

	void LateUpdate ()
	{
		if (mWidget != null)
		{
			mWidget.sizeDelta = new Vector2(
				Mathf.RoundToInt(width),
				Mathf.RoundToInt(height));
		}
	}
}
