using UnityEngine;

public abstract class CharacterState : MonoBehaviour
{
    protected Character character;
    protected CharacterStateMachine characterStateMachine;
    protected CharacterBlackboard characterBlackboard;
    protected CharacterVitals characterVitals;
    void Awake()
    {
        character = GetComponent<Character>();
        characterStateMachine = GetComponent<CharacterStateMachine>();
        characterBlackboard = GetComponent<CharacterBlackboard>();
        characterVitals = GetComponent<CharacterVitals>();

    }

    void Update()
    {
        MoveCharacter();
        ManageStateChange();
    }


    public abstract void MoveCharacter();
    public abstract void ManageStateChange();
}
