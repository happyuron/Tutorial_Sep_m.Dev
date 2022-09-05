using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public static T Instance;

    protected virtual void Init()
    {
        if (Instance == null)
        {
            Instance = GetComponent<T>();
        }
        if (FindObjectsOfType<T>().Length > 1)
            Destroy(gameObject);
    }

    protected virtual void Awake()
    {
        Init();
    }

}
