using System.Linq;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    private Character character;
    private CharacterBlackboard blackboard;
    private SphereCollider sphereCollider;

    private void Awake()
    {
        character = GetComponentInParent<Character>();
        blackboard = character.Blackboard;
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger)
            return;

        if (other.TryGetComponent(out Trash trash))
        {
            if (character.Vitals)
                blackboard.LastSeenTrash = trash;
        }

        else if (other.TryGetComponent(out Character otherCharacter))
        {
            if (blackboard.Friends.Contains(otherCharacter))
                blackboard.LastSeenFriend = otherCharacter;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.isTrigger)
            return;

        if (other.TryGetComponent(out Trash trash))
        {
            if (blackboard.LastSeenTrash == trash)
                blackboard.LastSeenTrash = null;
        }

        else if (other.TryGetComponent(out Character otherCharacter))
        {
            if (blackboard.LastSeenFriend == otherCharacter)
                blackboard.LastSeenFriend = null;
        }
    }

}
