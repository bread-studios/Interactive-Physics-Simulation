using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayButtonController : MonoBehaviour , IPointerClickHandler , IPointerEnterHandler , IPointerExitHandler , IPointerDownHandler, IPointerUpHandler{

    public Sprite ps; //play sprite
    public Sprite ss; //stop sprite
    public GameObject m;
    private Image img;
    private PlayingManager pm;
    private RectTransform rt;

	void Start () {
        m = GameObject.FindWithTag("Manager");
        img = GetComponent<Image>();
        pm = m.GetComponent<PlayingManager>();
        rt = GetComponent<RectTransform>();

        var tempColor = img.color;
        tempColor.a = 1f;
        img.color = tempColor;

        rt.sizeDelta = new Vector2(130, 35f);

        img.sprite = ps;
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        if (img.sprite == ps)
        {
            img.sprite = ss;
        }
        else
        {
            img.sprite = ps;
        }
        pm.TogglePlayPause();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

        var tempColor = img.color;
        tempColor.a = 0.5f;
        img.color = tempColor;

    }

    public void OnPointerExit(PointerEventData eventData)
    {

        var tempColor = img.color;
        tempColor.a = 1f;
        img.color = tempColor;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        rt.sizeDelta = new Vector2(117,31.5f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        rt.sizeDelta = new Vector2(130, 35f);
    }

    public void Switch()
    {
        if (img.sprite == ps)
        {
            img.sprite = ss;
        }
        else
        {
            img.sprite = ps;
        }
    }

}
