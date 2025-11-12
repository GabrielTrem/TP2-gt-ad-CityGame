using UnityEngine;

public class CharacterStateWork : CharacterState
{
    private void Start()
    {
        character.MakeInvisible();
    }
    public override void UpdateCharacterVitals()
    {
        characterVitals.RaiseHunger();
        characterVitals.RaiseLoneliness();
        characterVitals.RaiseSleepiness();
    }
    public override void ManageStateChange()
    {
        if (characterVitals.IsHungerAboveThreshold || characterVitals.IsLonelinessAboveThreshold || characterVitals.IsSleepinessAboveThreshold)
        {
            character.MakeVisible();
            characterStateMachine.ChangeCharacterState(CharacterStateMachine.CharacterNextState.MoveToDestination);
        }
    }
}
