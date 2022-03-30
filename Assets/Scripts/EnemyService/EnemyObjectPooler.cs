﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyObjectPooler : MonoBehaviour
    {
        [System.Serializable]
        public class Pool
        {
            public string tag;
            public GameObject prefab;
            public int size;
        }


        #region SingleTon
        public static EnemyObjectPooler Instance;
        private void Awake()
        {
            Instance = this;
        }
        #endregion

        public List<Pool> pools;
        public Dictionary<string, Queue<GameObject>> poolDictionary;

        private void Start()
        {
            poolDictionary = new Dictionary<string, Queue<GameObject>>();
            foreach (Pool pool in pools)
            {
                Queue<GameObject> objectPool = new Queue<GameObject>();
                for (int i = 0; i < pool.size; i++)
                {
                    GameObject obj = Instantiate(pool.prefab);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }

                poolDictionary.Add(pool.tag, objectPool);
            }
        }

        public GameObject spawnFromPool(string tag, Vector3 position, Quaternion rotation)
        {
            if (!poolDictionary.ContainsKey(tag))
            {
                Debug.LogWarning("Pool With Tag " + tag + " does'nt exist");
                return null;
            }

            GameObject objToSpawn = poolDictionary[tag].Dequeue();
            objToSpawn.SetActive(true);
            objToSpawn.transform.position = position;
            objToSpawn.transform.rotation = rotation;

            poolDictionary[tag].Enqueue(objToSpawn);
            return objToSpawn;
        }

    }
}