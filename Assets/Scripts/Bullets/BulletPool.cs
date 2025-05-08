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

        public void ReturnToPool(BulletController returnedBullet)
        {
            PooledBullets pooledbullet = pooledBullets.Find(item => item.bulletController.Equals(returnedBullet));
            pooledbullet.isUsed = false;
        }

        public BulletController GetBullet()
        {
            if (pooledBullets.Count > 0)
            {
                PooledBullets pooledBullet = pooledBullets.Find(bullet => !bullet.isUsed);

                if (pooledBullet != null)
                {
                    pooledBullet.isUsed = true;
                    return pooledBullet.bulletController;
                }
            }

            return CreateNewPooledBullet();
        }

        private BulletController CreateNewPooledBullet()
        {
            PooledBullets pooledBullet = new PooledBullets();
            pooledBullet.bulletController = new BulletController(bulletView, bulletScriptableObject);
            pooledBullet.isUsed = true;
            pooledBullets.Add(pooledBullet);
            return pooledBullet.bulletController;
        }

        public class PooledBullets
        {
            public BulletController bulletController;
            public bool isUsed;
        }
    }
}

