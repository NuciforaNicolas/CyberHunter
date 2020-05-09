using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGun : MonoBehaviour {

	public enum GunType {normal = 1, power1 = 2, power2 = 5, power3 = 10};
	public GunType gun;

	protected void SetGunType(int type){
		switch(type){
			case 1: gun = GunType.power1; 
				break;
			case 2: gun = GunType.power2; 
				break;
			case 3: gun = GunType.power3;
				break;
			default: gun = GunType.normal; 
				break;
		}
		
	}
}
