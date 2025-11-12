using UnityEngine;

public class CharacterStateSocialise : CharacterState
{
    private void Start()
    {
        character.MakeInvisible();
    }
    public override void UpdateCharacterVitals()
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
