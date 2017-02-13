using UnityEngine;
using System.Collections;

public abstract	class Jewel : MonoBehaviour {

	public	static	readonly	string	JewelTag="Jewel";

	[HideInInspector]
	public	SpriteRenderer	mSR;			//Allows derived classes to access this
	public	Rigidbody2D		mRB;			//Allows derived classes to access this

	// Use this for initialization
	protected virtual	void Start () {			//Allows this to be overidden
		mSR = GetComponent<SpriteRenderer> ();	
		mRB = GetComponent<Rigidbody2D> ();
	}
		
	
	void Update () {							//Grab Update method and add offscreen flag
		ProcessUpdate (GameHelper.OffScreen (transform.position));
	}

	protected	virtual	void	ProcessUpdate(bool vOffscreen) {		//Default method to handle this
		Debug.Log (name + ":is offscreen");
	}

	public	virtual	void	ClickedOn(Vector2 vPosition) {		//Default click action
		Debug.Log (name + ":was clicked @"+vPosition.ToString());
	}

	public	virtual	void	Kill() {		//Kill the Game Object, allows for tidy up
		Destroy (gameObject);
	}

	void OnCollisionEnter2D(Collision2D vOtherCol) {		//Wrap collision method
		if (vOtherCol.gameObject.tag == JewelTag) {		//Is it a Jewel we collided with?
			CollidedWith(vOtherCol.gameObject.GetComponent<Jewel>());			//Pass Jewel we collided with along
		}
	}

	protected	virtual void CollidedWith(Jewel vJewel) {		//Default collide action
		
		Debug.Log (MyTypeName + " collided with "+vJewel.MyTypeName);
		if (AllowCollisionAction) {		//Are we taking default action?
			Kill ();	//Default action		//Respect flag, and process
		}
	}

	protected	virtual bool AllowCollisionAction {		//Default is to allow Collision action
		get	{
			return	true;			//If this is tru default collision will be processed
		}
	}

	public	string	MyTypeName {
		get {
			return	GetType ().Name;		//Helper to get the type name
		}
	}

	void	OnDestroy() {
		GameManager.RemoveJewel (this);
		WillDie ();
	}

	protected	virtual	void	WillDie() {
		GameHelper.DebugMsg (gameObject.name + " being destroyed");		
	}

}
