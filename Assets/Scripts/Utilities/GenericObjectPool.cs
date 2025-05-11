using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericObjectPool<T> where T : class
{
    private List<PooledItem<T>> pooledItems = new List<PooledItem<T>>();

    public T GetItem()
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
        return pooledItem.Item;
    }

    public T CreateItem()
    {
        throw new NotImplementedException("Please use create Item");
    }

    public class PooledItem<T>
    {
        public T Item;
        public bool isUsed;
    }
}
