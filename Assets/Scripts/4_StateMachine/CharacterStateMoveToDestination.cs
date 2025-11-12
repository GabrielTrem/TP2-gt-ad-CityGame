using System;
using Unity.VisualScripting;
using UnityEngine;
using static CharacterStateMachine;

public class CharacterStateMoveToDestination : CharacterState
{
    private void Start()
    {
        character.NavigateTo(characterBlackboard.currentDestination);
    }
    public override void UpdateCharacterVitals()
    {
        characterVitals.RaiseHunger();
        characterVitals.RaiseLoneliness();
        characterVitals.RaiseSleepiness();
    }

    public override void ManageStateChange()
    {
        if (characterBlackboard.lastSeenFriend != null)
        {
            characterStateMachine.ChangeCharacterState(CharacterStateMachine.CharacterNextState.Greet);
        }
        else if (characterBlackboard.lastSeenTrash != null) 
        {
            if(characterStateMachine.TrashBehaviour == CityCharacterTrashBehaviour.PickUp)
            {
                characterStateMachine.ChangeCharacterState(CharacterStateMachine.CharacterNextState.PickUpTrash);
            }
            else if(characterStateMachine.TrashBehaviour == CityCharacterTrashBehaviour.Throw && characterBlackboard.ShouldThrowTrash) 
            {
                characterStateMachine.ChangeCharacterState(CharacterNextState.ThrowTrash);
            }
        }

        if (character.IsCloseTo(characterBlackboard.currentDestination))
        {
            Building currentDestinationBuilding = (Building)characterBlackboard.currentDestination;
            switch (currentDestinationBuilding.Type)
            {
                case Building.CityBuildingType.Food:
                    characterStateMachine.ChangeCharacterState(CharacterStateMachine.CharacterNextState.Eat);
                    break;

                case Building.CityBuildingType.Social:
                    characterStateMachine.ChangeCharacterState(CharacterStateMachine.CharacterNextState.Socialise);
                    break;

                case Building.CityBuildingType.House:
                    characterStateMachine.ChangeCharacterState(CharacterStateMachine.CharacterNextState.Sleep);
                    break;

                case Building.CityBuildingType.Workplace:
                    characterStateMachine.ChangeCharacterState(CharacterStateMachine.CharacterNextState.Work);
                    break;
            }
            characterBlackboard.currentDestination = null;
        }
    }
}
