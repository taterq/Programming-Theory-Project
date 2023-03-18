using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public GameObject[] prefabs;
    public enum SUPERHERO_LIST
    {
        UNKNOWN=-1,
        BATMAN=0,
        SUPERMAN=1
    }
    public MainManager instance 
    { 
        get { return _instance; }
        set { _instance = value; }
    }
    static private MainManager _instance = null;
    public SUPERHERO_LIST playerChar = SUPERHERO_LIST.UNKNOWN;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public GameObject GetPlayerInstance()
    {
        return Instantiate(prefabs[(int)playerChar]);
    }

}
