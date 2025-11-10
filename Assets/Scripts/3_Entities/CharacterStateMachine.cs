using Unity.VisualScripting;
using UnityEngine;

// Il s'agit de la classe dans laquelle vous allez implémenter la machine à état. Vous aurez tout particulièrement à
// compléter la méthode "ChangeCharacterState" (Vous aurez pour cela besoin de créer une énumération des prochains états)
//
// Notez que c'est aussi ici que les personnages "malpropres" sont gérés. Pour les personnages "malpropre", cette classe
// contient une méthode qui, de temps en temps, met le booléen "shouldThrowTrash" du CharacterBlackboard à "true". Dans
// votre machine à état, cela signifie qu'il est temps de changer d'état pour lancer un déchet.
//
// Au cas où ce n'était pas encore clair, vous avez à modifier cette classe pour le travail.
public class CharacterStateMachine : MonoBehaviour
{
    [Header("Behaviour")]
    [SerializeField] private CityCharacterTrashBehaviour trashBehaviour = CityCharacterTrashBehaviour.Ignore;
    [SerializeField, Range(0, 100)] private float throwTrashChances = 5f;
    [SerializeField, Min(0)] private float throwTrashCheckDelay = 1f;

    private Character character;
    private float throwTrashCheckTimer;

    public enum CharacterNextState { MoveToDestination, Work, Eat, Socialise, Sleep, PickUpTrash, ThrowTrash, Greet }
    public enum CityCharacterTrashBehaviour{ Ignore, PickUp, Throw }

    private CharacterState currentState = null;
    public CityCharacterTrashBehaviour TrashBehaviour => trashBehaviour;

    private void Awake()
    {
        // Get dependencies.
        character = GetComponent<Character>();
        currentState = gameObject.AddComponent<CharacterStateMoveToDestination>();

        // Init timers.
        throwTrashCheckTimer = 0;
    }

    private void Update()
    {
        UpdateTimers();
    }

    private void UpdateTimers()
    {
        if (trashBehaviour == CityCharacterTrashBehaviour.Throw)
        {
            throwTrashCheckTimer += Time.deltaTime;
            if (throwTrashCheckTimer >= throwTrashCheckDelay)
            {
                character.Blackboard.ShouldThrowTrash = RandomUtils.Chance(throwTrashChances);
                throwTrashCheckTimer = 0f;
            }
        }
        else
        {
            throwTrashCheckTimer = 0f;
        }
    }

    public void ChangeCharacterState(CharacterNextState nextState)
    {
        Destroy(currentState);

        switch (nextState)
        {
            case CharacterNextState.MoveToDestination:
                {
                    currentState = gameObject.AddComponent<CharacterStateMoveToDestination>();
                    break;
                }
            case CharacterNextState.Work:
                {
                    currentState = gameObject.AddComponent<CharacterStateWork>();
                    break;
                }
            case CharacterNextState.Eat:
                {
                    currentState = gameObject.AddComponent<CharacterStateEat>();
                    break;
                }
            case CharacterNextState.Socialise:
                {
                    currentState = gameObject.AddComponent<CharacterStateSocialise>();
                    break;
                }
            case CharacterNextState.Sleep:
                {
                    currentState = gameObject.AddComponent<CharacterStateSleep>();
                    break;
                }
            case CharacterNextState.PickUpTrash:
                {
                    currentState = gameObject.AddComponent<CharacterStatePickUpTrash>();
                    break;
                }
            case CharacterNextState.ThrowTrash:
                {
                    currentState = gameObject.AddComponent<CharacterStateThrowTrash>();
                    break;
                }
            case CharacterNextState.Greet:
                {
                    currentState = gameObject.AddComponent<CharacterStateGreet>();
                    break;
                }
        }
    }  
}
