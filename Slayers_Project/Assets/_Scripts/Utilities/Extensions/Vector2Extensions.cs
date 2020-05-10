using UnityEngine;
using System.Collections;

public static class Vector2Extensions
{

	public static Vector2 withX (this Vector2 vector, float x)
	{
		return new Vector2 (x, vector.y);
	}

	public static Vector2 withY (this Vector2 vector, float y)
	{
		return new Vector2 (vector.x, y);
	}

	public static Vector2 plusX (this Vector2 vector, float plusX)
	{
		return new Vector2 (vector.x + plusX, vector.y);
	}

	public static Vector2 plusY (this Vector2 vector, float plusY)
	{
		return new Vector2 (vector.x, vector.y + plusY);
	}

	public static Vector2 timesX (this Vector2 vector, float timesX)
	{
		return new Vector2 (vector.x * timesX, vector.y);
	}

	public static Vector2 timesY (this Vector2 vector, float timesY)
	{
		return new Vector2 (vector.x, vector.y * timesY);
	}

	public static Vector2 Rotate (this Vector2 vector, float degrees)
	{
		float sin = Mathf.Sin (degrees * Mathf.Deg2Rad);
		float cos = Mathf.Cos (degrees * Mathf.Deg2Rad);
		
		float tx = vector.x;
		float ty = vector.y;
		vector.x = (cos * tx) - (sin * ty);
		vector.y = (sin * tx) + (cos * ty);
		return vector;
	}




	public static Vector2 mulComponents (this Vector2 a, Vector2 d)
	{
		return new Vector2 (a.x * d.x, a.y * d.y);
	}


	public static Vector2 addComponents (this Vector2 a, Vector2 d)
	{
		return new Vector2 (a.x + d.x, a.y + d.y);
	}


	public static Vector2 subComponents (this Vector2 a, Vector2 d)
	{
		return new Vector2 (a.x - d.x, a.y - d.y);
	}


	public static Vector2 divComponents (this Vector2 a, Vector2 d)
	{
		return new Vector2 (a.x / d.x, a.y / d.y);
	}




	public static LimitF ToLimitF (this Vector2 aVector)
	{
		return new LimitF (aVector);
	}

	public static Vector3 ToVector3 (this Vector2 aVector, float zValue = 0.0f)
	{
		return new Vector3 (aVector.x, aVector.y, zValue);
	}




	public static Vector2 NearestPointStrict (Vector2 lineStart, Vector2 lineEnd, Vector2 point)
	{
		var fullDirection = lineEnd - lineStart;
		var lineDirection = fullDirection.normalized;
		var closestPoint = Vector2.Dot ((point - lineStart), lineDirection) / Vector2.Dot (lineDirection, lineDirection);
		return lineStart + (Mathf.Clamp (closestPoint, 0, fullDirection.magnitude) * lineDirection);
	}

	/// <summary>
	/// Direct speedup of <seealso cref="Vector2.Lerp"/>
	/// </summary>
	/// <param name="v1"></param>
	/// <param name="v2"></param>
	/// <param name="value"></param>
	/// <returns></returns>
	/*public static Vector2 Lerp(Vector2 v1, Vector2 v2, float value)
	{
		if (value > 1.0f)
			return v2;
		if (value < 0.0f)
			return v1;
		return new Vector2(v1.x + (v2.x - v1.x) * value,
			v1.y + (v2.y - v1.y) * value);
	}*/
}
