using UnityEngine;
using System.Collections;

public class ResourceManager : MonoSingleton<ResourceManager> {
    public Sprite[] listSpritetest;
	// Use this for initialization
	void Start () {
        listSpritetest = LoadResourcesFromName("lion");
	}

    public Sprite[] LoadResourcesFromName(string animalName)
    {
        Sprite[] listSprite;

        if(animalName =="")
        {
            return null;
        }
        listSprite = Resources.LoadAll<Sprite>("imgAnimal/"+animalName);
        return listSprite;
    }
	// Update is called once per frame
	void Update () {
	
	}
}
