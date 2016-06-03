using UnityEngine;
using System.Collections;
using Vuforia;
public class VirtualButton_Test : MonoBehaviour,IVirtualButtonEventHandler {
    public GameObject objCube;
	// Use this for initialization
	void Start () {
        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
        for (int i = 0; i < vbs.Length; ++i)
        {
            // Register with the virtual buttons TrackableBehaviour
            vbs[i].RegisterEventHandler(this);
        }
	}

    public void OnButtonPressed(VirtualButtonAbstractBehaviour vb) {
        Debug.Log("click virtual!");
        switch(vb.VirtualButtonName)
        {
            case "btnLeft":
                Debug.Log("left!!!!!!!!!!");
                if (objCube)
                {
                    objCube.SetActive(false);
                }
                break;
        }
        
    }
    public void OnButtonReleased(VirtualButtonAbstractBehaviour vb) { }
	// Update is called once per frame
	void Update () {
	
	}
}
