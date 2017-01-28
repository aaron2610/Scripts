using System.Collections.Generic;
using UnityEngine;

public class NameGen : MonoBehaviour
{
	public IList<string> FirstFirstName = new List<string> { "Ruf", "Be", "Da", "Fi", "Aar", "Ban", "Ore", "Mi", "Van", "Sam", "Ko", "Vol", "Pri", "Te" };
	public IList<string> FirstMiddleName = new List<string> { "", "ma", "le", "pe", "a", "as", "e", "gon", "il" };
	public IList<string> FirstLastName = new List<string> { "", "ny", "lee", "on", "rt", "lyr" };
	public IList<string> LastFirstName = new List<string> { "Maggie", "Penny", "Saya", "Princess", "Abby", "Laila", "Sadie", "Olivia", "Starlight", "Talla" };

	public void Awake()
	{
	}

	public string FirstName()
	{
		string firstNameFinal;
		firstNameFinal = FirstFirstName[Random.Range(0, FirstFirstName.Count)] + FirstMiddleName[Random.Range(0, FirstMiddleName.Count)] + FirstLastName[Random.Range(0, FirstLastName.Count)];
		return firstNameFinal;
	}

	public string LastName()
	{

		string lastNameFinal;
		lastNameFinal = LastFirstName[Random.Range(0, LastFirstName.Count)];
		return lastNameFinal;
	}
}

