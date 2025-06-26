using CosmicCuration.Bullets;
using CosmicCuration.Enemy;
using CosmicCuration.Utilities;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Enemy
{
    public class EnemyPool : GenericObjectPool<EnemyController>
    {
        private EnemyScriptableObject enemyScriptableObject;
        private EnemyView enemyView;

        public EnemyPool(EnemyScriptableObject enemyScriptableObject, EnemyView enemyView)
        {
            this.enemyScriptableObject = enemyScriptableObject;
            this.enemyView = enemyView;
        }

        public EnemyController GetEnemy() => GetItem();

        protected override EnemyController CreateItem()
        {
            return new EnemyController(enemyView, enemyScriptableObject.enemyData);
        }

    }

}
