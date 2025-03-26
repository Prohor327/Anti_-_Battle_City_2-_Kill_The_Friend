using UnityEngine;
using System;
using System.Runtime.InteropServices;

[Serializable]
public class PlayerControlPreset
{
    [Header("Control")]
    [field: SerializeField] public KeyCode moveUp { get; private set;}
    [field: SerializeField] public KeyCode moveLeft { get; private set;}
    [field: SerializeField] public KeyCode moveRight { get; private set;}
    [field: SerializeField] public KeyCode moveDown { get; private set;}
    [field: SerializeField] public KeyCode shoot { get; private set;}
}