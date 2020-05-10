using UnityEngine;
using System;
using System.Collections.Generic;

public static class ArrayExtensions
{
	// This is an extension method. RandomItem() will now exist on all arrays.
	public static T RandomItem<T> (this T[] array)
	{
		return array [UnityEngine.Random.Range (0, array.Length)];
	}

	public static T random<T> (this T[] array)
	{
		return array [Mathf.FloorToInt (UnityEngine.Random.value * array.Length)];
	}

	public static int Count<T> (this T[] array, Func<T, bool> countPredicate)
	{
		var count = 0;
		for (int i = 0; i < array.Length; i++)
		{
			if (countPredicate (array [i]))
				count++;
		}
		return count;
	}

	public static T[] ForEach<T> (this T[] array, Action<T> action)
	{
		for (int i = 0; i < array.Length; i++)
		{
			action (array [i]);
		}
		return array;
	}

	/// <summary>
	/// Return the next index of the array, if index is out of bounds, return 0.
	/// </summary>
	/// <returns>The index.</returns>
	/// <param name="array">Array.</param>
	/// <param name="actualIndex">Actual index.</param>
	/// <typeparam name="T">The 1st type parameter.</typeparam>
	public static int NextIndex<T> (this T[] array, int actualIndex)
	{
		actualIndex++;
		return actualIndex < array.Length ? actualIndex : 0;
	}

	
	
	public static List<T> ToList<T> (this T[] array)
	{
		
		return new List<T> (array);
	}



	public static T[] RemoveRange<T> (this T[] array, int index, int count)
	{
		if (count < 0)
			throw new ArgumentOutOfRangeException ("count", " is out of range");
		if (index < 0 || index > array.Length - 1)
			throw new ArgumentOutOfRangeException ("index", " is out of range");

		if (array.Length - count - index < 0)
			throw new ArgumentException ("index and count do not denote a valid range of elements in the array", "");

		var newArray = new T[array.Length - count];

		for (int i = 0, ni = 0; i < array.Length; i++)
		{
			if (i < index || i >= index + count)
			{
				newArray [ni] = array [i];
				ni++;
			}
		}

		return newArray;
	}
}