using UnityEngine;
using System.Collections;

public static class AnimationExtensions
{


	public static Animation SetSpeed (this Animation anim, float newSpeed)
	{
		anim [anim.clip.name].speed = newSpeed; 
		return anim;
	}

}

