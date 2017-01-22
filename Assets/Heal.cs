using UnityEngine;
using System.Collections;

public class Heal : MonoBehaviour {

   // private bool isHealing = false;
    [SerializeField]private GameObject healObj;
    private Animator anim;
    [SerializeField]private GameObject fireObj;
    [SerializeField]
    private GameObject iceObj;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GameObject heal = Instantiate(healObj, transform.position + new Vector3(0, 0.5f, 0), transform.rotation) as GameObject;
            anim.SetTrigger("Heal");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {

            anim.SetTrigger("Fire");

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            anim.SetTrigger("Ice");
            GameObject Ice = Instantiate(iceObj, transform.position + transform.forward * 2.5f + new Vector3(0, 0.5f, 0), transform.rotation /*+ transform.forward + new Vector3(0,90,0)*/) as GameObject;
            Ice.SetActive(true);
        }
	}

    public void Fire()
    {
        GameObject Fire = Instantiate(fireObj, transform.position + transform.forward*2.5f+new Vector3(0, 0.5f, 0), transform.rotation) as GameObject;
        Fire.SetActive(true);
    }
    
}
