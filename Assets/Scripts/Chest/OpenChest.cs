using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenChest : MonoBehaviour
{
    private Animator animator;
    private GameObject key;
    private Animator keyAnimation;

    public int itemID;
    void Start()
    {
        animator = transform.parent.GetComponent<Animator>();
    }

    private async void OnMouseDown()
    {
        if (EventSystem.current.currentSelectedGameObject != null) {
            InventorySlot slot = SelectedSlot.Get().GetComponent<InventorySlot>();
            if (slot.ItemID == itemID)
            {
                key = Instantiate(slot.targetObject);
                key.transform.parent = GameObject.FindGameObjectWithTag("Floor").transform.parent;
                keyAnimation = key.transform.GetComponent<Animator>();
                keyAnimation.enabled = true;
                while (key.GetComponent<Key>().isEnd == false)
                    await Task.Yield();
                //Destroy(key);
                Inventory.instance.DeleteSlot(slot);
                animator.enabled = true;

            }
        }
    }
}
