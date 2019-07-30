using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedObjectControllerAndSelecter : MonoBehaviour
{ 
    
    private GameObject Manager;
    private PlayingManager pm;
    private Material SelectedMat;
    private Material DefaultMat;
    private Renderer rd;
    private RigidBodyManager rbm;
    private bool isSelected;
    private HighlightDetectionUI hdui;
    private Collider butter;
    public float trueBounce;
    public float startDyFric;
    public float startStFric;
    private float bounceFactor = 0.98823535f;
    //the reset button will bring the objects to these values:
    public Vector3 rsPos;
    public Vector3 rsRot;
    public Vector3 rsVel;
    public Vector3 rsAngVel;
    //UI gameobjects
    private GameObject cvs; //canvas
    private GameObject playButton;
    private GameObject posX;
    private GameObject posY;
    private GameObject posZ;
    private GameObject rotX;
    private GameObject rotY;
    private GameObject rotZ;
    private GameObject sclX;
    private GameObject sclY;
    private GameObject sclZ;
    private GameObject velX;
    private GameObject velY;
    private GameObject velZ;
    private GameObject angularVelX;
    private GameObject angularVelY;
    private GameObject angularVelZ;
    private GameObject mass;
    private GameObject dynamicFriction;
    private GameObject staticFriction;
    private GameObject elasticitySlider;
    private GameObject elasticityInput;
    public GameObject staticToggle;


    private void Start() { 
        rsAngVel = new Vector3(0, 0, 0);
        Manager = GameObject.FindWithTag("Manager");
        pm = Manager.GetComponent<PlayingManager>();
        rd = GetComponent<Renderer>();
        SelectedMat = Resources.Load("Materials/Selected", typeof(Material)) as Material;
        DefaultMat = Resources.Load("Materials/Default", typeof(Material)) as Material;
        rd.material = DefaultMat;
        playButton = GameObject.FindWithTag("PlayButton");
        rbm = GetComponent<RigidBodyManager>();
        cvs = GameObject.FindWithTag("Canvas");
        hdui = cvs.GetComponent<HighlightDetectionUI>();
        butter = GetComponent<Collider>();
        butter.material.bounceCombine = PhysicMaterialCombine.Average;
        butter.material.frictionCombine = PhysicMaterialCombine.Average;
        trueBounce = butter.material.bounciness / bounceFactor;
        butter.material.bounciness = trueBounce * bounceFactor;
        butter.material.bounciness = trueBounce * bounceFactor;
        trueBounce = butter.material.bounciness / bounceFactor;

        posX = GameObject.Find("PositionX");
        posY = GameObject.Find("PositionY");
        posZ = GameObject.Find("PositionZ");

        rotX = GameObject.Find("RotationX");
        rotY = GameObject.Find("RotationY");
        rotZ = GameObject.Find("RotationZ");

        sclX = GameObject.Find("ScaleX");
        sclY = GameObject.Find("ScaleY");
        sclZ = GameObject.Find("ScaleZ");

        velX = GameObject.Find("VelocityX");
        velY = GameObject.Find("VelocityY");
        velZ = GameObject.Find("VelocityZ");

        angularVelX = GameObject.Find("AngularVelocityX");
        angularVelY = GameObject.Find("AngularVelocityY");
        angularVelZ = GameObject.Find("AngularVelocityZ");

        mass = GameObject.Find("MassInput");

        dynamicFriction = GameObject.Find("DynamicFrictionInput");
        staticFriction = GameObject.Find("StaticFrictionInput");

        dynamicFriction.GetComponent<InputField>().text = startDyFric.ToString();
        staticFriction.GetComponent<InputField>().text = startStFric.ToString();
        butter.material.dynamicFriction = startDyFric;
        butter.material.staticFriction = startStFric;

        elasticityInput = GameObject.Find("ElasticityInput");
        elasticitySlider = GameObject.Find("ElasticitySlider");

        staticToggle = GameObject.Find("Static");

        KidsReactToPropertyDamage();
        Compile();
    }

    private void Update()
    {
        trueBounce = butter.material.bounciness / bounceFactor;
        butter.material.bounciness = trueBounce * bounceFactor;
        butter.material.bounceCombine = PhysicMaterialCombine.Average   ;
        butter.material.frictionCombine = PhysicMaterialCombine.Average;
        if (pm.Selected == gameObject && pm.IsPlaying == true)
        {
            Compile();
        }
    }

    private void OnMouseDown()
    {
        if (!hdui.isGUIHighlighted)
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
                Compile();
            }
        }
    }

    public void Compile()//compiles properties together
    {
        //Properties: rbm.vel for velocity, transform.[position, rotation, or maybe scale].[x, y, or z] for transform properties
        /*list order: transform properties(position xyz, and rotation xyz), velocity magnitude, angular velocity magnitude, */
        //any edits made here should have a counterpart in "kidsreacttopropertydamage"
        posX.GetComponent<InputField>().text = transform.position.x.ToString("n5");
        posY.GetComponent<InputField>().text = transform.position.y.ToString("n5");
        posZ.GetComponent<InputField>().text = transform.position.z.ToString("n5");
        rotX.GetComponent<InputField>().text = transform.rotation.eulerAngles.x.ToString("n5");
        rotY.GetComponent<InputField>().text = transform.rotation.eulerAngles.y.ToString("n5");
        rotZ.GetComponent<InputField>().text = transform.rotation.eulerAngles.z.ToString("n5");
        sclX.GetComponent<InputField>().text = transform.localScale.x.ToString("n5");
        sclY.GetComponent<InputField>().text = transform.localScale.y.ToString("n5");
        sclZ.GetComponent<InputField>().text = transform.localScale.z.ToString("n5");
        velX.GetComponent<InputField>().text = rbm.vel.x.ToString("n5");
        velY.GetComponent<InputField>().text = rbm.vel.y.ToString("n5");
        velZ.GetComponent<InputField>().text = rbm.vel.z.ToString("n5");
        angularVelX.GetComponent<InputField>().text = rbm.rot.x.ToString("n5");
        angularVelY.GetComponent<InputField>().text = rbm.rot.y.ToString("n5");
        angularVelZ.GetComponent<InputField>().text = rbm.rot.z.ToString("n5");
        mass.GetComponent<InputField>().text = rbm.mass.ToString("n5");
        dynamicFriction.GetComponent<InputField>().text = butter.material.dynamicFriction.ToString("n5");
        staticFriction.GetComponent<InputField>().text = butter.material.staticFriction.ToString("n5");
        trueBounce = butter.material.bounciness / bounceFactor;
        elasticityInput.GetComponent<InputField>().text = trueBounce.ToString("n5");
        elasticitySlider.GetComponent<Slider>().value = float.Parse(elasticityInput.GetComponent<InputField>().text);
        butter.material.bounciness = trueBounce * bounceFactor;
        staticToggle.GetComponent<Toggle>().isOn = rbm.isStatic;
        
    }

    public void KidsReactToPropertyDamage() //reacting to the user changing the properties (kids react to losing david)
    {
        if (pm.Selected == gameObject)
        {
            transform.position = new Vector3(float.Parse(posX.GetComponent<InputField>().text), float.Parse(posY.GetComponent<InputField>().text), float.Parse(posZ.GetComponent<InputField>().text));
            transform.eulerAngles = new Vector3(float.Parse(rotX.GetComponent<InputField>().text), float.Parse(rotY.GetComponent<InputField>().text), float.Parse(rotZ.GetComponent<InputField>().text));
            transform.localScale = new Vector3(float.Parse(sclX.GetComponent<InputField>().text), float.Parse(sclY.GetComponent<InputField>().text), float.Parse(sclZ.GetComponent<InputField>().text));
            rbm.vel = new Vector3(float.Parse(velX.GetComponent<InputField>().text), float.Parse(velY.GetComponent<InputField>().text), float.Parse(velZ.GetComponent<InputField>().text));
            rbm.rot = new Vector3(float.Parse(rotX.GetComponent<InputField>().text), float.Parse(rotY.GetComponent<InputField>().text), float.Parse(rotZ.GetComponent<InputField>().text));
            rbm.mass = float.Parse(mass.GetComponent<InputField>().text);
            butter.material.dynamicFriction = float.Parse(dynamicFriction.GetComponent<InputField>().text);
            butter.material.staticFriction = float.Parse(staticFriction.GetComponent<InputField>().text);
            trueBounce = butter.material.bounciness / bounceFactor;
            if (pm.isSliderChanged)
            {
                trueBounce = elasticitySlider.GetComponent<Slider>().value;
                elasticityInput.GetComponent<InputField>().text = trueBounce.ToString("n5");
            }
            if (!pm.isSliderChanged)
            {
                trueBounce = float.Parse(elasticityInput.GetComponent<InputField>().text);
                elasticitySlider.GetComponent<Slider>().value = trueBounce;
            }
            butter.material.bounciness = trueBounce * bounceFactor;
        }
    }

    public void reset()
    {
        transform.position = rsPos;
        transform.eulerAngles = rsRot;
        rbm.rot = rsAngVel;
        rbm.vel = rsVel;
        Compile();
    }

    IEnumerator Waiter()
    {
        if (pm.Selected == gameObject)
        {
            isSelected = true;
        }
        else
        {
            isSelected = false;
        }
        yield return new WaitUntil(() => pm.Selected);
        yield return new WaitUntil(() => !pm.Selected);
        rd.material = DefaultMat;
    }
}