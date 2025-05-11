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

        return CreateItem();
    }

    private T CreateItem()
    {
        throw new NotImplementedException("Not Implemented the create item");
    }

    public class PooledItem<T>
    {
        public T Item;
        public bool isUsed;
    }
}
