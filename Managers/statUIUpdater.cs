using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class statUIUpdater : MonoBehaviour
{
	public GameObject Player;

	public Image healthImage;
	public Image energyImage;
	public Image thirstImage;
	public Image hungerImage;

	public Text healthUI;
	public Text energyUI;
	public Text thirstUI;
	public Text hungerUI;

	private float maxHealth, currentHealth, maxHunger, currentHunger, maxThirst, currentThirst, maxEnergy, currentEnergy;

	public static Text healthUI_s, energyUI_s, thirstUI_s, hungerUI_s;
	

	void Start()
	{
		healthUI_s = healthUI;
		energyUI_s = energyUI;
		thirstUI_s = thirstUI;
		hungerUI_s = hungerUI;

		currentHealth = Player.GetComponent<CharBio>().currentHealth;
		maxHealth = Player.GetComponent<CharBio>().maxHealth;

		StartCoroutine(HealthUI());
		StartCoroutine(EnergyUI());
		StartCoroutine(HungerUI());
		StartCoroutine(ThirstUI());
		StartCoroutine(TextNormal());
	}
	public IEnumerator TextNormal()
	{
		while ( true )
		{
			healthUI_s.text = "health"; ;
			thirstUI_s.text = "thirst";
			hungerUI_s.text = "hunger";
			energyUI_s.text = "energy";
			yield return new WaitForSeconds(4f);
		}
	}


	public static void HealthText(string healthUpdate)
	{
		healthUI_s.text = healthUpdate;
	}

	public static void EnergyText(string energyUpdate)
	{
		energyUI_s.text = energyUpdate;

	}

	public static void ThirstText(string thirstUpdate)
	{
		thirstUI_s.text = thirstUpdate;

	}

	public static void HungerText(string hungerUpdate)
	{
		hungerUI_s.text = hungerUpdate;

	}

	IEnumerator HealthUI()
	{
		while ( true )
		{
			//currentHealth = Player.GetComponent<CharBio>().currentHealth;
			//maxHealth = Player.GetComponent<CharBio>().maxHealth;
			//currentHealth / maxHealth;  //QQQ Get player HEALTH
			healthImage.fillAmount = currentHealth / maxHealth;  //QQQ Get player HEALTH
			yield return new WaitForSeconds(1f);
		}
	}


	IEnumerator HungerUI()
	{
		while ( true )
		{
			currentHunger = Player.GetComponent<CharBio>().currentHunger;
			maxHunger = Player.GetComponent<CharBio>().maxHunger;
			float hunger_per = currentHunger / maxHunger;
			hungerImage.fillAmount = hunger_per;
			yield return new WaitForSeconds(4f);
		}
	}


	IEnumerator ThirstUI()
	{
		while ( true )
		{
			currentThirst = Player.GetComponent<CharBio>().currentThirst;
			maxThirst = Player.GetComponent<CharBio>().maxThirst;
			float thirst_per = currentThirst / maxThirst;
			thirstImage.fillAmount = thirst_per;
			yield return new WaitForSeconds(4f);
		}
	}


	IEnumerator EnergyUI()
	{
		while ( true )
		{
			currentEnergy = Player.GetComponent<CharBio>().currentEnergy;
			maxEnergy = Player.GetComponent<CharBio>().maxEnergy;
			float energy_per = currentEnergy / maxEnergy;
			energyImage.fillAmount = energy_per;
			yield return new WaitForSeconds(3f);
		}
	}


}