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

            //Lazy way to just keep repeating until it's not the same?
            //while(randomRange == lastPositionUsed)
            //    randomRange = Random.Range(0, movePointOptions.Count);


            //TODO: Make it not use the same
            //movePointsAlreadyUsed.Add(movePointOptions[randomRange]);
            //movePoints.Clear();

            //if (movePointOptions.Count != movePointsAlreadyUsed.Count)
            //{
            //    for (int x = 0; x < movePointOptions.Count; x++)
            //    {
            //        for (int y = 0; x < movePointsAlreadyUsed.Count; y++)
            //        {
            //            if (movePointOptions[x] != movePointsAlreadyUsed[y])
            //            {
            //                movePoints.Add(movePointOptions[x]);
            //            }
            //        }
            //    }

            //}
            //else {
            //    movePointsAlreadyUsed.Clear();
            //}
        }
        private void Movement()
        {
            rigidbody.position = Vector2.MoveTowards(transform.position, currentTarget.position, speed * 50 * Time.deltaTime);
            //transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}