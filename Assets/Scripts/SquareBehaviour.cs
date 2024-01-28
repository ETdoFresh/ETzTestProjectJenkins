using System;
using UnityEngine;

public enum CubeState
{
    NotRotating,
    RotatingSlow,
    RotatingFast,
}

public class SquareBehaviour : MonoBehaviour
{
    [SerializeField] public CubeState state = CubeState.NotRotating;
    [SerializeField] public float rotatingSlowSpeed = 100f;
    [SerializeField] public float rotatingFastSpeed = 300f;

    private void OnEnable()
    {
        GameEvents.ToggleSpinningClicked.AddListener(OnToggleSpinningClicked);
    }
    
    private void OnDisable()
    {
        GameEvents.ToggleSpinningClicked.RemoveListener(OnToggleSpinningClicked);
    }
    
    private void OnToggleSpinningClicked()
    {
        state = state switch
        {
            CubeState.NotRotating => CubeState.RotatingSlow,
            CubeState.RotatingSlow => CubeState.RotatingFast,
            CubeState.RotatingFast => CubeState.NotRotating,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private void Update()
    {
        switch (state)
        {
            case CubeState.NotRotating:
                break;
            case CubeState.RotatingSlow:
                transform.Rotate(-Vector3.forward, rotatingSlowSpeed * Time.deltaTime);
                break;
            case CubeState.RotatingFast:
                transform.Rotate(-Vector3.forward, rotatingFastSpeed * Time.deltaTime);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
