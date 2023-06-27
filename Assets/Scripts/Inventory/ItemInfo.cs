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
    [SerializeField] Vector3 defaultPosition;
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

    public void Open(Item item, int coefficient)
    {
        ChangeInfo(item); 
        gameObject.transform.localScale = scale;
        gameObject.transform.localPosition = new Vector3(defaultPosition.x,
                                                    defaultPosition.y - 117.0f * coefficient,
                                                    defaultPosition.z);
    }

    public void Close()
    {
        gameObject.transform.localScale = Vector3.zero;
    }
}
