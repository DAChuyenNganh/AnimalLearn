using UnityEngine;
using System.Collections;
using Holoville.HOTween;
using UnityEngine.UI;
public enum eStateMove
{
    LEFT_TO_RIGHT = 1,
    RIGHT_TO_LEFT =2
}
public enum eShowType
{
    SHOW_PROFILE  = 0,
    SHOW_IMAGE = 1
}

/// <summary>
/// Manager movement ui
/// </summary>
public class UiShowProfile : MonoBehaviour {
    [SerializeField]
    private Vector3 positionMove_root = new Vector3();
    [SerializeField]
    private Vector3 positionMove_to = new Vector3();

    [SerializeField]
    private const float timeMove = 0.5f;
    private const float distanceMove = 226;
    private ProfileManager profileManager;
    //private ProfileImageManager profileImage;

    //public eShowType typeShow = eShowType.SHOW_IMAGE;    
    //public GameObject objTextNoTrackableImage;
    //public GameObject objTextNoTrackableProfile;
    public eStateMove currStateMove = eStateMove.LEFT_TO_RIGHT;
	// Use this for initialization
	void Start () {
        this.positionMove_root = transform.localPosition;
        if(positionMove_root.x <0)
        {
            this.positionMove_to = new Vector3(positionMove_root.x+distanceMove, positionMove_root.y);
        }else
        {
            this.positionMove_to = new Vector3(positionMove_root.x - distanceMove, positionMove_root.y);
        }
        currStateMove = eStateMove.RIGHT_TO_LEFT;
	}

    // event onclick show >>
    [ContextMenu("move")]
    public void StartMove(Transform icon)
    {
        Vector3 newLocalScale = icon.localScale;
        newLocalScale.x *= -1;
        icon.localScale = newLocalScale;
        
        //if (typeShow == eShowType.SHOW_IMAGE)
        //{
        //    if(currNameAnimal =="" && objTextNoTrackableImage)
        //    {
        //        objTextNoTrackableImage.SetActive(true);
        //    }
        //    else
        //    {
        //        objTextNoTrackableImage.SetActive(false);
        //        profileImage.SetImageFromResourcesByName(currNameAnimal);
        //    }
        //}
        //else
        //{
        //    if (currNameAnimal == "" && objTextNoTrackableImage)
        //    {
        //        objTextNoTrackableProfile.SetActive(true);
        //    }
        //    else
        //    {
        //        objTextNoTrackableProfile.SetActive(false);
                
        //    }
        //}
        switch (currStateMove)
        {
            case eStateMove.LEFT_TO_RIGHT:
                HOTween.To(gameObject.transform, timeMove, new TweenParms()
                    .Prop("localPosition", positionMove_root, false)
                    .Ease(EaseType.Linear));
                currStateMove = eStateMove.RIGHT_TO_LEFT;
                break;
            case eStateMove.RIGHT_TO_LEFT:
                HOTween.To(gameObject.transform, timeMove, new TweenParms()
                    .Prop("localPosition", positionMove_to, false)
                    .Ease(EaseType.Linear));
                currStateMove = eStateMove.LEFT_TO_RIGHT;
                break;
        }
    }

	// Update is called once per frame
	void Update () {
       
	}
}
