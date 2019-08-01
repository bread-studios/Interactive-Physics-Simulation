using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheHandOfGod : MonoBehaviour {

    //public SelectedObjectControllerAndSelecter socas;




	void Start () {
		
	}



	void Update () {
		if(Input.GetKeyUp("h"))
        {
            ThrowSpawnEgg();
        }
	}




    public void ThrowSpawnEgg()
    {
        Instantiate(Resources.Load("Prefabs/"+"Cube"), Vector3.zero, Quaternion.identity);

    }
}
