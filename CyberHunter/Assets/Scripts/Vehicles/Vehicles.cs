using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicles : MonoBehaviour {
	[SerializeField] bool toFlip;

	void FlipVehicle(int scale){
		if(toFlip)
			transform.localScale = new Vector3(scale, 1, 1);
	}
}
