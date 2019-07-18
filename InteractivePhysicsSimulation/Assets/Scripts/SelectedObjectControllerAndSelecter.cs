using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedObjectControllerAndSelecter : MonoBehaviour {

    private GameObject Manager;
    private PlayingManager pm;
    private Material SelectedMat;
    private Material DefaultMat;
    private Renderer rd;
    private RigidBodyManager rbm;
    private GameObject posX;
    private GameObject posY;
    private GameObject posZ;
    private GameObject rotX;
    private GameObject rotY;
    private GameObject rotZ;
    private bool isSelected;

    private void Start()
    {
        Manager = GameObject.FindWithTag("Manager");
        pm = Manager.GetComponent<PlayingManager>();
        rd = GetComponent<Renderer>();
        SelectedMat = Resources.Load("Materials/Selected", typeof(Material)) as Material;
        DefaultMat = Resources.Load("Materials/Default", typeof(Material)) as Material;
        rd.material = DefaultMat;
        rbm = GetComponent<RigidBodyManager>();

        posX = GameObject.Find("PositionX");
        posY = GameObject.Find("PositionY");
        posZ = GameObject.Find("PositionZ");
        rotX = GameObject.Find("RotationX");
        rotY = GameObject.Find("RotationY");
        rotZ = GameObject.Find("RotationZ");
    }
    private void Update()
    {
        if (pm.Selected == gameObject && pm.IsPlaying == true)
        {
            Compile();
        }
    }
    private void OnMouseDown()
    {
        if(pm.Selected != null)
        {
            pm.Selected = null;
        }
        else
        {
            pm.Selected = gameObject;
            rd.material = SelectedMat;
            StartCoroutine("Waiter");
            Debug.Log(gameObject.name);
            Compile();
        }
        
    }


    public void KidsReactToPropertyDamage() //reacting to the user changing the properties (kids react to losing david)
    {
        if(pm.Selected == gameObject)
        {
            
        }
    }

    public void Compile()//compiles properties together
    {
        //Properties: rbm.vel for velocity, transform.[position, rotation, or maybe scale].[x, y, or z] for transform properties
        /*list order: transform properties(position xyz, and rotation xyz), velocity magnitude, angular velocity magnitude, */
        Debug.Log("boop1");
        List<float> floatProperties = new List<float>();
        floatProperties.Add(transform.position.x);
        floatProperties.Add(transform.position.y);
        floatProperties.Add(transform.position.z);
        floatProperties.Add(transform.rotation.x);
        floatProperties.Add(transform.rotation.y);
        floatProperties.Add(transform.rotation.z);
        floatProperties.Add(rbm.vel.x);
        floatProperties.Add(rbm.vel.y);
        floatProperties.Add(rbm.vel.z);

        if (pm.Selected == gameObject)
        {
            TransferToUI();
        }

    }

    void TransferToUI()
    {
        Debug.Log("boop2");
        posX.GetComponent<InputField>().text = transform.position.x.ToString();
        posY.GetComponent<InputField>().text = transform.position.y.ToString();
        posZ.GetComponent<InputField>().text = transform.position.z.ToString();
        rotX.GetComponent<InputField>().text = transform.rotation.eulerAngles.x.ToString();
        rotY.GetComponent<InputField>().text = transform.rotation.eulerAngles.y.ToString();
        rotZ.GetComponent<InputField>().text = transform.rotation.eulerAngles.z.ToString();

    }

    IEnumerator Waiter()
    {
        if (pm.Selected == gameObject)
        {
            isSelected = true;
        }
        else
        {
            isSelected = false  ;
        }
        yield return new WaitUntil(() => pm.Selected);
        yield return new WaitUntil(() => !pm.Selected);
        rd.material = DefaultMat;
    }


}
