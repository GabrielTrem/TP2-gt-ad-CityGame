using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class UpdateUI : MonoBehaviour
{

    private GameManager gameManager;
    private Character[] Characters;

    private TMPro.TextMeshProUGUI[] UiStats;

    [Header("Input Action Asset Reference")]
    public InputActionAsset playerControlsAsset;

    private InputAction nextCharacterAction;
    private InputAction previousCharacterAction;

    private const string PlayerMapName = "Player";
    private const string NextActionName = "NextCharacter";
    private const string PreviousActionName = "PreviousCharacter";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = Finder.GameManager;
        UiStats = GetComponentsInChildren<TMPro.TextMeshProUGUI>();
        Characters = gameManager.CityObjects.Characters;

        if (playerControlsAsset != null)
        {

            var playerMap = playerControlsAsset.FindActionMap(PlayerMapName);

            if (playerMap != null)
            {
                nextCharacterAction = playerMap.FindAction(NextActionName);
                previousCharacterAction = playerMap.FindAction(PreviousActionName);
            }
            else
            {
                Debug.LogError($"Action Map '{PlayerMapName}' introuvable dans l'Asset.");
            }
        }
        else
        {
            Debug.LogError("L'Asset d'Input Actions n'a pas été assigné !");
        }

        if (nextCharacterAction != null && previousCharacterAction != null)
        {
            nextCharacterAction.Enable();
            previousCharacterAction.Enable();

            nextCharacterAction.performed += OnNextCharacterPerformed;
            previousCharacterAction.performed += OnPreviousCharacterPerformed;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (nextCharacterAction.IsPressed()) { 
            Debug.Log("j'ai peser sur x");
        }

    }

    void OnNextCharacterPerformed(InputAction.CallbackContext context)
    {
        CycleTarget(1);
    }

    void OnPreviousCharacterPerformed(InputAction.CallbackContext context)
    {
        CycleTarget(-1);
    }

    private void CycleTarget(int direction)
    {
    }

    private void OnDisable()
    {
        if (nextCharacterAction != null && previousCharacterAction != null)
        {
            nextCharacterAction.performed -= OnNextCharacterPerformed;
            previousCharacterAction.performed -= OnPreviousCharacterPerformed;

            nextCharacterAction.Disable();
            previousCharacterAction.Disable();
        }
    }
}
