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
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            magic.MPCurrentVal -= 20;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            magic.MPCurrentVal -= 30;
        }


    }
}
