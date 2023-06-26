using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemInfo : MonoBehaviour
{

    private Image BackGround;
    private TMP_Text Title;
    private Image Icon;

    [SerializeField] Vector3 scale;
    public static ItemInfo instance;

    private void Start()
    {
        instance = this;

        BackGround = GetComponent<Image>();
        Title = transform.GetChild(0).GetComponent<TMP_Text>();
        // Icon = transform.GetChild(2).GetComponent<Image>();
    }

    public void ChangeInfo(Item item)
    {
        if (item != null)
            Title.text = item.Name;
        // Icon.sprite = item.icon;
    }

    public void Open(Item item)
    {
        ChangeInfo(item); 
        gameObject.transform.localScale = scale;
    }

    public void Close()
    {
        gameObject.transform.localScale = Vector3.zero;
    }
}
