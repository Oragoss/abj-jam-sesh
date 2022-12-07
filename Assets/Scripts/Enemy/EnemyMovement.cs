using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy
{

    [RequireComponent(typeof(EnemyCombat))]
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] int speed = 5;

        //TODO: Only find the player through trigger
        GameObject player;

        Rigidbody2D rigidbody;

        bool canMove;

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            //transform.LookAt(player.transform);
        }

        private void FixedUpdate()
        {
            //Move to onTrigger Stay
            player = GameObject.FindGameObjectWithTag("Player");
            if (canMove)
            {
                rigidbody.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, transform.position.y), speed * Time.deltaTime);
            }


            //Tried this one: https://forum.unity.com/threads/moving-an-enemy-charactercontroller-toward-player.1146479/
            //Tried this one: https://stackoverflow.com/questions/30827559/how-to-make-enemies-turn-and-move-towards-player-when-near-unity3d
            //Vector2 move = Vector2.MoveTowards(player.transform.position, gameObject.transform.position, 0.5f);
            //if (move != Vector2.zero)
            //{
            //    gameObject.transform.forward = move;
            //}
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                canMove = true;
            }
        }

        private void OnTriggerStay2D(Collider2D collider)
        {

        }
    }
}