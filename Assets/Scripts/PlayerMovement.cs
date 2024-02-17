using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //system var
    private _playerInputs player_Inputs;
    private Vector2 moveAction;

    //public var
    private Rigidbody2D rb2d;
    [SerializeField] float moveSpeed = 10f;

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
        rb2d = GetComponentInChildren<Rigidbody2D>();
    }

    private void Update()
    {
        playerMovement();
    }

    #region player movements
    void playerMovement()
    {
        
        rb2d.velocity = new Vector2(moveAction.x * moveSpeed, moveAction.y * moveSpeed);

       //clamp nlng naten ung movement ni player para di sya pwede mag close sa pinka righ side -pat
    }
    #endregion
}
