using UnityEngine;
using System.Collections;

public class ButtonProfile : BaseClickButton {

    public override void OnClicked()
    {
        GameController.Instance.ShowName();
        base.OnClicked();
    }
	
}
