using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramanager : MonoBehaviour {
	[SerializeField] float deathZone;
	// Update is called once per frame
	void Update () {
		if(transform.position.y < deathZone){
			transform.GetComponent<Cinemachine.CinemachineBrain>().enabled = false;
			transform.position = new Vector3(transform.position.x, -1f, transform.position.z); //viene posto un limite sull'asse y. Se il giocatore cade fuori dalla mappa, la telecamera non scende oltre
		}
		
	}
}
