using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemInfo : MonoBehaviour
{
    public static ItemInfo instance;

    private Image BackGround;
    private Text Title;
    private Text Description;
    private Image Icon;

    private void Start()
    {
        instance = this;

        BackGround = GetComponent<Image>();
        Title = transform.GetChild(0).GetComponent<Text>();
        Description = transform.GetChild(1).GetComponent<Text>();
        // Icon = transform.GetChild(2).GetComponent<Image>();
    }

    public void ChangeInfo(Item item)
    {
        Title.text = item.Name;
        Description.text = item.Description;
        // Icon.sprite = item.icon;
    }

    public void Open(Item item)
    {
        ChangeInfo(item); 
        gameObject.transform.localScale = Vector3.one;
    }

    public void Close()
    {
        gameObject.transform.localScale = Vector3.zero;
    }
}
