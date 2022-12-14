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

        bool canMove = true;
        BoxCollider2D playerCollider;
        private Rigidbody2D _playerRigidbody;

        public void EnablePlayerMovement() => canMove = true;
        public void DisablePlayerMovement() => canMove = false;

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
            if(canMove)
                _playerRigidbody.velocity = new Vector2(horizontalInput * playerSpeed, _playerRigidbody.velocity.y);

            if (Input.GetButton("Jump") && IsGrounded())
                Jump(horizontalInput);
        }
        private void Jump(float horizontalInput) => _playerRigidbody.velocity = new Vector2(horizontalInput * playerSpeed, jumpPower);

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Wall"))
            {
                DisablePlayerMovement();
                //_playerRigidbody.velocity = new Vector2(0, 0);
            }

            if (collision.gameObject.CompareTag("Ground"))
            {
                EnablePlayerMovement();
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Wall"))
            {
                EnablePlayerMovement();
            }

            //if (collision.gameObject.CompareTag("Ground"))
            //{
            //    DisablePlayerMovement();
            //}
        }



        /// <summary>
        /// Determine if the player is touching the ground by checking if the player collider is touching an object that is a part of the
        /// grounded layer. It's probably best to make anything that has a layer also have a tag of the same name but layers seem to be the go to for 2D instead of tags.
        /// </summary>
        /// Stack Overflow: https://stackoverflow.com/questions/38191659/unity-physics2d-raycast-hits-itself
        /// <returns></returns>
        private bool IsGrounded()
        {
            bool grounded = Physics2D.OverlapCircle(playerCollider.transform.position, 1, groundLayer);
            return grounded;
        }
    }
}