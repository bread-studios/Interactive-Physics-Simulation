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
            ThrowSpawnEgg("Cube",new Vector3(0,0,0));
        }
	}




    public void ThrowSpawnEgg(string prefab, Vector3 position)
    {
        Instantiate(Resources.Load("Prefabs/"+ prefab), position, Quaternion.identity);

    }
}
