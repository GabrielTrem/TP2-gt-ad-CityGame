using UnityEngine;

public class CharacterStateThrowTrash : CharacterState
{
    private void Start()
    {
        character.NavigateTo(characterBlackboard.lastSeenTrash);
    }

    private void Update()
    {
        if (character.IsCloseTo(characterBlackboard.lastSeenTrash) && !character.IsThrowingTrash())
        {
            character.ThrowTrash();
            characterBlackboard.lastSeenTrash = null;
        }
    }

    public override void UpdateCharacterVitals()
    {
        characterVitals.RaiseHunger();
        characterVitals.RaiseLoneliness();
        characterVitals.RaiseSleepiness();
    }

    public override void ManageStateChange()
    {
        if (!character.IsThrowingTrash())
        { 
            characterStateMachine.ChangeCharacterState(CharacterStateMachine.CharacterNextState.MoveToDestination);
        }
    }
}
