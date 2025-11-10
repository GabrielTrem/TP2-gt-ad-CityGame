using UnityEngine;

public class CharacterStateMoveToDestination : CharacterState
{
    public override void MoveCharacter()
    {
        if (characterVitals.IsHungerAboveThreshold)
        {
            //character.NavigateTo();
        }
        else if (characterVitals.IsLonelinessAboveThreshold)
        {
            //character.NavigateTo();
        }
        else if (characterVitals.IsSleepinessAboveThreshold)
        {
            //character.NavigateTo();
        }
    }

    public override void ManageStateChange()
    {
        
    }
}
