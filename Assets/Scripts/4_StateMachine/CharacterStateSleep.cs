using UnityEngine;

public class CharacterStateSleep : CharacterState
{
    public override void MoveCharacter()
    {
        characterVitals.LowerSleepiness();
    }
    public override void ManageStateChange()
    {
        if (characterVitals.IsSleepinessBellowTarget)
        {
            character.MakeVisible();
            characterStateMachine.ChangeCharacterState(CharacterStateMachine.CharacterNextState.MoveToDestination);
        }
    }

}
