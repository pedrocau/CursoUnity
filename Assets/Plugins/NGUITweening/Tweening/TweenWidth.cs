//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2014 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;

/// <summary>
/// Tween the widget's size.
/// </summary>

[RequireComponent(typeof(RectTransform))]
[AddComponentMenu("NGUI/Tween/Tween Width")]
public class TweenWidth : UITweener
{
	public int from = 100;
	public int to = 100;
	public bool updateTable = false;

	RectTransform mWidget;


	public RectTransform cachedWidget { get { if (mWidget == null) mWidget = GetComponent<RectTransform>(); return mWidget; } }

	[System.Obsolete("Use 'value' instead")]
	public int width { get { return this.value; } set { this.value = value; } }

	/// <summary>
	/// Tween's current value.
	/// </summary>

	public int value { get { return (int)cachedWidget.sizeDelta.x; } set { cachedWidget.sizeDelta = new Vector2(value,cachedWidget.sizeDelta.y); } }

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

	static public TweenWidth Begin (RectTransform widget, float duration, int width)
	{
		TweenWidth comp = UITweener.Begin<TweenWidth>(widget.gameObject, duration);
		comp.from = (int)widget.sizeDelta.x;
		comp.to = width;

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
