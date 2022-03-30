using System.Collections;
using UnityEngine;

namespace Assets.Scripts.EnemyService
{
    public class EnemyShooting : MonoBehaviour
    {

        public GameObject enemy;
        public GameObject enemyprojectile;
        public GameObject enemyprojctileClone;
        

        private void Update()
        {
            fireEnemyProjectile();
        }
        private void fireEnemyProjectile()
        {
            if (Random.Range(0f, 500f) < 1)
            {
                enemyprojctileClone = Instantiate(enemyprojectile, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.6f, 0), enemy.transform.rotation) as GameObject;
            }
        }
    }
}