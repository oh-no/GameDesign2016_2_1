using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	[SerializeField]Transform target;
	[SerializeField]float spinSpeed = 1.0f;

	private const float DISTANCE = 0.01f;	//カメラとターゲットの距離

	Vector3 nowPos;
	Vector3 pos = Vector3.zero;
	Vector2 mouse = Vector2.zero;
	Vector3 oldPos = Vector3.zero;
	bool isCol = false;
	float oldMouseX;
	float oldMouseY;
	// Use this for initialization
	void Start () {
		// Canera get Start Position from Player
		nowPos = transform.position;

		if(target == null)
		{
			target = GameObject.FindWithTag("Player").transform;
			Debug.Log("player didn't setting. Auto search 'Player' tag.");
		}

		mouse.y = 0.5f; // start mouse y pos ,0.5f is half
	}

	// Update is called once per frame
	void Update () {
		if (!isCol) {
			// Get MouseMove
			mouse += new Vector2 (oldMouseX, oldMouseY) * Time.deltaTime * spinSpeed;
		} else {
			// Get MouseMove
			oldMouseY -= 1;
			mouse -= new Vector2 (oldMouseX, oldMouseY) * Time.deltaTime * spinSpeed;
			isCol = false;
		}

		// Clamp mouseY move
		mouse.y = Mathf.Clamp (mouse.y, -0.3f + 0.5f, 0.3f + 0.5f);
		// sphere coordinates
		pos.x = Mathf.Sin (mouse.y * Mathf.PI) * Mathf.Cos (mouse.x * Mathf.PI);
		pos.y = Mathf.Cos (mouse.y * Mathf.PI);
		pos.z = Mathf.Sin (mouse.y * Mathf.PI) * Mathf.Sin (mouse.x * Mathf.PI);
		// r and upper
		pos *= nowPos.z;

		pos.y += nowPos.y;
		//pos.x += nowPos.x; // if u need a formula,pls remove comment tag.
		oldPos = pos;

		transform.position = DISTANCE * pos + target.position;
		transform.LookAt(target.position);

		//プレイヤーの向きを変える
		Vector3 lookRot = 2 * target.position - transform.position;
		lookRot.y = target.transform.position.y;
		target.LookAt (lookRot);


		// Get MouseMove
		oldMouseX = Input.GetAxis ("Mouse X");
		oldMouseY = Input.GetAxis ("Mouse Y");
	}

	void OnCollisionStay(Collision other)
	{
		isCol = true;
		Debug.Log (other);
	}
}