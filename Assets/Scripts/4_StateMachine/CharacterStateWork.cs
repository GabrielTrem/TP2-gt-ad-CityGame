using UnityEngine;

public class CharacterStateWork : CharacterState
{

    public override void MoveCharacter()
    {
        characterVitals.RaiseHunger();
        characterVitals.RaiseLoneliness();
        characterVitals.RaiseSleepiness();
    }
    public override void ManageStateChange()
    {
        if (characterVitals.IsHungerAboveThreshold || characterVitals.IsLonelinessAboveThreshold || characterVitals.IsSleepinessAboveThreshold)
        {
            characterStateMachine.ChangeCharacterState(CharacterStateMachine.CharacterNextState.MoveToDestination);
        }
    }
}
