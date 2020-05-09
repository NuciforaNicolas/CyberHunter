using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicles : MonoBehaviour {

	void FlipVehicle(int scale){
		transform.localScale = new Vector3(scale, 1, 1);
	}
}
