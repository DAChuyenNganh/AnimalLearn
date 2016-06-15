using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Holoville.HOTween;

public class GameController : MonoSingleton<GameController> {
    public GameObject currObjectTracked; // object nhan dien duoc hien tai
    public GameObject currImgTargetParent;

    public Camera cameraAR;
    public GameObject objCameraAR;
    public GameObject imgTargetMode1;
    public GameObject imgTargetMode2;

    public Text txtNameAnimal;

    private UiShowProfile uiProfile;
	// Use this for initialization
	void Start () {
        GoToMode1();
        uiProfile = FindObjectOfType(typeof(UiShowProfile)) as UiShowProfile;
	}

    public void GoToMode1()
    {
        ScreenManager.Instance.ShowScreenByType(_ScreenType.MODE1);
        if(cameraAR)
        {
            cameraAR.enabled = true;
        }
        if(imgTargetMode1 && !imgTargetMode1.activeInHierarchy)
        {
            imgTargetMode1.SetActive(true);
        }

        if(objCameraAR)
        {
            objCameraAR.SetActive(true);
        }
    }

    public void BackToMode1()
    {
        GoToMode1();
        if(currObjectTracked && currImgTargetParent)
        {
            currObjectTracked.transform.SetParent(currImgTargetParent.transform, false);
            currObjectTracked.transform.localEulerAngles = Vector3.zero;
            currObjectTracked.SetActive(false);
        }
    }
	
    public void GoToMode2()
    {
        ScreenManager.Instance.ShowScreenByType(_ScreenType.MODE2);
        if(cameraAR)
        {
            //cameraAR.enabled = false;
            objCameraAR.SetActive(false);
        }
        if(imgTargetMode1 && imgTargetMode1.activeInHierarchy)
        {
            imgTargetMode1.SetActive(false);
        }
        if (currObjectTracked)
        {
            currImgTargetParent = currObjectTracked.transform.parent.gameObject;
        }
    }

	// Update is called once per frame
	void Update () {
	    if(currObjectTracked)
        {
            if(txtNameAnimal)
            {
                txtNameAnimal.text = currObjectTracked.transform.GetChild(0).gameObject.name;
            }
        }
	}

    /// <summary>
    /// show thong tin cua animal
    /// </summary>
    [ContextMenu("test")]
    public void ShowName()
    {
        //uiProfile.StartMove();  // effect move
    }

    //public void ShowImageInProfile(ProfileImageManager profileImage)
    //{
    //    if (currObjectTracked)
    //    {
    //        string animalName = currObjectTracked.transform.GetChild(0).gameObject.name;
    //        profileImage.SetImageFromResourcesByName(animalName);
    //    }
    //}

    public string GetNameAnimalCurrent()
    {
        string name = "";
        if(currObjectTracked)
        {
            name = currObjectTracked.transform.GetChild(0).gameObject.name;
           
        }
        else
        {
            name = "";
        }
        return name;
    }
}
