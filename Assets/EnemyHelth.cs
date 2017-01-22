using UnityEngine;
using System.Collections;

public class EnemyHelth : MonoBehaviour {

    [SerializeField]private float hp = 100;
    private Animator anim;
    private bool isAnimated = false;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (hp == 50)
        {
            anim.SetTrigger("Damaging");
         //   Invoke("delay", 3.5f);

        }
        else if (hp == 0) {
            anim.SetBool("Death",true);
            if (!isAnimated)
            {
                StartCoroutine(coRoutine());
                isAnimated = true;
            }
                
          //  Destroy(gameObject);
        }

	}

    public void GetDamage(float damage)
    {
        Debug.Log(hp);
        hp = Mathf.Clamp(hp-damage, 0, 100);
    }

    IEnumerator coRoutine()
    {
       yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
        yield break;
    }
    private void delay()
    {
        anim.SetFloat("walking", 0.0f);
    }
}
