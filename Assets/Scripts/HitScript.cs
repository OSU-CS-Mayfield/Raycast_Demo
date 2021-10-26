using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScript : MonoBehaviour
{
	public GameObject objectToSpawn;

	void Hit(RaycastHit hit)
	{
		Instantiate(objectToSpawn, hit.point,
		  Quaternion.LookRotation(hit.normal));
	}
}
