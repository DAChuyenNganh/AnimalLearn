using UnityEngine;
using System.Collections;

public class ButtonClickAttack : BaseClickButton {
   
    public override void OnClicked()
    {
        GameObject o_AnimalCurrent = GameController.Instance.currObjectTracked;

        if(o_AnimalCurrent)
        {
            string s_NameOfAnimal = "S_"+o_AnimalCurrent.transform.GetChild(0).gameObject.name;
            _AudioType audio = (_AudioType)System.Enum.Parse(typeof(_AudioType), s_NameOfAnimal);
            AudioManager.Instance.PlayAudioByType(audio);
        }        
    }
}
