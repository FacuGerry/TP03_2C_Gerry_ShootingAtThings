using System;
using UnityEngine;

[Serializable]
public class CustomIkController
{
    public AvatarIKGoal goal;
    public Transform target;
    public float weight;
}