using System.Collections;
using UnityEngine;

public class TimeOfDay : MonoBehaviour
{
	public Light sun;
	public static int DSE = 2161;  //Days sense exiting the caves
	public static int dayCount = 1;
	public static int hourOfDay;
	public float hourLength = 5f;
	public bool countUp = true;

	private void Start()
	{
		hourOfDay = 5;
		SunAndFog();
		StartCoroutine(TimeUpdater());
	}

	public IEnumerator TimeUpdater()
	{
		while ( true )
		{
			StartCoroutine(SunAndFog());
			Debug.Log(hourOfDay);

			switch ( countUp )
			{
				case true:
					{
						hourOfDay++;
						if ( hourOfDay >= 10 )
						{
							countUp = false;
							yield return new WaitForSeconds(hourLength * 4f);
						}
						break;
					}
				case false:
					{
						hourOfDay--;
						if ( hourOfDay <= 0 )
						{
							dayCount++;
							DSE++;
							countUp = true;
							yield return new WaitForSeconds(hourLength * 4f);
						}
						break;
					}
			}
			yield return new WaitForSeconds(hourLength);
		}
	}

	public IEnumerator SunAndFog()
	{
		sun.intensity = hourOfDay * 0.3f;
		RenderSettings.fogDensity = 0.1f - (hourOfDay * 0.01f);
		yield return new WaitForEndOfFrame();
	}
}