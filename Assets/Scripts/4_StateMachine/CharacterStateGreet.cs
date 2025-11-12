using UnityEngine;

public class CharacterStateGreet : CharacterState
{

    public void Start()
    {
        character.CancelNavigate();
        character.GreetCharacter(characterBlackboard.LastSeenCharacter);
    }
    public override void UpdateCharacterVitals()
    {
        characterVitals.LowerLoneliness();
    }

    public override void ManageStateChange()
    {
        if (!character.IsGreetingCharacter()) 
        {
            characterStateMachine.ChangeCharacterState(CharacterStateMachine.CharacterNextState.MoveToDestination);
        }
    }

}
