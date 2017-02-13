using UnityEngine;
using System.Collections;

public class MegaGreenJewel : SuperGreenJewel {		//Inherits functionallity from Jewel

	// Use this for initialization
	protected override void Start () {
		base.Start ();		//Make sure base method does its initialisation
		transform.localScale=Vector2.one*0.5f;
	}

}