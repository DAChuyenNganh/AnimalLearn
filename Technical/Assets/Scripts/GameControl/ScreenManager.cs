using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public enum _ScreenType
{
    MENU = 1,
    MODE1 = 2,
    MODE2 = 3
}

[System.Serializable]
public class ScreenConfig
{
    public GameObject _objScreen;
    public _ScreenType _type;
}
public class ScreenManager : MonoSingleton<ScreenManager> {
    public List<ScreenConfig> listScreen = new List<ScreenConfig>();
    private Dictionary<_ScreenType, GameObject> dicScreen = new Dictionary<_ScreenType,GameObject>();

    public GameObject currentScreen;
    void Awake()
    {
        InitDictionary(); 
    }
	// Use this for initialization
	void Start () {
        ShowScreenByType(_ScreenType.MODE1);
	}

    private void InitDictionary()
    {
        foreach(ScreenConfig var in listScreen)
        {
            dicScreen.Add(var._type, var._objScreen);
        }
    }
	
    private GameObject GetScreenByType(_ScreenType _type)
    {
        if(dicScreen.ContainsKey(_type))
        {
            return dicScreen[_type];
        }

        return null;
    }

    private void DisableAllScreen()
    {
        foreach(GameObject var in dicScreen.Values)
        {
            var.SetActive(false);
        }
    }

    public void ShowScreenByType(_ScreenType _type)
    {
        DisableAllScreen();
        currentScreen = GetScreenByType(_type);
        if(currentScreen)
        {
            currentScreen.SetActive(true);
        }
    }


	// Update is called once per frame
	void Update () {
	
	}
}
