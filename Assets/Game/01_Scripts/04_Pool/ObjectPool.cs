using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    public int initialPoolSize = 10;

    private List<GameObject> pool = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            CreateNewObject();
        }
    }

    private GameObject CreateNewObject()
    {
        GameObject obj = Instantiate(prefab);
        obj.SetActive(false);
        pool.Add(obj);
        return obj;
    }

    public GameObject GetObject()
    {
        foreach (var obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        return CreateNewObject();
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
    }
}
