using UnityEngine;
using System.Collections;

public class Healing_Animation : MonoBehaviour {

    private bool isExpansion = false;
    private bool isReduction = false;
    [SerializeField]private float rotateSpeed = 3;
    [SerializeField]private float destroyTime = 3;

	// Use this for initialization
	void Start () {
        StartCoroutine(StartRotate());
        //transform.localScale = new Vector3(0, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
        //回転
        transform.eulerAngles += new Vector3(0, rotateSpeed, 0);

        //拡大
        if (isExpansion)
        {
            //float velocity = 1;
            //transform.localScale = new Vector3(Mathf.SmoothDamp(0, 5, ref velocity, destroyTime/2), transform.localScale.y, Mathf.SmoothDamp(0, 5, ref velocity, destroyTime / 2));

            transform.localScale = new Vector3(Mathf.Clamp(transform.localScale.x+Time.deltaTime, 0, 1), transform.localScale.y, Mathf.Clamp(transform.localScale.z+Time.deltaTime, 0, 1));
        }
        //縮小
        if (isReduction)
        {
            transform.localScale = new Vector3(Mathf.Clamp(transform.localScale.x - Time.deltaTime, 0, 1), transform.localScale.y, Mathf.Clamp(transform.localScale.z - Time.deltaTime, 0, 1));
        }




    }

    IEnumerator StartRotate()
    {
        isExpansion = true;
        yield return new WaitForSeconds(destroyTime/2);
        isExpansion = false;
        isReduction = true;
        yield return new WaitUntil ( () => transform.localScale.x < 0.1f );
        //yield return new WaitForSeconds(destroyTime);
        isExpansion = false;
        Destroy(gameObject);
    }

   
}
