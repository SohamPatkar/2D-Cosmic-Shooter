using CosmicCuration.Bullets;
using CosmicCuration.Enemy;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool
{
    private EnemyScriptableObject enemyScriptableObject;
    private EnemyView enemyView;
    public List<PooledEnemy> pooledEnemies = new List<PooledEnemy>();

    public EnemyPool(EnemyScriptableObject enemyScriptableObject, EnemyView enemyView)
    {
        this.enemyScriptableObject = enemyScriptableObject;
        this.enemyView = enemyView;
    }

    public EnemyController GetEnemy()
    {
        if (pooledEnemies.Count > 0)
        {
            PooledEnemy pooledEnemy = pooledEnemies.Find(x => !x.isUsed);

            if (pooledEnemy != null)
            {
                pooledEnemy.isUsed = true;
                return pooledEnemy.enemyController;
            }
        }

        return CreateEnemy();
    }

    private EnemyController CreateEnemy()
    {
        PooledEnemy pooledEnemy = new PooledEnemy();
        pooledEnemy.enemyController = new EnemyController(enemyView, enemyScriptableObject.enemyData);
        pooledEnemy.isUsed = true;
        pooledEnemies.Add(pooledEnemy);
        return pooledEnemy.enemyController;
    }

    public void ReturnEnemyToPool(EnemyController returnEnemy)
    {
        PooledEnemy enemy = pooledEnemies.Find(item => item.enemyController.Equals(returnEnemy));
        enemy.isUsed = false;
    }

    public class PooledEnemy
    {
        public EnemyController enemyController;
        public bool isUsed;
    }
}
