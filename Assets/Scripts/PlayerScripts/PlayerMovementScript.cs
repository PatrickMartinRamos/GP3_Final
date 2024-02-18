using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{
    playerManagerScript _playerManager;

    //system var
    private _playerInputs player_Inputs;
    private Vector2 moveAction;
    private Rigidbody2D rb2d;

    #region enable _playerInputs
    private void OnEnable()
    {
        if (player_Inputs == null)
        {
            //enable inputs
            player_Inputs = new _playerInputs();

            player_Inputs._playerMovements.Movements.performed += i => moveAction = i.ReadValue<Vector2>();
            player_Inputs._playerMovements.Movements.canceled += i => moveAction = i.ReadValue<Vector2>();
        }

        player_Inputs.Enable();
    }
    private void OnDisable()
    {
        if (player_Inputs != null)
        {
            player_Inputs._playerMovements.Movements.performed -= i => moveAction = i.ReadValue<Vector2>();
            player_Inputs._playerMovements.Movements.canceled -= i => moveAction = i.ReadValue<Vector2>();
        }

        player_Inputs.Disable();
    }
    #endregion

    private void Start()
    {
        _playerManager = playerManagerScript._playerManagerInstance;
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        playerMovement();
    }

    #region player movements
    void playerMovement()
    {        
        rb2d.velocity = new Vector2(moveAction.x * _playerManager.playerMoveSpeed, moveAction.y * _playerManager.playerMoveSpeed);

        //clamp nlng naten ung movement ni player para di lumagpas sa camera and hanggan middle lng ung movement para di makalapit sa spawn point ng enemy
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -8f, 0f),Mathf.Clamp(transform.position.y, -4.5f, 4.5f));
    }
    #endregion
}
