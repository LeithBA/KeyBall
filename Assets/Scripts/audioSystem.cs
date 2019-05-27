using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioSystem : MonoBehaviour
{
    private static audioSystem _instance;
    public static audioSystem Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
