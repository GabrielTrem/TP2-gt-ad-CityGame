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
        UpdateCharacterVitals();
        ManageStateChange();
    }


    public abstract void UpdateCharacterVitals();
    public abstract void ManageStateChange();
}
