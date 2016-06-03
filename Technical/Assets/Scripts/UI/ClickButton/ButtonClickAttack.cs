using UnityEngine;
using System.Collections;

public class ButtonClickAttack : BaseClickButton {
    public BaseAnimationManager animationScripts;
    public override void OnClicked()
    {
        //animationScripts = GameObject.FindObjectOfType(typeof(BaseAnimationManager)) as BaseAnimationManager;
        //if(animationScripts)
        //{
        //    //Debug.Log(animationScripts.gameObject);
        //    animationScripts.Attack();
        //    //animationScripts.SetAnimationByType(_AnimationState.attack);
        //}

        GameObject o_AnimalCurrent = GameController.Instance.currObjectTracked;

        if(o_AnimalCurrent)
        {
            string s_NameOfAnimal = "S_"+o_AnimalCurrent.transform.GetChild(0).gameObject.name;
            _AudioType audio = (_AudioType)System.Enum.Parse(typeof(_AudioType), s_NameOfAnimal);
            AudioManager.Instance.PlayAudioByType(audio);
            Debug.Log(s_NameOfAnimal);
        }        
    }
}
