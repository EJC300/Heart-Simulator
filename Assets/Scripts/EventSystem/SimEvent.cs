
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimEvent<T> where T : class
{
    public delegate void Fire(T t);

    private float delayCounter;

    private float delayCount;
    private bool Delay()
    {
        
       if(delayCounter < delayCount)
        {
            delayCounter++;
            return false;
        }
       else
        {
            delayCounter = Time.deltaTime;
            return true;
        }
    }
   
    public void InvokeSimEvent()
    {
        if(Delay())
        {
           
        }
    }
}
