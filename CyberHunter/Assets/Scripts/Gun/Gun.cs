using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : GunController {
	
	public void SetPowerUp(int type){
		SetGunType(type);
	}

	public void Shoot(float flip){
		SpawnBullet((int)gun, flip);
	}
}
