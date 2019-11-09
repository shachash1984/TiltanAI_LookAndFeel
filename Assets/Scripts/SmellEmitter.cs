using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class SmellEmitter : MonoBehaviour
{
    private SphereCollider smellRange;
    private float originalSmellIntensity;
    public float smellIntensity;
    private Coroutine diminishCoroutine;
    public float diminishRate = 0.01f;

    private void Awake()
    {
        smellRange = GetComponent<SphereCollider>();
        smellIntensity = smellRange.radius;
    }

    private void OnTriggerEnter(Collider other)
    {
        SmellEmitter se = other.GetComponent<SmellEmitter>();
        if (se && se.smellIntensity > this.smellIntensity)
        {

            smellRange.radius = se.smellIntensity;
            smellIntensity = se.smellIntensity;
            if (diminishCoroutine != null)
                StopCoroutine(diminishCoroutine);
            diminishCoroutine = StartCoroutine(DiminishSmell());
        }
    }


    IEnumerator DiminishSmell()
    {
        while (smellIntensity > originalSmellIntensity)
        {
            smellIntensity -= Time.deltaTime * diminishRate;
            smellRange.radius = smellIntensity;
            yield return null;
        }
    }

}
