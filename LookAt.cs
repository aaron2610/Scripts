using System;
using System.Linq;
using UnityEngine;
using GameDataEditor;

public class LookAt : MonoBehaviour
{
	public string caption;

	public CaptionType captionType;
	public GDEfactionData factionList;
	public FactionManager.FactionList factionPicked;
	public bool useCustomCaption = true;

	public void Start()
	{
		GDEDataManager.Init("gde_data");

		object vfactionList = factionPicked.ToString();
		factionList = (GDEfactionData)vfactionList;

		if ( useCustomCaption == false )
		{
			switch ( captionType )
			{
				case CaptionType.factionHomeCity:
					if ( factionList.factionType == "cult" || factionList.factionType == "religious" )
					{
						caption = "Holy City of " + factionList.religion.fullName;
						break;
					}
					else if ( factionList.factionType == "neutral" )
					{
						caption = factionList.capital + " Trading Hub";
						break;
					}
					else
					{
						caption = factionList.capital.fullName;
						break;
					}
				case CaptionType.factionLeader:
					caption = factionList.leaderTitle;
					break;

				case CaptionType.factionMotto:
					caption = factionList.fullName + Environment.NewLine + "<i><size=8>" + factionList.motto + "</size></i>";
					break;

				case CaptionType.factionName:
					caption = factionList.fullName;
					break;

				case CaptionType.godName:
					if ( factionList.factionType == "cult" )
					{
						caption = "True Followers of " + factionList.religion.godName;
						break;
					}
					else if ( factionList.factionType == "military" )
					{
						caption = "Swords of " + factionList.religion.godName;
						break;
					}
					else
					{
						caption = "Followers of " + factionList.religion.godName;
						break;
					}

				case CaptionType.locationName:
					{
						caption = factionList.capital.fullName;
						break;
					}
				case CaptionType.religionName:
					if ( factionList.religion.fullName == "atheist" )
						caption = "All beliefs are welcome";
					else
						caption = "Followers of " + factionList.religion.godName + " welcome";
					break;

				default:
					break;
			}
		}
	}

	private void OnMouseEnter()
	{
		UIManager.infoBox.text = caption;
	}

	private void OnMouseExit()
	{
		UIManager.ClearInfoBox();
	}

	private void WaitToClear()
	{
		UIManager.ClearInfoBox();
		UIManager.infoBox.text = string.Empty;
	}

	public enum CaptionType
	{
		factionName,
		factionMotto,
		factionHomeCity,
		factionLeader,
		religionName,
		godName,
		locationName
	}
}