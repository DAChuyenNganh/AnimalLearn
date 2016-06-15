using UnityEngine;
using System.Collections;
using Holoville.HOTween;
using UnityEngine.UI;
public enum eStateMove
{
    LEFT_TO_RIGHT = 1,
    RIGHT_TO_LEFT =2
}
public class UiShowProfile : MonoBehaviour {
    [SerializeField]
    private Vector3 positionMove_root = new Vector3();
    [SerializeField]
    private Vector3 positionMove_to = new Vector3();
    [SerializeField]
    private Sequence sequenceLeftToRight = null;
    private Sequence sequenceRightToLeft = null;
    [SerializeField]
    private const float timeMove = 0.5f;

    public eStateMove currStateMove = eStateMove.LEFT_TO_RIGHT;

    private const float distanceMove = 226;
	// Use this for initialization
	void Start () {
        Debug.Log(transform.position);
        this.positionMove_root = transform.localPosition;
        if(positionMove_root.x <0)
        {
            this.positionMove_to = new Vector3(positionMove_root.x+distanceMove, positionMove_root.y);
        }else
        {
            this.positionMove_to = new Vector3(positionMove_root.x - distanceMove, positionMove_root.y);
        }
        
        //transform.localPosition = positionMove_to;
        
        currStateMove = eStateMove.RIGHT_TO_LEFT;
	}

    [ContextMenu("test")]
    public void TestPosition()
    {
        //StartMove();
    }

    [ContextMenu("move")]
    public void StartMove(Transform icon)
    {
        Vector3 newLocalScale = icon.localScale;
        newLocalScale.x *= -1;
        icon.localScale = newLocalScale;

        switch(currStateMove)
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
