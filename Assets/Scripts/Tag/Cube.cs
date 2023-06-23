using UnityEngine;
using static TagManager;

public class Cube : MonoBehaviour
{
    BoxCollider col;
    public int number;
    internal int numberCell;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider>();
    }


    private void OnMouseDown()
    {
        if (!TagManager.isWin)
        {
            col.enabled = false;
            RaycastHit hit;

            if (!Physics.Linecast(transform.position, transform.position + transform.right, out hit))
            {
                transform.position = new Vector3(transform.position.x + 0.25f, transform.position.y, transform.position.z);
            }
            else if (!Physics.Linecast(transform.position, transform.position + -transform.right, out hit))
            {
                transform.position = new Vector3(transform.position.x - 0.25f, transform.position.y, transform.position.z);
            }
            else if (!Physics.Linecast(transform.position, transform.position + transform.up, out hit))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z);
            }
            else if (!Physics.Linecast(transform.position, transform.position + -transform.up, out hit))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.25f, transform.position.z);
            }
            col.enabled = true;

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "trigger")
        {
            numberCell = other.transform.GetComponent<NumberCell>().numberCell;
            TagManager.Win();
        }
    }

}
