using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour
{
	public float inventorySize;
	public float maxInventorySize;
	public float maxWaterHold;
	public float currentWaterHold;
	public bool hasBelt; //adds 2 slots

	public enum BackpackType
	{
		none,
		satchel,
		smallBackpack,
		backpack,
		largeBackpack
	}

	public enum CanteenType
	{
		none,
		canteen,
		bigCanteen
	}
}