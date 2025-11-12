using UnityEngine;

public class CharacterStatePickUpTrash : CharacterState
{
    public void Start()
    {
        character.NavigateTo(characterBlackboard.LastSeenTrash);
    }

    private void Update()
    {
        if (character.IsCloseTo(characterBlackboard.LastSeenTrash) && !character.IsPickingTrash())
        {
            character.PickUpTrash(characterBlackboard.LastSeenTrash);
            characterBlackboard.LastSeenTrash = null;
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
