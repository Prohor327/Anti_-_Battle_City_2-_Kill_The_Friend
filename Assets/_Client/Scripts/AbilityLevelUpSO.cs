using UnityEngine;

[CreateAssetMenu(fileName = "AbillitySO", menuName = "Game/AbillitySO", order = 0)]
public class AbillitySO : ScriptableObject 
{
    [field: SerializeField] public AbillityType abillityType { get; private set; }
    [field: SerializeField] public float value { get; private set; }
    [field: SerializeField] public string description { get; private set; }
    [field: SerializeField] public Texture2D texture { get; private set; }
}