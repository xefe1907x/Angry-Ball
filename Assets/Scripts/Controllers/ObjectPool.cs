using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
    }

    public List<Pool> pools;
    public int poolSize;
    public Dictionary<string, Queue<GameObject>> poolDictionary = new Dictionary<string, Queue<GameObject>>();
    
    GameObject targetParent;
    GameObject pivot;

    Vector2 pivotPosition;

    string currentBallTag;

    #region Singleton

    public static ObjectPool Instance;

    void Awake()
    {
        if (Instance != null)
            Destroy(this);
        
        Instance = this;
    }

    #endregion

    void Start()
    {
        targetParent = GameObject.FindGameObjectWithTag("ObjectPool");
        pivot = GameObject.FindGameObjectWithTag("Pivot");
        pivotPosition = pivot.transform.position;

        BallController.ballTagSelected += CreatingPoolWithQueue;
    }

    void CreatingPoolWithQueue(string ballTag)
    {
        foreach (var pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < poolSize; i++)
            {
                if (pool.tag == ballTag)
                {
                    GameObject obj = Instantiate(pool.prefab);
                    obj.transform.SetParent(targetParent.transform);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }
            }
            
            poolDictionary.Add(pool.tag, objectPool);
        }

        currentBallTag = ballTag;
    }

    public GameObject SpawnBallFromPool()
    {
        GameObject spawnBall = poolDictionary[currentBallTag].Dequeue();
        spawnBall.SetActive(true);
        spawnBall.transform.position = pivotPosition;
        spawnBall.transform.rotation = Quaternion.identity;

        return spawnBall;
    }

    void OnDisable()
    {
        BallController.ballTagSelected -= CreatingPoolWithQueue;
    }
}
