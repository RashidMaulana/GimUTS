using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacksoundScript : MonoBehaviour
{
    public static BacksoundScript bs;
    private void Awake()
    {
        if(bs!= null && bs != this)
        {
            Destroy(this.gameObject);
            return;
        }

        bs = this;

        DontDestroyOnLoad(this);
    }
}
