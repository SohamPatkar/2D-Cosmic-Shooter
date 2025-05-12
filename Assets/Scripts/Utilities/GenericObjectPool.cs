using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace CosmicCuration.Utilities
{
    public class GenericObjectPool<T> where T : class
    {
        private List<PooledItem<T>> pooledItems = new List<PooledItem<T>>();

        protected virtual T GetItem<U>() where U : T
        {
            if (pooledItems.Count > 0)
            {
                PooledItem<T> pooledItem = pooledItems.Find(item => !item.isUsed && item.Item is U);

                if (pooledItem != null)
                {
                    pooledItem.isUsed = true;
                    return pooledItem.Item;
                }
            }

            return CreatePooledItem<U>();
        }

        private T CreatePooledItem<U>() where U : T
        {
            PooledItem<T> newItem = new PooledItem<T>();
            newItem.Item = CreateItem<U>();
            newItem.isUsed = true;
            pooledItems.Add(newItem);
            return newItem.Item;
        }

        protected virtual T CreateItem<U>() where U : T
        {
            throw new NotImplementedException("Please use create Item");
        }

        public void ReturnItem(T item)
        {
            PooledItem<T> pooledItem = pooledItems.Find(item => item.Equals(item));
            pooledItem.isUsed = false;
        }

        public class PooledItem<T>
        {
            public T Item;
            public bool isUsed;
        }
    }

}
