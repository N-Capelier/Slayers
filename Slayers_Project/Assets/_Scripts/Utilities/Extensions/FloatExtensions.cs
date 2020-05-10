using UnityEngine;
using System.Collections;

public static class FloatExtensions
{
	public static float Remap (this float value, float from1, float to1, float from2, float to2)
	{
		return Mathf.Clamp ((value - from1) / (to1 - from1) * (to2 - from2) + from2, Mathf.Min (from2, to2), Mathf.Max (from2, to2));
	}

	public static float RemapPercent (this float value, float from1, float to1)
	{
		return  Mathf.Clamp ((value - from1) / (to1 - from1) * 100, 0, 100);
	}

	public static float rotationNormalizedDeg (this float rotation)
	{
		rotation = rotation % 360f;
		if (rotation < 0)
			rotation += 360f;
		return rotation;
	}

	public static float rotationNormalizedRad (this float rotation)
	{
		rotation = rotation % Mathf.PI;
		if (rotation < 0)
			rotation += Mathf.PI;
		return rotation;
	}

}
