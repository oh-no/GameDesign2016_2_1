using UnityEngine;
using System.Collections;
using System;

[Serializable]

public class Player_Stats_MP
{
    //MP
    [SerializeField]
    private BarScript_MP MPbar;
    [SerializeField]
    private float MPmaxVal;

    [SerializeField]
    private float MPcurrentVal;



   

    //MP用スクリプト
    public float MPCurrentVal
    {
        get
        {
            return MPcurrentVal;
        }

        set
        {
            MPcurrentVal = Mathf.Clamp(value, 0, MPMaxVal);
            MPbar.Value = MPcurrentVal;
        }
    }

    public float MPMaxVal
    {
        get
        {
            return MPmaxVal;
        }

        set
        {

            this.MPmaxVal = value;
            MPbar.MPMaxValue = MPmaxVal;
        }
    }
    public void IntializeMP()
    {
        this.MPMaxVal = MPmaxVal;
        this.MPCurrentVal = MPcurrentVal;
    }
}
