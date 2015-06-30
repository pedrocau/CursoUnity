//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2014 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Tween the object's alpha. Works with both UI widgets as well as renderers.
/// </summary>

[AddComponentMenu("NGUI/Tween/Tween Alpha")]
public class TweenAlpha : UITweener
{
	[Range(0f, 1f)] public float from = 1f;
	[Range(0f, 1f)] public float to = 1f;

	bool mCached = false;
	CanvasGroup _canvasGroup;
	Image _image;

	Material mMat;
	SpriteRenderer mSr;

	[System.Obsolete("Use 'value' instead")]
	public float alpha { get { return this.value; } set { this.value = value; } }

	void Cache ()
	{
		mCached = true;
		_canvasGroup = GetComponent<CanvasGroup>();
		_image = GetComponent<Image>();
		mSr = GetComponent<SpriteRenderer>();

		if (_canvasGroup == null && mSr == null && _image == null)
		{
			Renderer ren = GetComponent<Renderer>();
			if (ren != null) mMat = ren.material;
			if (mMat == null) 
			{
				_canvasGroup = GetComponentInChildren<CanvasGroup>();
				_image = GetComponentInChildren<Image>();
			}
		}
	}

	/// <summary>
	/// Tween's current value.
	/// </summary>

	public float value
	{
		get
		{
			if (!mCached) Cache();
			if (_canvasGroup != null) return _canvasGroup.alpha;
			else if (_image != null) return _image.color.a;
			if (mSr != null) return mSr.color.a;
			return mMat != null ? mMat.color.a : 1f;
		}
		set
		{
			if (!mCached) Cache();

			if (_canvasGroup != null || _image != null)
			{
				if(_canvasGroup != null) _canvasGroup.alpha = value;
				else if(_image != null) 
				{
					var color = _image.color;
					color.a = value;
					_image.color = color;
				}
			}
			else if (mSr != null)
			{
				Color c = mSr.color;
				c.a = value;
				mSr.color = c;
			}
			else if (mMat != null)
			{
				Color c = mMat.color;
				c.a = value;
				mMat.color = c;
			}
		}
	}

	/// <summary>
	/// Tween the value.
	/// </summary>

	protected override void OnUpdate (float factor, bool isFinished) { value = Mathf.Lerp(from, to, factor); }

	/// <summary>
	/// Start the tweening operation.
	/// </summary>

	static public TweenAlpha Begin (GameObject go, float duration, float alpha)
	{
		TweenAlpha comp = UITweener.Begin<TweenAlpha>(go, duration);
		comp.from = comp.value;
		comp.to = alpha;

		if (duration <= 0f)
		{
			comp.Sample(1f, true);
			comp.enabled = false;
		}
		return comp;
	}

	public override void SetStartToCurrentValue () { from = value; }
	public override void SetEndToCurrentValue () { to = value; }
}
