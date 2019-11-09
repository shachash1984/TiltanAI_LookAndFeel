using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Sense : MonoBehaviour
{
    protected float elapsedTime = 0f;

    protected virtual void Initialize() { }
    protected virtual void UpdateSense() { }

    public Aspect.AspectType aspectName;
    public float DetectionRate { get; private set; }

    private void Start()
    {
        elapsedTime = 0f;
        DetectionRate = 1;
        aspectName = Aspect.AspectType.Enemy;
        Initialize();
    }

    private void Update()
    {
        UpdateSense();
    }
}
