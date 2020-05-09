using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKillabble <T>{
	void TakeDamage(T damage);
	void Death();
}

