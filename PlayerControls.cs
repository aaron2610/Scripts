using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControls : MonoBehaviour
{
	private Animator animator;
	private GameObject cam;
	private bool inAction;
	private Camera mainCamera;
	private bool showInv;
	private bool showUI;
	private Vector3 zoomCamLoc;
	private Quaternion zoomCamRotation;
	public int ViewPoint = 0;
	public GameObject weapon;
	public GameObject weaponHit;
	private float moveTime = 1.5f;

	private void CameraMove(float posx, float posy, float posz)
	{
		zoomCamLoc.x = posx;
		zoomCamLoc.y = posy;
		zoomCamLoc.z = posz;
		cam.transform.localPosition = zoomCamLoc;
	}

	private void Start()
	{
		cam = Camera.main.gameObject;
		zoomCamRotation = Camera.main.transform.localRotation;
		animator = gameObject.GetComponent<Animator>();

		if ( GetComponent<Rigidbody>() )
			GetComponent<Rigidbody>().freezeRotation = true;
		//CameraMove(0, 12f, -5.48f);
	}

	public void ActionCounter()
	{
		Debug.Log("Done swinging");
		inAction = false;
	}

	public void Update()
	{
		if ( Input.GetKeyUp(KeyCode.V) )
		{
			switch ( ViewPoint )
			{
				case 0:   //Main View
					{
						CameraMove(0, 2f, -2.48f);
						ViewPoint++;
						cam.transform.Rotate(4f, 0f, 0f);
						break;
					}

				case 1:  //Over the shoulder
					{
						CameraMove(0, 1.5f, -1.2f);
						ViewPoint++;
						cam.transform.Rotate(4f, 0f, 0f);
						break;
					}

				case 2: //In front and turned
					{
						CameraMove(0, 1.5f, 4f);
						ViewPoint = 0;
						cam.transform.Rotate(0f, 180f, 0f);
						break;
					}
			}
		}

		if ( CrossPlatformInputManager.GetButtonDown("Fire1") )
		{
			if ( inAction == true )
			{
				Debug.Log("Already Attacking");
			}
			else
			{
				inAction = true;
				gameObject.GetComponent<CharBio>().MeleeAttack();
				Invoke("ActionCounter", 1.5f);
			}
		}

		if ( Input.GetKeyDown(KeyCode.KeypadMinus) )
		{
			UIManager.ToggleCanvas();
		}

		if ( CrossPlatformInputManager.GetButtonDown("Fire2") )
		{
			Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit interactionInfo;
			if ( Physics.Raycast(interactionRay, out interactionInfo, 5) )
			{
				GameObject interactObj = interactionInfo.collider.gameObject;
				if ( interactObj.HasTag("interact") || interactObj.tag == "interact" || interactObj.layer == 5 )
				{
					Debug.Log("Interacting");
					interactObj.SendMessage("SetupButtonUI", SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}
}