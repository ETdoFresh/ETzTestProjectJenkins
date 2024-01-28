using UnityEngine;
using UnityEngine.UI;

public class ToggleSpinningButtonBehaviour : MonoBehaviour
{
    [SerializeField] private Button button;

    private void OnValidate()
    {
        if (!button) button = GetComponent<Button>();
    }
    
    private void OnEnable()
    {
        button.onClick.AddListener(OnToggleSpinningClicked);
    }
    
    private void OnDisable()
    {
        button.onClick.RemoveListener(OnToggleSpinningClicked);
    }
    
    private void OnToggleSpinningClicked()
    {
        GameEvents.ToggleSpinningClicked.Invoke();
    }
}
