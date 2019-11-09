using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smell : Sense
{

    private void OnTriggerEnter(Collider other)
    {
        SmellEmitter smellEmitter = other.GetComponent<SmellEmitter>();
        if(smellEmitter)
        {
            Aspect aspect = other.GetComponent<Aspect>();
            if (aspect && aspect.aspectName == Aspect.AspectType.Player)
            {
                Debug.Log("Smelling player");
            }
        }
    }

}
