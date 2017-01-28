using UnityEngine;
using System.Collections;

public class WeaponInfo : MonoBehaviour
{
	public bool inHands = false;
	public string weaponName;
	public bool isAttacking;
	public bool alreadyHit;
	public GameObject targetHit;
	public GameObject thisRootObj;

	public enum WeaponType
	{
		blunt,
		axe,
		spear,
		sword,
		dagger,
		shield,
		twoHanded
	}

	public enum WeaponSpeed
	{
		slow,
		normal,
		fast,
		doubleHit
	}

	public enum WeaponMaterial
	{
		wood,
		steel,
		iron
	}

	public WeaponMaterial weaponMaterial;
	public WeaponType weaponType;
	public WeaponSpeed weaponSpeed;

	public float weaponQuality;
	public float weaponLength;
	public float weaponMass;

	private float qualFactor;
	private float massFactor;
	private float finalDamage;

	private void Start()
	{
		if ( gameObject.transform.root.gameObject.GetComponent<CharBio>() == true )
		{
			inHands = true;
			WeaponEquiped();
		}
	}

	public void StatInfo()
	{
	}

	public void WeaponEquiped()
	{
		thisRootObj = gameObject.transform.root.gameObject;
		//if ( thisRootObj.GetComponent<CharBio>() )
		//{
		//	thisRootObj.GetComponent<CharBio>().hasWeaponInHand = true;
		//	thisRootObj.GetComponent<CharBio>().weaponDamage = WeaponDamage();
		//	thisRootObj.GetComponent<CharBio>().weaponInHand = gameObject;
		//	thisRootObj.GetComponent<CharBio>().weaponLength = weaponLength;
		//	thisRootObj.GetComponent<CharBio>().weaponMass = weaponMass;
		//}
	}

	public void UnEquipWeapon()
	{
		//thisRootObj.GetComponent<CharBio>().hasWeaponInHand = false;
		//thisRootObj.GetComponent<CharBio>().weaponDamage = 0;
		//thisRootObj.GetComponent<CharBio>().weaponInHand = null;
		//thisRootObj.GetComponent<CharBio>().weaponLength = 0;
		//thisRootObj.GetComponent<CharBio>().weaponMass = 0;
		thisRootObj = null;
	}

	public float BleedDamage()
	{
		float bleedDmg = weaponQuality * 0.02f;
		return bleedDmg;
	}

	public float WeaponDamage()
	{
		float materialFactor = 2f;
		switch ( weaponMaterial )
		{
			case WeaponMaterial.wood:
				{
					materialFactor = 3f;
					break;
				}
			case WeaponMaterial.steel:
				{
					materialFactor = 9f;
					break;
				}
			case WeaponMaterial.iron:
				{
					materialFactor = 7f;
					break;
				}
			default:
				{
					materialFactor = 2f;
					break;
				}
		}
		qualFactor = weaponQuality * 0.1f + 2f;
		massFactor = weaponMass * 1.5f + 1f;

		finalDamage = materialFactor + qualFactor + massFactor;
		return finalDamage;
	}

	public void OnTriggerEnter(Collider other)
	{
		if ( isAttacking == true && alreadyHit == false )
		{
			Debug.Log("You swing at someone on enter ");
			targetHit = other.transform.root.gameObject;
			if ( targetHit.GetComponent<CharBio>() )
			{
				float hitDmg = WeaponDamage();
				alreadyHit = true;
				Debug.Log("alreadyHit set to true");
				thisRootObj.GetComponent<CharBio>().FromWeaponHit(targetHit, WeaponDamage());
				Debug.Log("Sent weapon Info from weapon to CharBio");
				isAttacking = false;
				Debug.Log("isAttacking set to false");
			}
		}
	}

	public void OnTriggerStay(Collider other)
	{
		if ( isAttacking == true && alreadyHit == false )
		{
			Debug.Log("You swing at someone on triggerStay ");
			targetHit = other.transform.root.gameObject;
			if ( targetHit.GetComponent<CharBio>() )
			{
				float hitDmg = WeaponDamage();
				alreadyHit = true;
				Debug.Log("alreadyHit set to true");
				thisRootObj.GetComponent<CharBio>().FromWeaponHit(targetHit, WeaponDamage());
				Debug.Log("Sent weapon Info from weapon to CharBio");
				isAttacking = false;
				Debug.Log("isAttacking set to false");
			}
		}
	}
}