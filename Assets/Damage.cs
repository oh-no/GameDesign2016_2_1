using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {

    [SerializeField]
    private float damage = 50;
    private Animator anim;
    public GameObject skelton;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("a");
            other.GetComponent<EnemyHelth>().GetDamage(damage);

        }
    }
}
