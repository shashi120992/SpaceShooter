using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class ObjectPooler : MonoBehaviour
    {
        public static ObjectPooler Instance;
        private List<GameObject> pooledObjects = new List<GameObject>();
        private int amounttToPool = 20;

        [SerializeField] GameObject lasorPrefab;
        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }
        }

        private void Start()
        {
            for (int i = 0; i < amounttToPool; i++)
            {
                GameObject obj = Instantiate(lasorPrefab);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }

        public GameObject getPooledObject()
        {
            for(int i = 0; i < pooledObjects.Count; i++)
            {
                if(!pooledObjects[i].activeInHierarchy)
                {
                    return pooledObjects[i];
                }
            }

            return null;
        }
    }

}