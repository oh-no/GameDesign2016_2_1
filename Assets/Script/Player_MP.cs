using UnityEngine;
using System.Collections;

public class Player_MP : MonoBehaviour {

    [SerializeField]
    private Player_Stats_MP magic;
    private void Awake()
    {
      magic.IntializeMP();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.E))
        {
            magic.MPCurrentVal -= 10;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            magic.MPCurrentVal += 10;
        }


    }
}
