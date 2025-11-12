using System.Linq;
using UnityEngine;

public class CharacterSensor : MonoBehaviour
{
    private Character character;
    private CharacterBlackboard blackboard;
    private SphereCollider sphereCollider;

    private void Awake()
    {
        character = GetComponent<Character>();
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
    }

    private void Start()
    {
        blackboard = character.Blackboard;
    }

    private void OnTriggerEnter(Collider other)
    {

        Trash trash = other.gameObject.GetComponent<Trash>();
        if (trash != null)
        {
            blackboard.LastSeenTrash = trash;
        }
        Character otherCharacter = other.gameObject.GetComponent<Character>();
        if (otherCharacter != null)
        {
            blackboard.LastSeenCharacter = otherCharacter;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Trash trash = other.gameObject.GetComponent<Trash>();
        if (trash != null)
        {
            if (blackboard.LastSeenTrash == trash)
                blackboard.LastSeenTrash = null;
        }
        Character otherCharacter = other.gameObject.GetComponent<Character>();
        if (otherCharacter != null)
        {
            if (blackboard.LastSeenCharacter == otherCharacter)
                blackboard.LastSeenCharacter = null;
        }
    }

}
