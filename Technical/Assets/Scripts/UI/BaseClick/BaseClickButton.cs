using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BaseClickButton : MonoBehaviour {
	void OnEnable()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(OnClicked);
    }

    public virtual void OnClicked()
    {

    }

    void OnDisable()
    {
        gameObject.GetComponent<Button>().onClick.RemoveListener(OnClicked);
    }
}
