using UnityEngine;
using System.Collections;

public class MoveGhost : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public Transform target;


	// Update is called once per frame
	void Update () {
		Vector3 A=new Vector3(target.position.x,target.position.y+1,target.position.z);
		transform.position=target.position;
	}
}
