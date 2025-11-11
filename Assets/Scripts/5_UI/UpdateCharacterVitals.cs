using UnityEngine;
using UnityEngine.UI;

public class UpdateCharacterVitals : MonoBehaviour
{
    [SerializeField] private Scrollbar hungerBar;
    [SerializeField] private Scrollbar lonelinessBar;
    [SerializeField] private Scrollbar sleepinessSlider;

    private CharacterVitals currentVitals;

    public void SetTarget(Character character)
    {
        currentVitals = character != null ? character.Vitals : null;
        UpdateVitalsUI(true);
    }

    public void UpdateVitalsUI(bool forceUpdate = false)
    {
        if (currentVitals == null)
        {
            if (hungerBar != null) hungerBar.gameObject.SetActive(false);
            if (lonelinessBar != null) lonelinessBar.gameObject.SetActive(false);
            if (sleepinessSlider != null) sleepinessSlider.gameObject.SetActive(false);
            return;
        }

        if (forceUpdate)
        {
            if (hungerBar != null) hungerBar.gameObject.SetActive(true);
            if (lonelinessBar != null) lonelinessBar.gameObject.SetActive(true);
            if (sleepinessSlider != null) sleepinessSlider.gameObject.SetActive(true);
        }

        if (hungerBar != null)
        {
            if (forceUpdate) 
            hungerBar.value = currentVitals.Hunger;
        }

        if (lonelinessBar != null)
        {
            if (forceUpdate)
            lonelinessBar.value = currentVitals.Loneliness;
        }

        if (sleepinessSlider != null)
        {
            if (forceUpdate)
            sleepinessSlider.value = currentVitals.Sleepiness;
        }
    }
}