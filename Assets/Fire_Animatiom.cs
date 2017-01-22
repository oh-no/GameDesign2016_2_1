using UnityEngine;
using System.Collections;

public class Fire_Animatiom : MonoBehaviour
{

    private bool isExpansion = false;
    private bool isReduction = false;
    [SerializeField]
    private float rotateSpeed = 3;
    [SerializeField]
    private float destroyTime = 3;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(StartRotate());
        //transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //回転
        transform.eulerAngles += new Vector3(0, 0, rotateSpeed);

        //拡大
        if (isExpansion)
        {
            
            transform.localScale = new Vector3(Mathf.Clamp(transform.localScale.x + Time.deltaTime, 0, 1), Mathf.Clamp(transform.localScale.y + Time.deltaTime, 0, 1), transform.localScale.z );
        }
        //縮小
        if (isReduction)
        {
            transform.localScale = new Vector3(Mathf.Clamp(transform.localScale.x - Time.deltaTime, 0, 1), Mathf.Clamp(transform.localScale.y - Time.deltaTime, 0, 1), transform.localScale.z);
        }




    }

    IEnumerator StartRotate()
    {
        isExpansion = true;
        yield return new WaitForSeconds(destroyTime / 2);
        isExpansion = false;
        isReduction = true;
        yield return new WaitUntil(() => transform.localScale.x < 0.1f);
        //yield return new WaitForSeconds(destroyTime);
        isExpansion = false;
        Destroy(gameObject);
    }


}
