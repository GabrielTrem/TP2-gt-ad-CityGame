using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour
{
    private GameManager gameManager;
    private Character[] Characters;
    private int currentCharacterIndex = 0;

    [Header("Input Action Asset Reference")]
    [SerializeField] private InputActionAsset playerControlsAsset;

    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI characterNameText;
    [SerializeField] private TextMeshProUGUI currentStateNameText;
    [SerializeField] private Image characterAvatarImage;
    
    
    private UpdateCharacterVitals vitalsUI;

    private InputAction nextCharacterAction;
    private InputAction previousCharacterAction;

    private const string PlayerMapName = "Player";
    private const string NextActionName = "NextCharacter";
    private const string PreviousActionName = "PreviousCharacter";

    void Start()
    {
        vitalsUI = GetComponent<UpdateCharacterVitals>();

        gameManager = Finder.GameManager;

        Characters = gameManager.CityObjects.Characters
            .Where(c => c != null)
            .ToArray();

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
        UpdateCharacterDisplay();
    }

    void Update()
    {
        UpdateCharacterState();

        if (vitalsUI != null)
        {
            vitalsUI.UpdateVitalsUI();
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
        if (Characters == null || Characters.Length == 0) return;

        Character previousCharacter = Characters[currentCharacterIndex];

        int newIndex = currentCharacterIndex + direction;

        currentCharacterIndex = (newIndex % Characters.Length + Characters.Length) % Characters.Length;

        if (previousCharacter != null)
        {
            previousCharacter.HidePointer();
        }

        UpdateCharacterDisplay();
    }

    private void UpdateCharacterDisplay()
    {
        if (Characters == null || Characters.Length == 0 || currentCharacterIndex < 0 || currentCharacterIndex >= Characters.Length)
        {
            if (characterNameText != null) characterNameText.text = "Aucun Personnage Disponible";
            if (currentStateNameText != null) currentStateNameText.text = "N/A";

            if (vitalsUI != null) vitalsUI.SetTarget(null);

            return;
        }

        Character character = Characters[currentCharacterIndex];

        if (character == null)
        {
            if (characterNameText != null) characterNameText.text = "ERREUR : Personnage Déréférencé";
            if (currentStateNameText != null) currentStateNameText.text = "N/A";
            if (characterAvatarImage != null) characterAvatarImage.sprite = null;

            if (vitalsUI != null) vitalsUI.SetTarget(null);

            return;
        }

        if (characterNameText != null)
        {
            characterNameText.text = character.FullName;
        }

        if (characterAvatarImage != null)
        {
            characterAvatarImage.sprite = character.Avatar;
        }

        if (vitalsUI != null)
        {
            vitalsUI.SetTarget(character);
        }

        UpdateCharacterState();
        character.ShowPointer();
    }

    private void UpdateCharacterState()
    {
        if (Characters == null || Characters.Length == 0) return;

        Character character = Characters[currentCharacterIndex];

        if (character == null) return;

        CharacterStateMachine stateMachine = character.GetComponent<CharacterStateMachine>();
        if (currentStateNameText != null && stateMachine != null)
        {
            currentStateNameText.text = $"État : {stateMachine.CurrentStateName}";
        }
    }

    private void OnDisable()
    {
        if (nextCharacterAction != null)
        {
            nextCharacterAction.performed -= OnNextCharacterPerformed;
            nextCharacterAction.Disable();
        }

        if (previousCharacterAction != null)
        {
            previousCharacterAction.performed -= OnPreviousCharacterPerformed;
            previousCharacterAction.Disable();
        }
    }
}