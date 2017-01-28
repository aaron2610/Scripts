using System.Collections;
using UnityEngine;

public class PersonWaterStorage : MonoBehaviour
{
	public float maxWaterAmount = 0f;
	public int bottleCount = 1;
	public int flaskCount = 0;
	public int bigBottleCount = 0;
	public int jugCount;
	public float currentWaterAmount = 0f;
	public WaterStorage.StorageType storageType = WaterStorage.StorageType.bottle;
	public float drinkAmount = .3f;

	public void Start()
	{
		maxWaterAmount = WaterStorage.MaxStorage(storageType);
		if ( storageType  != WaterStorage.StorageType.none)
			currentWaterAmount = Random.Range(2f, maxWaterAmount);

	}
	public void Clamper()
	{
	 currentWaterAmount = Mathf.Clamp(currentWaterAmount, 0, maxWaterAmount);
	}

	public void DrinkWater()
	{
		if (currentWaterAmount <= 3)
		{
			gameObject.GetComponent<CharBio>().currentThirst += currentWaterAmount;
			currentWaterAmount = 0;
		} else
		{
			gameObject.GetComponent<CharBio>().currentThirst += drinkAmount;
			currentWaterAmount -= drinkAmount;
			gameObject.GetComponent<CharBio>().currentEnergy += 5f;
			gameObject.GetComponent<CharBio>().currentHealth += 2f;
		}

		Clamper();
	}
}



public static class WaterStorage
{
	public enum StorageType
	{
		none,
		bottle,
		flask,
		bigBottle,
		jug
	}




	public static float MaxStorage(this StorageType storageType)
	{
		float maxAmount = 0;
		switch (storageType)
		{
			case StorageType.none:
				{
					return 0f;
				}
			case StorageType.bottle:
				{
					return 2f;
				}
			case StorageType.flask:
				{
					return 6f;
				}
			case StorageType.bigBottle:
				{
					return 10f;
				}
			case StorageType.jug:
				{
					return 20f;
				}
		}

		return maxAmount;

	}

}