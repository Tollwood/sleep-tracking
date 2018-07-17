using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class AbstracListController<T> : MonoBehaviour
{
    protected Transform container;
    protected int currentSize = -1;
    protected List<T> elements = new List<T>();

    protected void clearList()
    {
        foreach (Transform child in container)
        {
            Destroy(child.gameObject);
        }
    }

    public void Update()
    {
        if (currentSize == elements.Count)
        {
            return;
        }
        refreshList();
    }

    protected void refreshList()
    {
        clearList();
        foreach (T el in elements)
        {
            addElement(el);
        }
        currentSize = elements.Count;
    }

    protected abstract void addElement(T element);
}
