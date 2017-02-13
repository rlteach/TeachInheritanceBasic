using UnityEngine;
using System.Collections;

public class GameHelper : MonoBehaviour {


	public	static	bool	ShowDebug = true;


	public  static  Vector2 GameSize {		//Central place to get screen bound from
		get {
			return new Vector2(Camera.main.orthographicSize * Camera.main.aspect, Camera.main.orthographicSize);
		}
	}

	public  static  bool OffScreen (Vector3 vPosition) {		//Check if outside bounds
		Vector2 tGameSize = GameSize;		//Cache for speed
		return (vPosition.x < -tGameSize.x		//Check far left
			|| vPosition.x > tGameSize.x		//Check far right
			|| vPosition.y < -tGameSize.y		//Check bottom
			|| vPosition.y > tGameSize.y);		//Check top
	}

	public  static  Vector3 WrapOnScreen(Vector3 vPosition) {
		Vector2 tGameSize = GameSize;		//Cache for speed
		if (vPosition.x < -tGameSize.x) {
			vPosition.x += tGameSize.x * 2.0f;
		} else if (vPosition.x > tGameSize.x) {
			vPosition.x -= tGameSize.x * 2.0f;
		}

		if (vPosition.y < -tGameSize.y) {
			vPosition.y += tGameSize.y * 2.0f;
		} else if (vPosition.y > tGameSize.y) {
			vPosition.y -= tGameSize.y * 2.0f;
		}
		return vPosition;
	}


	public  static  Vector3 OnScreenRandomPosition {
		get {
			Vector2 tSize = GameSize;
			return  new Vector2(Random.Range(-tSize.x, tSize.x), Random.Range(-tSize.y, tSize.y));
		}
	}

	static	public	void	DebugMsg(string vText) {		//Global debug on off toggle safe debug message
		if (ShowDebug) {
			Debug.Log (vText);
		}
	}
}
