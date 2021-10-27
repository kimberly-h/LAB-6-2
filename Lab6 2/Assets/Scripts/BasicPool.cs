using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    private Queue<GameObject> activeObj = new Queue<GameObject>();

    public static BasicPool Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        GrowPool();
    }

    public GameObject getRandomPool()
    {
        if (activeObj.Count == 0)
            GrowPool();

        var instance = activeObj.Dequeue();
        instance.SetActive(true);
        return instance;
    }

    private void GrowPool()
    {
        for (int i = 0; i < 10; i++)
        {
            var addInstance = Instantiate(prefab);
            addInstance.transform.SetParent(transform);
            AddToPool(addInstance);
        }
    }

    public void AddToPool(GameObject instance)
    {
        instance.SetActive(false);
        activeObj.Enqueue(instance);
    }
}