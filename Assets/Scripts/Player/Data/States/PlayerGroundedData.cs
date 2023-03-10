using System;
using UnityEngine;

[Serializable]
public class PlayerGroundedData
{
    [field: SerializeField] [field: Range(0f, 25f)] public float baseSpeed { get; private set;} = 5f;
    [field: SerializeField] public PlayerWalkData walkData { get; private set;}
    [field: SerializeField] public PlayerRunData runData { get; private set;}
    [field: SerializeField] public PlayerRollData rollData { get; private set;}

    // [SerializeField]
    // private PlayerRunData runData;

    // public PlayerRunData RunData { 
    //     get {return runData;}
    //     private set {runData = value;}
    // }
}
