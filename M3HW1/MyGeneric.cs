// <copyright file="MyGeneric.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// My own generic.
/// </summary>
/// <typeparam name="T">The type.</typeparam>
internal class MyGeneric<T>
    where T : IComparable<T>
{
    private T[] data;
    private int size;

    /// <summary>
    /// Initializes a new instance of the <see cref="MyGeneric{T}"/> class.
    /// </summary>
    /// <param name="yourData">Array of your data.</param>
    public MyGeneric(T[] yourData)
    {
        this.data = yourData;
    }

    /// <summary>
    /// Method for adding data to my generic.
    /// </summary>
    /// <param name="yourData">.</param>
    public void Add(T yourData)
    {
        int i = this.data.Length;
        Array.Resize<T>(ref this.data, this.data.Length + 1);
        this.data[i] = yourData;
    }

    /// <summary>
    /// Method for sorting data in my generic.
    /// </summary>
    /// <returns>Array of data.</returns>
    public T[] Sort()
    {
        Array.Sort(this.data);

        return this.data;
    }

    /// <summary>
    /// Method for removing item at index.
    /// </summary>
    /// <param name="index">Index of removing item.</param>
    /// <returns>Array of data.</returns>
    public T[] RemoveAt(int index)
    {
        if (this.data.Length == 0)
        {
            Console.WriteLine("Невозможно удалить элемент по указаному индексу");
            return null;
        }

        T[] dest = new T[this.data.Length - 1];
        if (index < 0 || index >= this.data.Length)
        {
            Console.WriteLine("Невозможно удалить элемент по указаному индексу");
            return dest;
        }

        if (index > 0)
        {
            Array.Copy(this.data, 0, dest, 0, index);
        }

        if (index < this.data.Length - 1)
        {
            Array.Copy(this.data, index + 1, dest, index, this.data.Length - index - 1);
        }

        return dest;
    }

    /// <summary>
    /// Method for adding collection to my generic.
    /// </summary>
    /// <returns>Enumerator.</returns>
    public IEnumerator GetEnumerator()
    {
        for (int index = 0; index < this.data.Length; index++)
        {
            yield return this.data[index];
        }
    }

    /// <summary>
    /// Method for adding collection to my generic.
    /// </summary>
    /// <param name="collection">.</param>
    public void AddRange(IEnumerable<T> collection)
    {
        var newArray = collection.ToArray();
        Array.Resize<T>(ref this.data, this.data.Length + newArray.Length);
        for (int i = this.data.Length - newArray.Length, j = 0; i < this.data.Length; i++, j++)
        {
            this.data[i] = newArray[j];
        }
    }

    /// <summary>
    /// Method for removing item.
    /// </summary>
    /// <param name="item">.</param>
    /// <returns>True, if removing is successful;false, if not.</returns>
    public bool Remove(T item)
    {
        this.size = this.data.Length;
        var index = Array.IndexOf(this.data, item, 0, this.size);
        if (this.data == null || index < 0 || index == this.size)
        {
            return false;
        }

        var newArray = new T[this.data.Length - 1];
        Array.Copy(this.data, 0, newArray, 0, index);
        Array.Copy(this.data, index + 1, newArray, index, this.data.Length - index - 1);
        this.data = newArray;
        return true;
    }
}
