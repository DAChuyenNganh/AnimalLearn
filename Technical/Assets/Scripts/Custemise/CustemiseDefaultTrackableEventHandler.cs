using UnityEngine;
using System.Collections;
using Vuforia;

public class CustemiseDefaultTrackableEventHandler : DefaultTrackableEventHandler {

    public GameObject objChildAnimal;
    public override void InitGame()
    {
        objChildAnimal = transform.GetChild(0).gameObject;
        if(!objChildAnimal)
        {
#if UNITY_EDITOR
            Debug.Log("thang nay khong co thang con!");
#endif 
        }
    }
    public override void UpdateGame()
    {
        
    }

    protected override void OnTrackingFound()
    {
        if (objChildAnimal && !objChildAnimal.activeInHierarchy)
        {
            objChildAnimal.SetActive(true);
        }

        GameController.Instance.currObjectTracked = objChildAnimal;

        //base.OnTrackingFound();
    }

    protected override void OnTrackingLost()
    {
        if(objChildAnimal && objChildAnimal.activeInHierarchy)
        {
            objChildAnimal.SetActive(false);
        }
        //base.OnTrackingLost();
    }
}
