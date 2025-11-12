using UnityEngine;

public class CharacterStateSleep : CharacterState
{
    private void Start()
    {
        character.MakeInvisible();
    }

    public override void UpdateCharacterVitals()
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
