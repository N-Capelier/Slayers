using UnityEngine;
using System.Collections.Generic;

public static class TextureExtensions
{
	public struct Point
	{
		public short x;
		public short y;

		public Point (short aX, short aY)
		{
			x = aX;
			y = aY;
		}

		public Point (int aX, int aY) : this ((short)aX, (short)aY)
		{
		}
	}



	/// <summary>
	/// sets a 1 pixel border of the texture on all mipmap levels to the clear color
	/// </summary>
	/// <param name="texture"></param>
	/// <param name="clearColor"> </param>
	/// <param name="makeNoLongerReadable"> </param>
	public static Texture2D ClearMipMapBorders (this Texture2D texture, Color clearColor, bool makeNoLongerReadable = false)
	{
		var mipCount = texture.mipmapCount;


		// In general case, mip level size is mipWidth=max(1,width>>miplevel) and similarly for height. 


		var width = texture.width;
		var height = texture.height;
		// tint each mip level
		for (var mip = 1; mip < mipCount; ++mip)
		{
			var mipWidth = Mathf.Max (1, width >> mip);
			var mipHeight = Mathf.Max (1, height >> mip);
			if (mipWidth <= 2)
				continue; //don't change mip levels below 2x2
			var xCols = new Color[mipWidth];
			var yCols = new Color[mipHeight];
			if (clearColor != default(Color)) //speedup.
			{
				for (var x = 0; x < xCols.Length; ++x)
				{
					xCols [x] = clearColor;
				}
				for (var y = 0; y < yCols.Length; ++y)
				{
					yCols [y] = clearColor;
				}
			}
			texture.SetPixels (0, 0, mipWidth, 1, xCols, mip); //set the top edge colors
			texture.SetPixels (0, 0, 1, mipHeight, yCols, mip); //set the left edge colors
			texture.SetPixels (mipWidth - 1, 0, 1, mipWidth, xCols, mip); //set the bottom edge colors
			texture.SetPixels (0, mipWidth - 1, mipHeight, 1, yCols, mip); //set the right edge colors
		}

		// actually apply all SetPixels, don't recalculate mip levels
		texture.Apply (false, makeNoLongerReadable);
		return texture;
	}

	/// <summary>
	/// sets a 1 pixel border of the texture on all mipmap levels to clear white
	/// </summary>
	/// <param name="texture"></param>
	/// <param name="makeNoLongerReadable"></param>
	public static Texture2D ClearMipMapBorders (this Texture2D texture, bool makeNoLongerReadable = false)
	{
		var clear = new Color (1, 1, 1, 0);
		ClearMipMapBorders (texture, clear, makeNoLongerReadable);
		return texture;
	}





	
	public static Texture2D FloodFillArea (this Texture2D aTex, int aX, int aY, Color aFillColor)
	{
		int w = aTex.width;
		int h = aTex.height;
		Color[] colors = aTex.GetPixels ();
		Color refCol = colors [aX + aY * w];
		Queue<Point> nodes = new Queue<Point> ();
		nodes.Enqueue (new Point (aX, aY));
		while (nodes.Count > 0)
		{
			Point current = nodes.Dequeue ();
			for (int i = current.x; i < w; i++)
			{
				Color C = colors [i + current.y * w];
				if (C != refCol || C == aFillColor)
					break;
				colors [i + current.y * w] = aFillColor;
				if (current.y + 1 < h)
				{
					C = colors [i + current.y * w + w];
					if (C == refCol && C != aFillColor)
						nodes.Enqueue (new Point (i, current.y + 1));
				}
				if (current.y - 1 >= 0)
				{
					C = colors [i + current.y * w - w];
					if (C == refCol && C != aFillColor)
						nodes.Enqueue (new Point (i, current.y - 1));
				}
			}
			for (int i = current.x - 1; i >= 0; i--)
			{
				Color C = colors [i + current.y * w];
				if (C != refCol || C == aFillColor)
					break;
				colors [i + current.y * w] = aFillColor;
				if (current.y + 1 < h)
				{
					C = colors [i + current.y * w + w];
					if (C == refCol && C != aFillColor)
						nodes.Enqueue (new Point (i, current.y + 1));
				}
				if (current.y - 1 >= 0)
				{
					C = colors [i + current.y * w - w];
					if (C == refCol && C != aFillColor)
						nodes.Enqueue (new Point (i, current.y - 1));
				}
			}
		}
		aTex.SetPixels (colors);
		return aTex;
	}

	public static Texture2D FloodFillBorder (this Texture2D aTex, int aX, int aY, Color aFillColor, Color aBorderColor)
	{
		int w = aTex.width;
		int h = aTex.height;
		Color[] colors = aTex.GetPixels ();
		byte[] checkedPixels = new byte[colors.Length];
		Color refCol = aBorderColor;
		Queue<Point> nodes = new Queue<Point> ();
		nodes.Enqueue (new Point (aX, aY));
		while (nodes.Count > 0)
		{
			Point current = nodes.Dequeue ();
			
			for (int i = current.x; i < w; i++)
			{
				if (checkedPixels [i + current.y * w] > 0 || colors [i + current.y * w] == refCol)
					break;
				colors [i + current.y * w] = aFillColor;
				checkedPixels [i + current.y * w] = 1;
				if (current.y + 1 < h)
				{
					if (checkedPixels [i + current.y * w + w] == 0 && colors [i + current.y * w + w] != refCol)
						nodes.Enqueue (new Point (i, current.y + 1));
				}
				if (current.y - 1 >= 0)
				{
					if (checkedPixels [i + current.y * w - w] == 0 && colors [i + current.y * w - w] != refCol)
						nodes.Enqueue (new Point (i, current.y - 1));
				}
			}
			for (int i = current.x - 1; i >= 0; i--)
			{
				if (checkedPixels [i + current.y * w] > 0 || colors [i + current.y * w] == refCol)
					break;
				colors [i + current.y * w] = aFillColor;
				checkedPixels [i + current.y * w] = 1;
				if (current.y + 1 < h)
				{
					if (checkedPixels [i + current.y * w + w] == 0 && colors [i + current.y * w + w] != refCol)
						nodes.Enqueue (new Point (i, current.y + 1));
				}
				if (current.y - 1 >= 0)
				{
					if (checkedPixels [i + current.y * w - w] == 0 && colors [i + current.y * w - w] != refCol)
						nodes.Enqueue (new Point (i, current.y - 1));
				}
			}
		}
		aTex.SetPixels (colors);
		return aTex;
	}
}



/*
 * 
 * 
 * Description

	Two extension methods for Texture2D which allows you to perform a floodfill operation on the texture.
	FloodFillArea will fill the area around the reference point as long as the color stays the same. The reference coler is taken from the start-point-pixel.
	FloodFillBorder will fill the area around the reference point until it reaches the given border color.
	Both functions only perform a 4-direction method (north,east,south,west). This equals the behaviour of usual filling methods like in MS Paint.


	Usage

	Place this script somewhere in your project or in "Assets/Standard Assets/" if you want to use the functions from a foreign language (not C#).
	To use it you can simply call the desired function like this from any language:
	
	    texture.FloodFillArea(10,10,Color.red);
	    // When you're done call Apply to commit your changes.
	    texture.Apply();
	    
	where "texture" is a Texture2D variable with a texture that is "writable".
 *
 *
 *
 */