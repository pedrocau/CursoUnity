//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2014 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;

/// <summary>
/// Tween the widget's size.
/// </summary>


[AddComponentMenu("NGUI/Tween/Tween Height")]
public class TweenHeight : UITweener
{
	public int from = 100;
	public int to = 100;
	public bool updateTable = false;

	RectTransform mWidget;


	public RectTransform cachedWidget { get { if (mWidget == null) mWidget = GetComponent<RectTransform>(); return mWidget; } }

	[System.Obsolete("Use 'value' instead")]
	public int height { get { return this.value; } set { this.value = value; } }

	/// <summary>
	/// Tween's current value.
	/// </summary>

	public int value { get { return (int)cachedWidget.sizeDelta.y; } set { cachedWidget.sizeDelta = new Vector2(cachedWidget.sizeDelta.x,value); } }

	/// <summary>
	/// Tween the value.
	/// </summary>

	protected override void OnUpdate (float factor, bool isFinished)
	{
		value = Mathf.RoundToInt(from * (1f - factor) + to * factor);


	}

	/// <summary>
	/// Start the tweening operation.
	/// </summary>

	static public TweenHeight Begin (RectTransform widget, float duration, int height)
	{
		TweenHeight comp = UITweener.Begin<TweenHeight>(widget.gameObject, duration);
		comp.from = (int)widget.sizeDelta.y;
		comp.to = height;

		if (duration <= 0f)
		{
			comp.Sample(1f, true);
			comp.enabled = false;
		}
		return comp;
	}

	[ContextMenu("Set 'From' to current value")]
	public override void SetStartToCurrentValue () { from = value; }

	[ContextMenu("Set 'To' to current value")]
	public override void SetEndToCurrentValue () { to = value; }

	[ContextMenu("Assume value of 'From'")]
	void SetCurrentValueToStart () { value = from; }

	[ContextMenu("Assume value of 'To'")]
	void SetCurrentValueToEnd () { value = to; }
}
