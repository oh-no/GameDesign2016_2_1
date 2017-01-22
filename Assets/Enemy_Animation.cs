using UnityEngine;
using System.Collections;

public class Enemy_Animation : MonoBehaviour
{
    private CharacterController eCon;
    private Animator animator;
    private Vector3 destination;
    private Vector3 destination_p;//目的地
    private float walk;    //移動スピード
    private float run = 2.0f;
    private Vector3 velocity;
    private Vector3 velocity2;
    private Vector3 direction;
    private Vector3 direction_p;
    private bool arrived = false;
    private Vector3 currnent;
    public float firstposx;
    public float firstposy;
    public Collider col;
    private bool isFind = false;
    private bool isSetdestination = false;



    void Start()
    {
        Vector3 current0 = transform.position;   //スタート時の位置を記憶
        var randDestination = Random.insideUnitCircle * 10;
        destination = new Vector3(randDestination.x + current0.x, 0, randDestination.y + current0.z);
        eCon = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        walk = 1.0f;
        velocity = Vector3.zero;
    }
    void Update()
    {
        if (!isFind) {
            if (/*eCon.isGrounded &&*/ (!arrived))
            {

                //velocity = Vector3.zero;
                animator.SetFloat("walking", 2.0f);
                Vector3 direction2D = Vector3.Scale((destination - transform.position), new Vector3(1, 0, 1));
                direction = direction2D.normalized;
                transform.LookAt(new Vector3(destination.x, transform.position.y, destination.z));
                velocity = direction * walk;
                Debug.Log("a"+destination);
                
            }
            if(!arrived) eCon.Move(velocity * Time.deltaTime);
            velocity.y += Physics.gravity.y * Time.deltaTime;

            if (Vector3.Distance(Vector3.Scale(destination, new Vector3(1,0,1)), Vector3.Scale(transform.position, new Vector3(1,0,1))) < 3)
            {
                arrived = true;
                animator.SetFloat("walking", 0.0f);
                if (!isSetdestination)
                {
                    isSetdestination = true;
                    StartCoroutine(SetDestination());
                }
            }
        }else
        {
            //Playerに追いついた時
            if (Vector3.Distance(Vector3.Scale(destination, new Vector3(1, 0, 1)), Vector3.Scale(transform.position, new Vector3(1, 0, 1))) < 1)
            {
                animator.SetTrigger("Attacking");

            }else { 
            //追いかけてるとき
                destination = GameObject.FindGameObjectWithTag("Player").transform.position;
                Vector3 direction2D = Vector3.Scale((destination - transform.position), new Vector3(1, 0, 1));
                direction = direction2D.normalized;
                transform.LookAt(new Vector3(destination.x, transform.position.y, destination.z));
                velocity = direction * walk;
                Debug.Log("b"+destination);
                eCon.Move(velocity * Time.deltaTime);
            }
            velocity.y += Physics.gravity.y * Time.deltaTime;

            
        }
    }

    IEnumerator SetDestination()
    {

        yield return new WaitForSeconds(5);
        arrived = false;
        isSetdestination = false;
        Vector3 current = transform.position;   //スタート時の位置を記憶
        var randDestination = Random.insideUnitCircle * 10;
        destination = current + new Vector3(randDestination.x + 6, 0, randDestination.y + 3);   //ランダム
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("みつけた！");
            isFind = true;
            animator.SetBool("found2", true);
            destination = col.gameObject.transform.position;
           // Debug.Log(destination);
            /*if (eCon.isGrounded && (!arrived)) {
                velocity2 = Vector3.zero;
                Vector3 v = Vector3.Scale((destination_p - transform.position), new Vector3(1, 0, 1));
                direction_p = v.normalized;
                transform.LookAt(new Vector3(destination_p.x, transform.position.y, destination_p.z));
                velocity2 = direction_p * run;
            }*/


        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("見失う");
            isFind = false;
            arrived = true;
            animator.SetBool("found2", false);
            animator.SetFloat("walking", 0.0f);
            StartCoroutine(SetDestination());
        }

    }
}