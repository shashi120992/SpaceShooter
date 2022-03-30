using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        public Transform[] spawnPoints;
        public GameObject Enemy;
        public float timeBetweenWaves = 1f;
        EnemyObjectPooler enemyObjectPooler;

        private float timeToSpawn = 2f;
        string[] m_Tag = new string[] { "Enemy", "Enemy2", "Powerup1", "Powerup2" };

        private void Start()
        {
            enemyObjectPooler = EnemyObjectPooler.Instance;
        }

        private void Update()
        {
            if(Time.time >= timeToSpawn)
            {
                spawnEnemy();
                timeToSpawn = Time.time + timeBetweenWaves;
            }
           
        }

        private void spawnEnemy()
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);   
            string randomTag = m_Tag[Random.Range(0, m_Tag.Length)];
            enemyObjectPooler.spawnFromPool(randomTag, spawnPoints[randomIndex].position, Quaternion.identity);
        }

        /*private void spawnEnemy()
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                if (randomIndex != i)
                {
                    //Instantiate(Enemy, spawnPoints[i].position, Quaternion.identity);
                    string randomTag = m_Tag[Random.Range(0, m_Tag.Length)];
                    enemyObjectPooler.spawnFromPool(randomTag, spawnPoints[i].position, Quaternion.identity);

                }
            }
        }
        */
    }
}