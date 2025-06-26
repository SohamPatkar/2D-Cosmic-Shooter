using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Utilities
{
    public class GenericObjectPool<T> where T : class
    {
        private List<PooledItem<T>> pooledItems = new List<PooledItem<T>>();

        protected T GetItem()
        {
            if (pooledItems.Count > 0)
            {
                PooledItem<T> pooledItem = pooledItems.Find(item => !item.isUsed);

                if (pooledItem != null)
                {
                    pooledItem.isUsed = true;
                    return pooledItem.Item;
                }
            }

            return CreatePooledItem();
        }

        private T CreatePooledItem()
        {
            PooledItem<T> pooledItem = new PooledItem<T>();
            pooledItem.Item = CreateItem();
            pooledItem.isUsed = true;
            pooledItems.Add(pooledItem);
            return pooledItem.Item;
        }

        protected virtual T CreateItem()
        {
            throw new NotImplementedException("Please use create Item");
        }

        public void ReturnItem(T item)
        {
            PooledItem<T> pooledItem = pooledItems.Find(item => item.Equals(item.Item));
            pooledItem.isUsed = false;
        }

        public class PooledItem<T>
        {
            public T Item;
            public bool isUsed;
        }
    }

}
