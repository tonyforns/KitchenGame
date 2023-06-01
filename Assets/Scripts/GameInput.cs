using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get;  private set; }

    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractAlternativeAction;
    public event EventHandler OnPauseAction;

    private PlayerInputActions playerInputActions;
    private void Awake()
    {
        Instance = this;
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Interact.performed += Interact_performed;
        playerInputActions.Player.InteractAlternative.performed += InteractAlternative_performed;
        playerInputActions.Player.Pause.performed+= Pause_performed;
    }

    private void Pause_performed(InputAction.CallbackContext obj)
    {
        OnPauseAction.Invoke(this, EventArgs.Empty);
    }

    private void InteractAlternative_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAlternativeAction?.Invoke(this, EventArgs.Empty);
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;
        return inputVector;
    }

    private void OnDestroy()
    {
        playerInputActions.Player.Interact.performed -= Interact_performed;
        playerInputActions.Player.InteractAlternative.performed -= InteractAlternative_performed;
        playerInputActions.Player.Pause.performed -= Pause_performed;

        playerInputActions.Dispose();
    }
}
