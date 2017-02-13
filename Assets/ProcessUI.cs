using UnityEngine;
using System.Collections;

public class ProcessUI : MonoBehaviour {

	public	void	AddJewelButton(int vNumber) {		//Call into static code , not possible from IDE
		GameManager.AddJewel(vNumber);
	}

	public	void	ClearAll() {
		GameManager.DeleteAllJewels ();
	}
}
