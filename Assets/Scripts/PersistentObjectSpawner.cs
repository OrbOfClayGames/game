using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Persist
{
    public class PersistentObjectSpawner : MonoBehaviour
    {
        [SerializeField] GameObject persistentObjectPrefab;
        private static bool hasSpawned = false;

        private void Awake()
        {
            if (hasSpawned)
                return;
            SpawnPersistentObjects();
            hasSpawned = true;
        }

        private void SpawnPersistentObjects()
        {
            GameObject persistentObject = Instantiate(persistentObjectPrefab);
            DontDestroyOnLoad(persistentObject);
        }
    }
}

