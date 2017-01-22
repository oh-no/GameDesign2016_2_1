using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    [SerializeField]
    private Player_Stats health;


    private void Awake()
    {
        health.Intialize();


    }
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Q)) {
            health.HPCurrentVal -= 10;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            health.HPCurrentVal += 10;
        }
  

    }

}
