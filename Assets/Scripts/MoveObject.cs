using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {

	public GameObject objectToMove;
	public GameObject targetpos;
	
	public void Move() {
		objectToMove.transform.position = targetpos.transform.position;
	}
}
