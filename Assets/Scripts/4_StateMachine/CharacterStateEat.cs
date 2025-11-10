using UnityEngine;

public class CharacterStateEat : CharacterState
{
    public override void MoveCharacter()
    {
        character.MakeInvisible();
        characterVitals.LowerHunger();
    }

    public override void ManageStateChange()
    {
        if (characterVitals.IsHungerBellowTarget)
        {
            character.MakeVisible();
            characterStateMachine.ChangeCharacterState(CharacterStateMachine.CharacterNextState.MoveToDestination);
        }
    }
}
