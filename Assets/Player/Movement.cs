using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour {
    
    // Components
    Rigidbody rb;
    Animator animator;

    // Input direction read
    Vector3 inputDirection;

    // Speed of the player
    [SerializeField] float speed = 5;
    // 3D model of the player
    [SerializeField] GameObject model;

    //Reference to player stats
    Stats playerStats;


    void Awake() {
        // Initialization
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        inputDirection = new Vector3();
        playerStats = GetComponent<Stats>();
        playerStats.onStatsChanged.AddListener(UpdateSpeed);
        UpdateSpeed();
    }
    
    // Updates the speed of the player when their speed stat is affected
    void UpdateSpeed() {
        speed = playerStats.Speed;
    }

    void Update() {
        // Playing the movement animation
        animator.SetFloat("Speed", rb.velocity.magnitude);

        // If the player is moving, sets the model's rotation to match the movement direction.
        if(rb.velocity.normalized != Vector3.zero) {
            // TODO : Reasearch that shit
            Quaternion toRotation = Quaternion.LookRotation(rb.velocity.normalized, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(model.transform.rotation, toRotation, 720 * Time.deltaTime);
        }
    }

    void FixedUpdate() {
        // Sets the velocity of the rigidbody depending on the input's direction and speed;
        rb.velocity = inputDirection * speed;
    }

	// Reads direction input
    public void MovePlayer(InputAction.CallbackContext context) {
        Vector2 readValue = context.ReadValue<Vector2>();

        inputDirection.x = readValue.x;
        inputDirection.z = readValue.y;
    }
}
