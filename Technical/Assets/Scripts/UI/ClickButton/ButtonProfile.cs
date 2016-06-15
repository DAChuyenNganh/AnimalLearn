using UnityEngine;
using System.Collections;

public class ButtonProfile : BaseClickButton {
    public Transform icon;
    public override void OnClicked()
    {
        Vector3 newLocalScale = icon.localScale;
        newLocalScale.x *= -1;
        icon.localScale = newLocalScale;

        GameController.Instance.ShowName();
        base.OnClicked();
    }
	
}
