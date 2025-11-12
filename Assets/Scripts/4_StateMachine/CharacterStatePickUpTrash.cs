using UnityEngine;

public class CharacterStatePickUpTrash : CharacterState
{
    public void Start()
    {
        character.NavigateTo(characterBlackboard.lastSeenTrash);
    }

    private void Update()
    {
        if (character.IsCloseTo(characterBlackboard.lastSeenTrash) && !character.IsPickingTrash())
        {
            character.PickUpTrash(characterBlackboard.lastSeenTrash);
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
        if (!character.IsPickingTrash()) 
        {
            characterStateMachine.ChangeCharacterState(CharacterStateMachine.CharacterNextState.MoveToDestination);
        }
    }

}
