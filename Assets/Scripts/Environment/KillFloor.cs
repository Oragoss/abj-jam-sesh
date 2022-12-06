using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Environment
{
    public class KillFloor : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject != null)
            {
                Destroy(collider.gameObject);
            }
        }

    }
}