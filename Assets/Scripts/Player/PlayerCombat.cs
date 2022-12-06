using Assets.Scripts.Enemy;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Player
{
    public class PlayerCombat : MonoBehaviour
    {
        //https://dennisse-pd.medium.com/how-to-create-a-cooldown-system-in-unity-4156f3a842ae????

        [SerializeField] LayerMask enemyLayer;
        [SerializeField] float meleeAttackCooldown = 0.5f;
        [SerializeField] int meleeDamage = 5;
        [SerializeField] int health = 25;

        CapsuleCollider2D attackCollider;
        EnemyCombat enemy;

        float attackRate = 2;
       

        void Awake()
        {
            attackCollider = gameObject.AddComponent<CapsuleCollider2D>();
            attackCollider.size = new Vector2(5f, 5f);
            attackCollider.isTrigger = true;
        }

        private void FixedUpdate()
        {
            attackRate += Time.deltaTime;

            if (Input.GetButton("Fire1") && attackRate > meleeAttackCooldown)
            {
                attackRate = 0;
                MeleeAttack();
            }

            if(health <= 0)
            {
                Debug.Log("TODO: Player needs to die and game over");
            }
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.CompareTag("Enemy"))
            {
                enemy = collider.GetComponent<EnemyCombat>();
            }
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
            if(collider)
            {
                if (collider.gameObject.CompareTag("Enemy"))
                {
                    enemy = null;
                }
            }
        }

        //private void OnCollisionEnter2D(Collision collision)
        //{
        //    if (collision.gameObject.CompareTag("Enemy"))
        //    {
        //        DamagePlayer(enemy.GetAttackDamage());
        //    }
        //}


        public void DamagePlayer(int amount)
        {
            health -= amount;
        }

        private void MeleeAttack()
        {
            if (enemy != null)
            {
                enemy.DamageEnemy(meleeDamage);
            }
        }
    }
}