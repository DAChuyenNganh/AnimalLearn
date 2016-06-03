using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ManagerButton : MonoBehaviour {
    public Image imgBG;
	// Use this for initialization
	void Start () {
        imgBG = gameObject.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    [ContextMenu("test")]
    public void Active()
    {
        StartCoroutine(DoActive());
    }
    public IEnumerator DoActive()
    {
        float n = 1;
        while(true)
        {
            n -= Time.deltaTime/10;
            imgBG.fillAmount = n;
            if(n < 0.75f)
            {
                break;
            }
           
            yield return new WaitForFixedUpdate();
        }
    }
}
