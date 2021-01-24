using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBillboard : MonoBehaviour {

    Camera mainCamera;
	
	void Start () {
        mainCamera = Camera.main;
	}
		
	void Update () {
        this.transform.rotation = mainCamera.transform.rotation;
	}
}
