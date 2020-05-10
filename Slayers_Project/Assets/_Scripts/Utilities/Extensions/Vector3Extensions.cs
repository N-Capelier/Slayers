using UnityEngine;
using System.Collections;

public static class Vector3Extensions
{

	public static Vector2 to2 (this Vector3 vector)
	{
		return vector;
	}

	public static Vector3 withX (this Vector3 vector, float x)
	{
		return new Vector3 (x, vector.y, vector.z);
	}

	public static Vector3 withY (this Vector3 vector, float y)
	{
		return new Vector3 (vector.x, y, vector.z);
	}

	public static Vector3 withZ (this Vector3 vector, float z)
	{
		return new Vector3 (vector.x, vector.y, z);
	}



	public static Vector3 plus (this Vector3 vector, Axis3D axe, float value)
	{
		switch (axe)
		{
		case Axis3D.x:
			return new Vector3 (vector.x + value, vector.y, vector.z);
			
		case Axis3D.y:
			return new Vector3 (vector.x, vector.y + value, vector.z);

		case Axis3D.z:
			return new Vector3 (vector.x, vector.y, vector.z + value);

		default:
			return default(Vector3);

		}


	}

	public static Vector3 plus (this Vector3 vector, Vector3 value)
	{
		return new Vector3 (vector.x + value.x, vector.y + value.y, vector.z + value.z);
	}


	public static Vector3 plusX (this Vector3 vector, float plusX)
	{
		return new Vector3 (vector.x + plusX, vector.y, vector.z);
	}

	public static Vector3 plusY (this Vector3 vector, float plusY)
	{
		return new Vector3 (vector.x, vector.y + plusY, vector.z);
	}

	public static Vector3 plusZ (this Vector3 vector, float plusZ)
	{
		return new Vector3 (vector.x, vector.y, vector.z + plusZ);
	}

	public static Vector3 mulX (this Vector3 vector, float timesX)
	{
		return new Vector3 (vector.x * timesX, vector.y, vector.z);
	}

	public static Vector3 mulY (this Vector3 vector, float timesY)
	{
		return new Vector3 (vector.x, vector.y * timesY, vector.z);
	}

	public static Vector3 mulZ (this Vector3 vector, float timesZ)
	{
		return new Vector3 (vector.x, vector.y, vector.z * timesZ);
	}


	public static Vector3 mulComponents (this Vector3 a, Vector3 d)
	{
		return new Vector3 (a.x * d.x, a.y * d.y, a.z * d.z);
	}

	public static Vector3 addComponents (this Vector3 a, float d)
	{
		return new Vector3 (a.x + d, a.y + d, a.z + d);
	}

	public static Vector3 addComponents (this Vector3 a, Vector3 d)
	{
		return new Vector3 (a.x + d.x, a.y + d.y, a.z + d.z);
	}

	public static Vector3 subComponents (this Vector3 a, float d)
	{
		return new Vector3 (a.x - d, a.y - d, a.z - d);
	}


	public static Vector3 subComponents (this Vector3 a, Vector3 d)
	{
		return new Vector3 (a.x - d.x, a.y - d.y, a.z - d.z);
	}


	public static Vector3 divComponents (this Vector3 a, Vector3 d)
	{
		return new Vector3 (a.x / d.x, a.y / d.y, a.z / d.z);
	}




	public static void print (this Vector3 _vector)
	{
		Debug.Log ("(" + _vector.x.ToString ("0.0#######") + ", " + _vector.y.ToString ("0.0#######") + ", " + _vector.z.ToString ("0.0#######") + ")");
	}


	public static Vector3 ToGuiCoordinateSystem (this Vector3 a)
	{
		var copy = a;
		copy.y = Screen.height - copy.y;
		return copy;
	}

	public static Vector3 Mask (this Vector3 a, Vector3 mask)
	{
		return new Vector3 (a.x * mask.x, a.y * mask.y, a.z * mask.z);
	}



	public static Vector3 Inverse (this Vector3 a)
	{
		return new Vector3 (1 / a.x, 1 / a.y, 1 / a.z);
	}


	public static Vector3 Set (this Vector3 vec, Axis3D axe, float new_value, bool debug = false)
	{
		Vector3 tmp = vec;
		switch (axe)
		{
		case Axis3D.x:
			if (debug)
				Debug.Log ("Set with Axe X");			
			tmp.x = new_value;
			break;
		case Axis3D.y:
			if (debug)
				Debug.Log ("Set with Axe Y");	
			tmp.y = new_value;
			break;
		case Axis3D.z:
			if (debug)
				Debug.Log ("Set with Axe Z");	
			tmp.z = new_value;
			break;
		}
		return tmp;
	}




	public static Vector2 xy (this Vector3 aVector)
	{
		return new Vector2 (aVector.x, aVector.y);
	}


	public static Vector2 xz (this Vector3 aVector)
	{
		return new Vector2 (aVector.x, aVector.z);
	}


	public static Vector2 yz (this Vector3 aVector)
	{
		return new Vector2 (aVector.y, aVector.z);
	}


	public static Vector2 yx (this Vector3 aVector)
	{
		return new Vector2 (aVector.y, aVector.x);
	}


	public static Vector2 zx (this Vector3 aVector)
	{
		return new Vector2 (aVector.z, aVector.x);
	}


	public static Vector2 zy (this Vector3 aVector)
	{
		return new Vector2 (aVector.z, aVector.y);
	}


	public static Vector3 Clamp (this Vector3 aVector, Axis3D axe, LimitF limit)
	{
		Vector3 tmp = aVector;
		switch (axe)
		{
		case Axis3D.x:
			tmp.x = Mathf.Clamp (tmp.x, limit.mini, limit.maxi);
			break;
		case Axis3D.y:
			tmp.y = Mathf.Clamp (tmp.y, limit.mini, limit.maxi);
			break;
		case Axis3D.z:
			tmp.z = Mathf.Clamp (tmp.z, limit.mini, limit.maxi);
			break;
		}
		return tmp;
	}

	public static Vector3 Clamp (this Vector3 aVector, Axis3D axe, Limit3D limit)
	{
		
		return new Vector3 (
			Mathf.Clamp (aVector.x, limit.mini.x, limit.maxi.x),
			Mathf.Clamp (aVector.y, limit.mini.y, limit.maxi.y),
			Mathf.Clamp (aVector.x, limit.mini.z, limit.maxi.z)
		);
	}



	/// <summary>
	/// gets the square distance between two vector3 positions. this is much faster that Vector3.distance.
	/// </summary>
	/// <param name="first">first point</param>
	/// <param name="second">second point</param>
	/// <returns>squared distance</returns>
	public static float SqrDistance (this Vector3 first, Vector3 second)
	{
		return (first.x - second.x) * (first.x - second.x) +
		(first.y - second.y) * (first.y - second.y) +
		(first.z - second.z) * (first.z - second.z);
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="first"></param>
	/// <param name="second"></param>
	/// <returns></returns>
	public static Vector3 MidPoint (this Vector3 first, Vector3 second)
	{
		return new Vector3 ((first.x + second.x) * 0.5f, (first.y + second.y) * 0.5f, (first.z + second.z) * 0.5f);
	}

	/// <summary>
	/// get the square distance from a point to a line segment.
	/// </summary>
	/// <param name="point">point to get distance to</param>
	/// <param name="lineP1">line segment start point</param>
	/// <param name="lineP2">line segment end point</param>
	/// <param name="closestPoint">set to either 1, 2, or 4, determining which end the point is closest to (p1, p2, or the middle)</param>
	/// <returns></returns>
	public static float SqrLineDistance (this Vector3 point, Vector3 lineP1, Vector3 lineP2, out int closestPoint)
	{

		Vector3 v = lineP2 - lineP1;
		Vector3 w = point - lineP1;

		float c1 = Vector3.Dot (w, v);

		if (c1 <= 0) //closest point is p1
		{
			closestPoint = 1;
			return SqrDistance (point, lineP1);
		}

		float c2 = Vector3.Dot (v, v);
		if (c2 <= c1) //closest point is p2
		{
			closestPoint = 2;
			return SqrDistance (point, lineP2);
		}


		float b = c1 / c2;

		Vector3 pb = lineP1 + b * v;
		{
			closestPoint = 4;
			return SqrDistance (point, pb);
		}
	}

	/// <summary>
	/// Absolute value of components
	/// </summary>
	/// <param name="v"></param>
	/// <returns></returns>
	public static Vector3 Abs (this Vector3 v)
	{
		return new Vector3 (Mathf.Abs (v.x), Mathf.Abs (v.y), Mathf.Abs (v.z));
	}

	/// <summary>
	/// Vector3.Project, onto a plane
	/// </summary>
	/// <param name="v"></param>
	/// <param name="planeNormal"></param>
	/// <returns></returns>
	public static Vector3 ProjectOntoPlane (this Vector3 v, Vector3 planeNormal)
	{
		return v - Vector3.Project (v, planeNormal);
	}

	/// <summary>
	/// Gets the normal of the triangle formed by the 3 vectors
	/// </summary>
	/// <param name="vec1"></param>
	/// <param name="vec2"></param>
	/// <param name="vec3"></param>
	/// <returns></returns>
	public static Vector3 Vector3Normal (Vector3 vec1, Vector3 vec2, Vector3 vec3)
	{
		return Vector3.Cross ((vec3 - vec1), (vec2 - vec1));
	}

	/// <summary>
	/// Using the magic of 0x5f3759df
	/// </summary>
	/// <param name="vec1"></param>
	/// <returns></returns>
	/*public static Vector3 FastNormalized (this Vector3 vec1)
	{
		var componentMult = MathX.FastInvSqrt (vec1.sqrMagnitude);
		return new Vector3 (vec1.x * componentMult, vec1.y * componentMult, vec1.z * componentMult);
	}*/


	/// <summary>
	/// 
	/// </summary>
	/// <param name="vec"></param>
	/// <returns></returns>
	public static bool IsNaN (this Vector3 vec)
	{
		return float.IsNaN (vec.x * vec.y * vec.z);
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="points"></param>
	/// <returns></returns>
	public static Vector3 Center (this Vector3[] points)
	{
		Vector3 ret = Vector3.zero;
		foreach (var p in points)
		{
			ret += p;
		}
		ret /= points.Length;
		return ret;
	}

	// axisDirection - unit vector in direction of an axis (eg, defines a line that passes through zero)
	// point - the point to find nearest on line for
	public static Vector3 NearestPointOnAxis (this Vector3 axisDirection, Vector3 point, bool isNormalized = false)
	{
		if (!isNormalized)
			axisDirection.Normalize ();
		var d = Vector3.Dot (point, axisDirection);
		return axisDirection * d;
	}

	// lineDirection - unit vector in direction of line
	// pointOnLine - a point on the line (allowing us to define an actual line in space)
	// point - the point to find nearest on line for
	public static Vector3 NearestPointOnLine (
		this Vector3 lineDirection, Vector3 point, Vector3 pointOnLine, bool isNormalized = false)
	{
		if (!isNormalized)
			lineDirection.Normalize ();
		var d = Vector3.Dot (point - pointOnLine, lineDirection);
		return pointOnLine + (lineDirection * d);
	}
}
