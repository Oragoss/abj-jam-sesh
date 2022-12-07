using Assets.Scripts.Player;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyCombat : MonoBehaviour
    {
        [SerializeField] int health = 10;
        [SerializeField] int attackDamage = 5;
        [SerializeField] int detectionRadius = 15;

        CircleCollider2D detectCollider;
        PlayerCombat player;
        float attackRate = 2;

        void Awake()
        {
            detectCollider = gameObject.AddComponent<CircleCollider2D>();
            detectCollider.radius = detectionRadius;
            detectCollider.isTrigger = true;
        }

        // Update is called once per frame
        void Update()
        {
            if(health <= 0)
            {
                Death();
            }
        }

        /**
         * Damaging??
         */

        public int GetAttackDamage()
        {
            return attackDamage;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                player.DamagePlayer(attackDamage);
            }
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                player = collider.GetComponent<PlayerCombat>();
            }
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
            if (collider)
            {
                if (collider.gameObject.CompareTag("Player"))
                {
                    player = null;
                }
            }
        }

        /**
         * Being Damaged
         */

        public void DamageEnemy(int damage)
        {
            health -= damage;
            StartCoroutine(PlayDamageAnimation());
        }

        private void Death()
        {
            Destroy(gameObject);
        }

        IEnumerator PlayDamageAnimation()
        {
            SpriteRenderer sprRend = gameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;
            sprRend.color = new Color(0.0f, 0.9f, 0.9f, 1.0f);
            
            yield return new WaitForSeconds(1);
            sprRend.color = new Color(1f, 0f, 0f, 1.0f);
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}