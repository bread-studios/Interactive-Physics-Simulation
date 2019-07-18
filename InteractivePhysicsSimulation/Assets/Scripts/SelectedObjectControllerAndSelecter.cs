using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedObjectControllerAndSelecter : MonoBehaviour {

    private GameObject Manager;
    private SelectionManager sm;
    private Material SelectedMat;
    private Material DefaultMat;
    private Renderer rd;
    private RigidBodyManager rbm;
    private bool amISelected;
    private void Start()
    {
        Manager = GameObject.FindWithTag("Manager");
        sm = Manager.GetComponent<SelectionManager>();
        rd = GetComponent<Renderer>();
        SelectedMat = Resources.Load("Materials/Selected", typeof(Material)) as Material;
        DefaultMat = Resources.Load("Materials/Default", typeof(Material)) as Material;
        rd.material = DefaultMat;
        rbm = GetComponent<RigidBodyManager>();
    }

    private void OnMouseDown()
    {
        if(sm.Selected != null)
        {
            sm.Selected = null;
        }
        else
        {
            sm.Selected = gameObject;
            rd.material = SelectedMat;
            StartCoroutine("Waiter");
            Debug.Log(gameObject.name);
        }
        
    }

    private void Update()
    {
        if (sm.Selected == gameObject)
        {
            amISelected = true;
        }
        else
        {
            amISelected = false;
        }
    }

    public void KidsReactToPropertyDamage() //reacting to the user changing the properties (kids react to losing david)
    {
        if(amISelected == true)
        {
            
        }
    }

    void Compile()//compiles properties together
    {
        //Properties: rbm.vel for velocity, transform.[position, rotation, or maybe scale].[x, y, or z] for transform properties
        /*list order: transform properties(position xyz, and rotation xyz), velocity magnitude, angular velocity magnitude, */
        List<float> floatProperties = new List<float>();
        floatProperties.Add(transform.position.x);
        floatProperties.Add(transform.position.y);
        floatProperties.Add(transform.position.z);
        floatProperties.Add(transform.rotation.x);
        floatProperties.Add(transform.rotation.y);
        floatProperties.Add(transform.rotation.z);
    }

    IEnumerator Waiter()
    {
        yield return new WaitUntil(() => amISelected);
        yield return new WaitUntil(() => !amISelected);
        rd.material = DefaultMat;
    }

}
