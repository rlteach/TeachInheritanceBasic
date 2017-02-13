using UnityEngine;
using System.Collections;

public class GreenJewel : Jewel {		//Inherits functionallity from Jewel

	// Use this for initialization
	protected override void Start () {
		base.Start ();		//Make sure base method does its initialisation
		mRB.AddForce(Quaternion.Euler(0,0,Random.Range(0,360f)) * Vector2.up,ForceMode2D.Impulse);		//Move in Random direction
	}
	
	protected	override	void	ProcessUpdate(bool vOffscreen) {		//Process off screen
		if (vOffscreen) {
			Kill ();		//I don't Wrap I die
		}
	}

	public	override	void	ClickedOn(Vector2 vPosition) {
		base.ClickedOn (vPosition);
		mRB.gravityScale = 1f;
		Debug.Log ("Green:I fall & spin when clicked");
		mRB.AddTorque (Random.Range (-180f, 180f), ForceMode2D.Impulse);
	}

	protected	override	void	WillDie() {
		GameHelper.DebugMsg (gameObject.name + " I dont wanna die");		
	}
}