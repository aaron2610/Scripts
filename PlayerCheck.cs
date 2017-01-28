using UnityEngine;
using System.Collections;

internal class PlayerCheck : MonoBehaviour
{
	public static bool Check(GameObject obj)
	{
		if ( obj.tag == "Player" || obj.HasTag("Player") )
			return true;
		else
			return false;
	}
}