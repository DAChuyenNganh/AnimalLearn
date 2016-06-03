﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour {
    private GameObject o_Parent;
	// Use this for initialization
	void Start () {
        o_Parent = transform.parent.gameObject;
	}




    void OnMouseDown()
    {
        if(o_Parent)
        {
            BaseAnimationManager s_ObjectAnimal = o_Parent.GetComponent<BaseAnimationManager>();
            if(s_ObjectAnimal)
            {
                s_ObjectAnimal.Attack();
            }


            _AudioType a_Audio = (_AudioType)System.Enum.Parse(typeof(_AudioType), o_Parent.name);

            AudioManager.Instance.PlayAudioByType(a_Audio);
        }
    }
}
