using UnityEngine;

// Point d'apparition d'un personnage.
public class CharacterSpawnPoint : MonoBehaviour
{
    public Vector3 Position => transform.position;
    public bool IsAvailable { get; set; } = true;
}