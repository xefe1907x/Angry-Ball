using UnityEngine;

[DefaultExecutionOrder(1000)]
public class BallSpawner : MonoBehaviour
{
    bool canSpawn = true;

    float newBallSpawnTime = 3f;
    void Start()
    {
        SpawnBall();
        HealthController.healthBecomeZero += NoMoreSpawn;
        BallHandler.ballIsThrown += SpawnNewBall;
    }

    void SpawnNewBall()
    {
        Invoke("SpawnBall", newBallSpawnTime);
    }
    void SpawnBall()
    {
        if (canSpawn)
        {
            ObjectPool.Instance.SpawnBallFromPool();
        }
    }

    void NoMoreSpawn()
    {
        canSpawn = false;
    }

    void OnDisable()
    {
        HealthController.healthBecomeZero -= NoMoreSpawn;
        BallHandler.ballIsThrown -= SpawnNewBall;
    }
}
