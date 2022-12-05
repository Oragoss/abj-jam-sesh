using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float playerSpeed = 5.0f;
        [SerializeField] private float jumpPower = 5.0f;
        [SerializeField] LayerMask groundLayer;
        BoxCollider2D playerCollider;
        bool grounded;

        private Rigidbody2D _playerRigidbody;

        private void Start()
        {
            _playerRigidbody = GetComponent<Rigidbody2D>();
            if (_playerRigidbody == null)
            {
                Debug.LogError("Player is missing a Rigidbody2D component");
            }
            playerCollider = gameObject.GetComponent<BoxCollider2D>();
        }
        private void Update()
        {
            MovePlayer();
        }
        private void MovePlayer()
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            _playerRigidbody.velocity = new Vector2(horizontalInput * playerSpeed, _playerRigidbody.velocity.y);

            if (Input.GetButton("Jump") && IsGrounded())
                Jump(horizontalInput);
        }
        private void Jump(float horizontalInput) => _playerRigidbody.velocity = new Vector2(horizontalInput * playerSpeed, jumpPower);

        /// <summary>
        /// Determine if the player is touching the ground by checking if the player collider is touching an object that is a part of the
        /// grounded layer. It's probably best to make anything that has a layer also have a tag of the same name but layers seem to be the go to for 2D instead of tags.
        /// </summary>
        /// Stack Overflow: https://stackoverflow.com/questions/38191659/unity-physics2d-raycast-hits-itself
        /// <returns></returns>
        private bool IsGrounded()
        {
            grounded = Physics2D.OverlapCircle(playerCollider.transform.position, 1, groundLayer);
            return grounded;
        }
    }
}