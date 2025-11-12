using UnityEngine;

public class CharacterStateEat : CharacterState
{

    private void Start()
    {
        character.MakeInvisible();
    }

    public override void UpdateCharacterVitals()
    {
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
