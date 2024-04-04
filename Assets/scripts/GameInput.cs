using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour{

    public event EventHandler OnInteractAction;
    private PlayerInputAction playerInputAction;

    private void Awake()
    {
        playerInputAction = new PlayerInputAction();
        playerInputAction.player.Enable();

        playerInputAction.player.Interact.performed += Interact_performed;
    }
    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if(OnInteractAction != null) { 
        OnInteractAction?.Invoke(this, EventArgs.Empty);
        }
    }

    public Vector2 GetMovementVectorNormalized(){
       Vector2 inputVector = playerInputAction.player.move.ReadValue<Vector2>();
        

        inputVector = inputVector.normalized;
        return inputVector;
    }
    
}
