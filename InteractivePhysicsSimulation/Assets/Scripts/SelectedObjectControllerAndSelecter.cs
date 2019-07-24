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
    private bool isSelected;
    private HighlightDetectionUI hdui;
    //UI gameobjects
    private GameObject playButton;
    private GameObject posX;
    private GameObject posY;
    private GameObject posZ;
    private GameObject rotX;
    private GameObject rotY;
    private GameObject rotZ;
    private GameObject velX;
    private GameObject velY;
    private GameObject velZ;
    private GameObject angularVelX;
    private GameObject angularVelY;
    private GameObject angularVelZ;
    private GameObject mass;
    //UI values
    private float speed;


    private void Start()
    {
        Manager = GameObject.FindWithTag("Manager");
        pm = Manager.GetComponent<PlayingManager>();
        rd = GetComponent<Renderer>();
        SelectedMat = Resources.Load("Materials/Selected", typeof(Material)) as Material;
        DefaultMat = Resources.Load("Materials/Default", typeof(Material)) as Material;
        rd.material = DefaultMat;
        playButton = GameObject.FindWithTag("PlayButton");
        rbm = GetComponent<RigidBodyManager>();
        hdui = playButton.GetComponent<HighlightDetectionUI>();

        posX = GameObject.Find("PositionX");
        posY = GameObject.Find("PositionY");
        posZ = GameObject.Find("PositionZ");

        rotX = GameObject.Find("RotationX");
        rotY = GameObject.Find("RotationY");
        rotZ = GameObject.Find("RotationZ");

        velX = GameObject.Find("VelocityX");
        velY = GameObject.Find("VelocityY");
        velZ = GameObject.Find("VelocityZ");

        angularVelX = GameObject.Find("AngularVelocityX");
        angularVelY = GameObject.Find("AngularVelocityY");
        angularVelZ = GameObject.Find("AngularVelocityZ");

        mass = GameObject.Find("MassInput");
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
        if (!hdui.isPlayButtonHighlighted)
        {
            if (pm.Selected != null)
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
    }


    public void KidsReactToPropertyDamage() //reacting to the user changing the properties (kids react to losing david)
    {
        if(pm.Selected == gameObject)
        {
            transform.position = new Vector3(float.Parse(posX.GetComponent<InputField>().text), float.Parse(posY.GetComponent<InputField>().text), float.Parse(posZ.GetComponent<InputField>().text));
            transform.eulerAngles = new Vector3(float.Parse(rotX.GetComponent<InputField>().text), float.Parse(rotY.GetComponent<InputField>().text), float.Parse(rotZ.GetComponent<InputField>().text));
            rbm.vel = new Vector3(float.Parse(velX.GetComponent<InputField>().text), float.Parse(velY.GetComponent<InputField>().text), float.Parse(velZ.GetComponent<InputField>().text));
            rbm.rot = new Vector3(float.Parse(rotX.GetComponent<InputField>().text), float.Parse(rotY.GetComponent<InputField>().text), float.Parse(rotZ.GetComponent<InputField>().text));
            rbm.mass = float.Parse(mass.GetComponent<InputField>().text);
        }
    }   

    public void Compile()//compiles properties together
    {
        //Properties: rbm.vel for velocity, transform.[position, rotation, or maybe scale].[x, y, or z] for transform properties
        /*list order: transform properties(position xyz, and rotation xyz), velocity magnitude, angular velocity magnitude, */
        //any edits made here should have a counterpart in "kidsreacttopropertydamage"
        posX.GetComponent<InputField>().text = transform.position.x.ToString();
        posY.GetComponent<InputField>().text = transform.position.y.ToString();
        posZ.GetComponent<InputField>().text = transform.position.z.ToString();
        rotX.GetComponent<InputField>().text = transform.rotation.eulerAngles.x.ToString();
        rotY.GetComponent<InputField>().text = transform.rotation.eulerAngles.y.ToString();
        rotZ.GetComponent<InputField>().text = transform.rotation.eulerAngles.z.ToString();
        velX.GetComponent<InputField>().text = rbm.vel.x.ToString();
        velY.GetComponent<InputField>().text = rbm.vel.y.ToString();
        velZ.GetComponent<InputField>().text = rbm.vel.z.ToString();
        angularVelX.GetComponent<InputField>().text = rbm.rot.x.ToString();
        angularVelY.GetComponent<InputField>().text = rbm.rot.y.ToString();
        angularVelZ.GetComponent<InputField>().text = rbm.rot.z.ToString();
        mass.GetComponent<InputField>().text = rbm.mass.ToString("n10");
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
