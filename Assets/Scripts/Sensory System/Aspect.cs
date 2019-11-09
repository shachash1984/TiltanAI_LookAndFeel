using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aspect : MonoBehaviour
{
    public enum AspectType
    {
        Player,
        Enemy,
        Wall
    }
    public AspectType aspectName;
}
