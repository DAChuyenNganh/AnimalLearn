using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ProfileImageManager : MonoBehaviour {
    private Sprite[] arraySpriteAnimal;

    public Transform contentImg;
    public Transform txtNoTrackable;
    // Use this for initialization
    void Start () {
	    
	}

    [ContextMenu("test")]
    public void Test()
    {
        SetImageFromResourcesByName("lion");
    }

    public void ShowProfileImage()
    {
        string animalName = GameController.Instance.GetNameAnimalCurrent();
        if(animalName == "")
        {
            contentImg.gameObject.SetActive(false);
            txtNoTrackable.gameObject.SetActive(true);
        }
        else
        {
            contentImg.gameObject.SetActive(true);
            txtNoTrackable.gameObject.SetActive(false);
            SetImageFromResourcesByName(animalName);
        }
    }

    public void SetImageFromResourcesByName(string _animalName)
    {
        arraySpriteAnimal = LoadResourcesFromName(_animalName);

        for(int i=0;i<arraySpriteAnimal.Length;i++)
        {
            GameObject objImage = ManagerObject.Instance.SpawnObjectByType(ObjectType.IMG_ANIMAL, PoolName.UI);
            objImage.transform.localScale = Vector3.one;

            objImage.GetComponent<Image>().sprite = arraySpriteAnimal[i];
        }
    }

    public Sprite[] LoadResourcesFromName(string animalName)
    {
        Sprite[] listSprite;

        if (animalName == "")
        {
            return null;
        }
        listSprite = Resources.LoadAll<Sprite>("imgAnimal/" + animalName);
        return listSprite;
    }
	// Update is called once per frame
	void Update () {
	
	}
}
