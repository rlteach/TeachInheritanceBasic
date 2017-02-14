using UnityEngine;
using System.Collections;

public class PurpleJewel : Jewel {
    protected override void Start()
    {
        base.Start();       //Make sure base method does its initialisation
        mRB.isKinematic = true;
    }
    protected override void ProcessUpdate(bool vOffscreen)
    {       //Process off screen
        if (vOffscreen)
        {
            transform.position = GameHelper.WrapOnScreen(transform.position);	//This one wraps the screen
        }
    }
}
