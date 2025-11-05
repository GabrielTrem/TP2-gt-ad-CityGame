using UnityEngine;

public abstract class CharacterState : MonoBehaviour
{
    void Awake()
    {
    }

    void Update()
    {
    }

    public abstract void ManageStateChange();
}
