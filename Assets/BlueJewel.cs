using UnityEngine;
using System.Collections;

public class BlueJewel : Jewel {		//Inherits functionallity from Jewel

	// Use this for initialization
	protected override void Start () {
		base.Start ();		//Make sure base method does its initialisation
		mRB.AddForce(Quaternion.Euler(0,0,Random.Range(0,360f)) * Vector2.up,ForceMode2D.Impulse);		//Move in Random direction
	}
	
	protected	override	void	ProcessUpdate(bool vOffscreen) {		//Process off screen
		if (vOffscreen) {
			transform.position=GameHelper.WrapOnScreen (transform.position);	//This one wraps the screen
		}
	}

	protected	override bool AllowCollisionAction {		//We override this to not die on collision
		get {
			return	false;
		}
	}

	public	override	void	ClickedOn(Vector2 vPosition) {
		base.ClickedOn (vPosition);		//Call base method also
		mRB.velocity = Vector2.zero;
		Debug.Log ("Blue:I stop & die when clicked");
		Invoke ("Kill",3f);
	}
}