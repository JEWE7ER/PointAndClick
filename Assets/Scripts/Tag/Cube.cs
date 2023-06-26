using UnityEngine;
using static TagManager;

public class Cube : MonoBehaviour
{
    internal int numberCell;
    private BoxCollider col;
    private float scaleX;
    private float scaleY;
    private Vector3 moveX;
    private Vector3 moveY;
    private Vector3 targetPosition;
    private bool move = false;
    private int speed;


    public TagManager tagManager;
    public GameObject triggerZones;
    public int number;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider>();
        scaleX = transform.localScale.x;
        scaleY = transform.localScale.y;
        moveX = new Vector3(scaleX, 0, 0);
        moveY = new Vector3(0, scaleY, 0);
        speed = tagManager.speed;
    }

    void FixedUpdate()
    {
        if (move)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            if (transform.position == targetPosition)
                move = false;
        }
    }

    private void OnMouseDown()
    {
        if (!tagManager.isWin && !move)
        {
            triggerZones.SetActive(false);
            RaycastHit hit;

            if (!Physics.Linecast(transform.position, transform.position + moveX, out hit))
            {
                targetPosition = new Vector3(transform.position.x + scaleX, transform.position.y, transform.position.z);
                move = true;
            }
            else if (!Physics.Linecast(transform.position, transform.position + -moveX, out hit))
            {
                targetPosition = new Vector3(transform.position.x - scaleX, transform.position.y, transform.position.z);
                move = true;
            }
            else if (!Physics.Linecast(transform.position, transform.position + moveY, out hit))
            {
                targetPosition = new Vector3(transform.position.x, transform.position.y + scaleY, transform.position.z);
                move = true;
            }
            else if (!Physics.Linecast(transform.position, transform.position + -moveY, out hit))
            {
                targetPosition = new Vector3(transform.position.x, transform.position.y - scaleY, transform.position.z);
                move = true;
            }
            triggerZones.SetActive(true);

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TagTrigger")
        {
            numberCell = other.transform.GetComponent<NumberCell>().numberCell;
            tagManager.Win();
        }
    }

}
