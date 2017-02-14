using UnityEngine;
using System.Collections;

public class SuperGreenJewel : GreenJewel {		//Inherits functionallity from Jewel


	// Use this for initialization
	protected override void Start () {
		base.Start ();		//Make sure base method does its initialisation
		mRB.AddTorque (Random.Range (-180f, 180f), ForceMode2D.Impulse);
	}
	
	public	override	void	ClickedOn(Vector2 vPosition) {
		base.ClickedOn (vPosition);
		mRB.gravityScale = -1f;
	}

	protected	override void CollidedWith(Jewel vJewel) {		//Default collide action
		mRB.angularVelocity /= 2.0f;		//Slow down
		vJewel.mRB.angularVelocity = -mRB.angularVelocity; //Transfer reverse to other one
	}
	protected	override bool AllowCollisionAction {		//We override this to not die on collision
		get {
			return	false;
		}
	}
}