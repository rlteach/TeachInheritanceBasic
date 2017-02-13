using UnityEngine;
using System.Collections;
using System.Collections.Generic; //need this to access generics

public class GameManager : Singleton {

	[Header("Link Jewels here")]
	public	GameObject[]	JewelPrefabs;


	List<Jewel>	mJewelList;

	static	GameManager	sGM;

	void Awake () {
		if (CreateSingleton (ref sGM)) {
			mJewelList=new List<Jewel>();
		}	
	}

	static	public	void	AddJewel(int vNumber) {
		if (sGM != null &&  vNumber < sGM.JewelPrefabs.Length && sGM.JewelPrefabs [vNumber]!=null) { 	//Check its valid
			GameObject	tGO=GameObject.Instantiate (sGM.JewelPrefabs [vNumber],GameHelper.OnScreenRandomPosition,Quaternion.identity) as GameObject;
			Jewel	tJewel = tGO.GetComponent<Jewel> ();
			sGM.mJewelList.Add (tJewel);
		} else {
			GameHelper.DebugMsg ("Invalid Jewel");
		}
	}

	static	public	void	DeleteAllJewels() {
		if (sGM != null && sGM.mJewelList != null) {
			while(sGM.mJewelList.Count>0) {
				Jewel	tJewel = sGM.mJewelList [0];		//Get first member
				sGM.mJewelList.Remove(tJewel);
				tJewel.Kill ();
			}
		}
	}

	static	public	void	RemoveJewel(Jewel vJewel) {
		if (sGM != null && sGM.mJewelList != null) {
			sGM.mJewelList.Remove(vJewel);
		}
	}


	// Update is called once per frame
	void Update () {
		ProcessMouse ();
	}

	void	ProcessMouse() {
		if (Input.GetMouseButtonDown (0)) {			//Only run raycast if mouse down has occured since last Update
			Ray tMousePointerRay = Camera.main.ScreenPointToRay (Input.mousePosition);		//Make a ray from the mouse pointer using the main camera
			RaycastHit2D	tMousePointerRayHit = Physics2D.Raycast (tMousePointerRay.origin,tMousePointerRay.direction);	//Cast the ray into the gameworld from the mouse position, pointing along direction (into the screen)
			if (tMousePointerRayHit.collider != null) {											//If collider is null we did not hit anything, otherise it wil be a reference the collider on the GameObject we hit
				GameObject tObjectHit = tMousePointerRayHit.collider.gameObject;				//At this point we know we have hit a collider on a GameObject, so get the game object
				Jewel	tJewel=tObjectHit.GetComponent<Jewel>();
				if (tJewel != null) {
					tJewel.ClickedOn (tMousePointerRay.origin);
				}
			}
		}
	}
}
