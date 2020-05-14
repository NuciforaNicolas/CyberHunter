using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGun : MonoBehaviour {

	public enum GunType {normal = 1, power1 = 2, power2 = 4, power3 = 10};
	public GunType gun;
	[SerializeField] Text attack;

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
		attack.text = ((int)gun).ToString();
	}
}
