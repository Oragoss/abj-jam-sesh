using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class BossMovement : MonoBehaviour
    {
        [SerializeField] List<Transform> movePoints;
        [SerializeField] float speed, secondsBeforeRepeating = 5f;
        private Transform currentTarget;
        private Rigidbody2D rigidbody;
        
        private void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            currentTarget = movePoints[0];
            InvokeRepeating("RandomizeRange", secondsBeforeRepeating, secondsBeforeRepeating);
        }

        private void Update()
        {
            Movement();
        }

        private void RandomizeRange()
        {
            int randomRange = Random.Range(0, movePoints.Count);
            currentTarget = movePoints[randomRange];
        }
        private void Movement()
        {
            rigidbody.position = Vector2.MoveTowards(transform.position, currentTarget.position, speed * 50 * Time.deltaTime);
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}