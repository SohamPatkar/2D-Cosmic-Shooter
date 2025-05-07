using UnityEngine;
using System.Collections.Generic;

namespace CosmicCuration.Bullets
{
    public class BulletPool
    {
        private BulletView bulletView;
        private BulletScriptableObject bulletScriptableObject;
        public List<PooledBullets> pooledBullets = new List<PooledBullets>();

        public BulletPool(BulletView bulletView, BulletScriptableObject bulletScriptableObject)
        {
            this.bulletView = bulletView;
            this.bulletScriptableObject = bulletScriptableObject;
        }

        public class PooledBullets
        {
            public BulletController bulletController;
            public bool isUsed;
        }
    }
}

