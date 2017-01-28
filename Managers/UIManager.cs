using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using GameDataEditor;

public class UIManager : MonoBehaviour
{
	public Canvas mainCanvas_m;
	public Camera invCamera_m;
	public RectTransform InventoryPanel_m;
	public RectTransform IntPanel;
	public Button optionAB;
	public Button optionBB;
	public Text Infobox_m;
	public Text locationUI_m;

	public static Text infoBox;

	public static Canvas mainCanvas;
	public static RectTransform IntPanelA;
	public static Button optionA;

	public static Button optionB;

	public static Text locationUI;

	private static bool mainCanvas_b;
	private static bool InventoryPanel_b;

	private void Awake()
	{
		infoBox = Infobox_m;
		mainCanvas_b = true;
		mainCanvas = mainCanvas_m;
		IntPanelA = IntPanel;
		IntPanelA.gameObject.SetActive(false);
		optionA = optionAB;
		optionB = optionBB;
		locationUI = locationUI_m;
		optionA.gameObject.SetActive(false);
		optionB.gameObject.SetActive(false);
		HideElements();
	}

	public static void HideElements()
	{
		IntPanelA.gameObject.SetActive(false);
		optionA.gameObject.SetActive(false);
		optionB.gameObject.SetActive(false);
	}

	public static void ToggleCanvas()
	{
		mainCanvas_b = !mainCanvas_b;
		mainCanvas.gameObject.SetActive(mainCanvas_b);
	}

	public static void LocationUpdate(string loc)
	{
		locationUI.text = "Currently in" + loc;
	}

	public static void ClearInfoBox()
	{
		infoBox.text = "";
	}

	public void Freezecam()
	{
	}
}