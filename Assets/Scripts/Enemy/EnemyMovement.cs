using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy
{

    [RequireComponent(typeof(EnemyCombat))]
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] int speed;
        
        //TODO: Only find the player through trigger
        [SerializeField] GameObject player;

        Rigidbody2D rigidbody;

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            //transform.LookAt(player.transform);
        }

        private void FixedUpdate()
        {
            //Try https://docs.unity3d.com/ScriptReference/Vector2.MoveTowards.html
            //Try https://gamedev.stackexchange.com/questions/112105/enemy-moving-towards-player-in-a-2d-setting
            rigidbody.velocity = new Vector2(-player.transform.position.x * speed * Time.deltaTime, rigidbody.velocity.y);


            //Tried this one: https://forum.unity.com/threads/moving-an-enemy-charactercontroller-toward-player.1146479/
            //Tried this one: https://stackoverflow.com/questions/30827559/how-to-make-enemies-turn-and-move-towards-player-when-near-unity3d
            //Vector2 move = Vector2.MoveTowards(player.transform.position, gameObject.transform.position, 0.5f);
            //if (move != Vector2.zero)
            //{
            //    gameObject.transform.forward = move;
            //}
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            
        }
    }
}