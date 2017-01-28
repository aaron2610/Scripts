using UnityEngine;
using System.Collections;

public class waterAmount : MonoBehaviour {
	public float maxAmount;
	public enum WaterTankType
	{
		BigTank,
		SmallTank,
		MediumTank,
		Barrel

	}
	public WaterTankType waterTankType;
	public float waterValue;


	// Use this for initialization
	void Start()
	{
		waterValue = Random.Range(100f, 300f);
		switch ( waterTankType )
		{
			case WaterTankType.BigTank:
				{
					maxAmount = 5000f;
					break;
				}
			case WaterTankType.MediumTank:
				{
					maxAmount = 2800f;
					break;
				}
			case WaterTankType.SmallTank:
				{
					maxAmount = 1500f;
					break;
				}
			case WaterTankType.Barrel:
				{
					maxAmount = 300f;
					break;
				}
			default:
				{
					maxAmount = 1000f;
					break;
				}
		}
	}
	
}
