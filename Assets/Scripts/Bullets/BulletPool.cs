using UnityEngine;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using CosmicCuration.Utilities;

namespace CosmicCuration.Bullets
{
    public class BulletPool : GenericObjectPool<BulletController>
    {
        private BulletView bulletView;
        private BulletScriptableObject bulletScriptableObject;
        public BulletPool(BulletView bulletView, BulletScriptableObject bulletScriptableObject)
        {
            this.bulletView = bulletView;
            this.bulletScriptableObject = bulletScriptableObject;
        }

        public BulletController GetBullet()
        {
            return GetItem();
        }


        protected override BulletController CreateItem()
        {
            return new BulletController(bulletView, bulletScriptableObject);
        }

    }
}

