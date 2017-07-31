using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generics
{
    public class CustomList<T>
    {
        public T[] list;
        private bool itemRemoved;
        public int amount { get; private set; }
        // Default constructor
        public CustomList() { amount = 0; }
        // gameObjects[0]
        public T this[int index]
        {
            get
            {
                return list[index];
            }
            set
            {
                list[index] = value;
            }
        }

        public void Add(T item)
        {
            // Create a new array of amount + 1
            T[] cache = new T[amount + 1];
            // Check if the list has been initialized
            if (list != null)
            {
                // Copy all existing items to new array
                for (int i = 0; i < list.Length; i++)
                {
                    cache[i] = list[i];
                }
            }
            // Place new item at end index
            cache[amount] = item;
            // Replace old array with new array
            list = cache;
            // Increment amount
            amount++;
        }

        public void Remove(T item)
        {
            // Create a new array of amount - 1
            T[] cache = new T[amount - 1];
            // Set boolean to false
            itemRemoved = false;
            // Check if the list has been initialized
            if (list != null)
            {
                // Copy all existing items to new array except removed item
                for (int i = 0; i < list.Length; i++)
                {
                    if (EqualityComparer<T>.Default.Equals(list[i], item))
                    {
                        itemRemoved = true;
                    }
                    else
                    {
                        cache[i] = itemRemoved ? list[i - 1] : list[i];
                    }
                }
            }
            // Replace old array with new array
            list = cache;
            // decrease amount
            amount--;
        }

        public void Clear()
        {
            // list equals nothing
            list = null;
            // amount = 0
            amount = 0;
        }
    }
}