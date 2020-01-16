using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushMechanism : MonoBehaviour
{
    public bool marja = true;

    public bool OnkoMarja()
    {
        if (marja)
        {
            marja = false;
            transform.GetChild(0).gameObject.SetActive(false);
            return true;
        }
        else
        {
            return false;
        }
    }



}




