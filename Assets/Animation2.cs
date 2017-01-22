using UnityEngine;
using System.Collections;

public class Animation2 : MonoBehaviour
{

   
    [SerializeField]
    private float rotateSpeed = 3;
    private float destroyTime = 3;
    private GameObject player;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(StartRotate());
        player = GameObject.FindGameObjectWithTag("Player");
        //transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        this.transform.position += player.transform.forward*0.5f;
   
       




    }

    IEnumerator StartRotate()
    {
        
        yield return new WaitForSeconds(destroyTime / 2);
        
        yield return new WaitUntil(() => transform.localScale.x < 0.1f);
        //yield return new WaitForSeconds(destroyTime);
       
        //Destroy(gameObject);
    }


}
