using UnityEngine;
using System.Collections;




#region Limits
[System.Serializable]
public struct Limit3D
{
	public Vector3 mini;
	public Vector3 maxi;

	public Vector3 GetRandomPosition ()
	{
		return new Vector3 (
			Random.Range (mini.x, maxi.x),
			Random.Range (mini.y, maxi.y),
			Random.Range (mini.z, maxi.z)
		);
	}

}


[System.Serializable]
public struct Limit2D
{
	public Vector2 BottomLeft;
	public Vector2 TopRight;

	public Vector2 GetRandomPosition ()
	{
		return new Vector2 (
			Random.Range (BottomLeft.x, TopRight.x),
			Random.Range (BottomLeft.y, TopRight.y)
		);
	}

}


[System.Serializable]
public struct LimitF
{
	public float mini;
	public float maxi;

	public LimitF (float min, float max)
	{
		mini = min;
		maxi = max;
	}

	public LimitF (Vector2 vectorLimit)
	{
		mini = vectorLimit.x;
		maxi = vectorLimit.y;
	}

	public bool isMaxi (float value)
	{
		return (value >= maxi);
	}

	public Vector2 ToVector2 ()
	{
		return new Vector2 (mini, maxi);
		;
	}

	public bool isMini (float value)
	{
		return (value <= mini);
	}

	public float GetRandomValue ()
	{
		return 
			Random.Range (mini, maxi);

	}

	public bool IsBetweenII (float value)
	{
		return (mini.CompareTo (value) <= 0) && (value.CompareTo (maxi) <= 0);
	}


	public  bool IsBetweenEI (float value)
	{
		return (mini.CompareTo (value) < 0) && (value.CompareTo (maxi) <= 0);
	}


	public  bool IsBetweenIE (float value)
	{
		return (mini.CompareTo (value) <= 0) && (value.CompareTo (maxi) < 0);
	}


	public  bool IsBetweenEE (float value)
	{
		return (mini.CompareTo (value) < 0) && (value.CompareTo (maxi) < 0);
	}

	public float Clamp (float value)
	{
		return Mathf.Clamp (value, mini, maxi);
	}
}

[System.Serializable]
public struct LimitI
{
	public int mini;
	public int maxi;

	public LimitI (int min, int max)
	{
		mini = min;
		maxi = max;
	}

	public LimitI (float min, float max)
	{
		mini = (int)min;
		maxi = (int)max;
	}

	public LimitI (Vector2 vectorLimit)
	{
		mini = (int)vectorLimit.x;
		maxi = (int)vectorLimit.y;
	}



	public Vector2 ToVector2 ()
	{
		return new Vector2 (mini, maxi);
		;
	}

	public bool isMaxi (float value)
	{
		return (value >= maxi);
	}


	public bool isMini (float value)
	{
		return (value <= mini);
	}

	public int GetRandomValueII ()
	{
		return 
			Random.Range (mini, maxi + 1);

	}

	public int GetRandomValue ()
	{
		return 
			Random.Range (mini, maxi);

	}


	public bool IsBetween (ClusingType type, float value)
	{

		switch (type)
		{

			case ClusingType.EE:
				return IsBetweenEE (value);
			case ClusingType.EI:
				return IsBetweenEI (value);
			case ClusingType.IE:
				return IsBetweenIE (value);
			case ClusingType.II:
				return IsBetweenII (value);
		}
		return default(bool);
	}


	public bool IsBetweenII (float value)
	{
		return (mini.CompareTo (value) <= 0) && (value.CompareTo (maxi) <= 0);
	}


	public  bool IsBetweenEI (float value)
	{
		return (mini.CompareTo (value) < 0) && (value.CompareTo (maxi) <= 0);
	}


	public  bool IsBetweenIE (float value)
	{
		return (mini.CompareTo (value) <= 0) && (value.CompareTo (maxi) < 0);
	}


	public  bool IsBetweenEE (float value)
	{
		return (mini.CompareTo (value) < 0) && (value.CompareTo (maxi) < 0);
	}

}


#endregion Limits