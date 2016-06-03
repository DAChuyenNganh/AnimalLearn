using UnityEngine;
using System.Collections;

public class ButtonPlay : BaseClickButton {
    public GameObject arCamera;
    public GameObject objPlatform;
    public GameObject objMode2;
    public override void OnClicked()
    {
        GameController.Instance.GoToMode2();

        GameObject objAnimal = GameController.Instance.currObjectTracked;
        if(objAnimal)
        {
            objAnimal.SetActive(true);
            objAnimal.transform.SetParent(objPlatform.transform,false);
            objAnimal.transform.localEulerAngles = new Vector3(90, 0, 0);
            objMode2.SetActive(true);
        }
    }
}
