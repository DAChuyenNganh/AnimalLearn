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
	// Use this for initialization
	void Start () {
        GoToMode1();
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

    [ContextMenu("test")]
    public void ShowName()
    {
        Sequence sequence = new Sequence(new SequenceParms().Loops(1, LoopType.Yoyo));
        Vector3 posStart = txtNameAnimal.GetComponent<RectTransform>().localPosition;
        sequence.Append(HOTween.To(txtNameAnimal.transform,1f,new TweenParms()
            .Prop("localPosition", new Vector3(posStart.x, posStart.y - txtNameAnimal.rectTransform.rect.height - 10, posStart.z), false)
            ));
        sequence.Play();
        Invoke("CallBackShowName",2f);
    }

    private void CallBackShowName()
    {
        Sequence sequence = new Sequence(new SequenceParms().Loops(1, LoopType.Yoyo));
        Vector3 posStart = txtNameAnimal.GetComponent<RectTransform>().localPosition;
        sequence.Append(HOTween.To(txtNameAnimal.transform, 1f, new TweenParms()
            .Prop("localPosition", new Vector3(posStart.x, posStart.y + txtNameAnimal.rectTransform.rect.height + 10, posStart.z), false)
            ));
        sequence.Play();
    }
}
