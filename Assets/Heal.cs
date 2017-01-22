using UnityEngine;
using System.Collections;

public class Heal : MonoBehaviour {

    private bool isHealing = false;
    [SerializeField]private GameObject healObj;
    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject heal = Instantiate(healObj, transform.position + new Vector3(0, 0.5f, 0), transform.rotation) as GameObject;
            anim.SetTrigger("Heal");
        }
	}
}
