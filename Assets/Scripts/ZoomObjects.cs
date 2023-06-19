using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ZoomObjects : MonoBehaviour
{
    private Camera cam;
    private GameObject target;
    private static Vector3 DefaultPositionCamera;
    private static Vector3 DefaultRotateCamera;
    private bool moveToPoint = false;
    private bool moveToDefault = false;
    private bool SuccessRotate = false;
    private float coefficient;
    private Button backButton;

    [SerializeField()] Vector3 PositionPoint;
    [SerializeField()] Vector3 RotatePoint;
    public float speed;

    void Start()
    {
        cam = Camera.main;
        target = GameObject.FindGameObjectWithTag("TargetCamera");
        backButton = GameObject.FindGameObjectWithTag("BackButton").GetComponent<Button>();
        backButton.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (moveToPoint)
            MoveCamera(ref moveToPoint, target);

        else if (moveToDefault)
        {
            MoveCamera(ref moveToDefault, target);
            if (!moveToDefault)
                cam.GetComponent<RotateRoom>().zoom = false;

        }
    }
    private void OnMouseDown()
    {
        if (!moveToPoint && cam.transform.position != PositionPoint)
        {
            DefaultPositionCamera = cam.transform.position;
            DefaultRotateCamera = cam.transform.eulerAngles;
            moveToPoint = true;
            backButton.gameObject.SetActive(true);
            coefficient = 1.5f;
            target.transform.position = PositionPoint;
            target.transform.eulerAngles = RotatePoint;
            cam.GetComponent<RotateRoom>().zoom = true;
        }
    }

    public void TapOnButton()
    {
        moveToDefault = true;
        backButton.gameObject.SetActive(false);
        this.gameObject.SetActive(true);
        target.transform.position = DefaultPositionCamera;
        target.transform.eulerAngles = DefaultRotateCamera;
        coefficient = 2.5f;
    }

    private void MoveCamera(ref bool move, GameObject target)
    {
        cam.transform.position = Vector3.MoveTowards(cam.transform.position, target.transform.position, speed * Time.deltaTime);
        if (cam.transform.rotation != target.transform.rotation)
            cam.transform.rotation = Quaternion.RotateTowards(cam.transform.rotation, target.transform.rotation, speed * coefficient * Time.deltaTime);
        else
            SuccessRotate = true;
        if (cam.transform.position == target.transform.position && SuccessRotate)
        {
            if (moveToPoint == move)
                this.gameObject.SetActive(false);
            move = false;
            SuccessRotate = false;
        }
    }
}
