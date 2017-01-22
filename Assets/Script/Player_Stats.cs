using UnityEngine;
using System.Collections;
using System;

[Serializable]

public class Player_Stats  {
    [SerializeField]
    private BarScript bar;

    //HP
    [SerializeField]
    private float HPmaxVal;

    [SerializeField]
    private float HPcurrentVal;




    //HP用スクリプト
    public float HPCurrentVal
    {
        get
        {
            return HPcurrentVal;
        }

        set
        {
            HPcurrentVal = Mathf.Clamp(value, 0,HPMaxVal);
            bar.Value = HPcurrentVal;
        }
    }

    public float HPMaxVal {
        get {
            return HPmaxVal;
        }
        set {
           
            this.HPmaxVal = value;
            bar.MaxValue = HPmaxVal;
        }
    }
    public void Intialize() {
        this.HPMaxVal = HPmaxVal;
        this.HPCurrentVal = HPcurrentVal;
    }


}
