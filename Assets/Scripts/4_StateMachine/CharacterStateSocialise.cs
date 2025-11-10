using UnityEngine;

public class CharacterStateSocialise : CharacterState
{
    public override void MoveCharacter()
    {
        characterVitals.LowerLoneliness();
    }
    public override void ManageStateChange()
    {
        if (characterVitals.IsLonelinessBellowTarget)
        {
            character.MakeVisible();
            characterStateMachine.ChangeCharacterState(CharacterStateMachine.CharacterNextState.MoveToDestination);
        }
    }
}
