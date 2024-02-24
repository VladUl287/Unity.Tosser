using UnityEngine;

public sealed class InteractElement : MonoBehaviour
{
    public float maxRaycastDistance = 10f;
    public LayerMask interactLayer;
    public GameObject crosshair;

    private bool dragging = false;
    private Rigidbody rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!dragging)
        {
            CheckDragging();
            return;
        }

        if (Input.GetButtonDown("Take"))
        {
            dragging = false;
            crosshair.SetActive(true);
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            dragging = false;
            crosshair.SetActive(true);
            rigidBody.velocity = Camera.main.transform.position + Camera.main.transform.forward * 10;
        }
        else
        {
            MoveByCamera();
        }
    }

    private void MoveByCamera()
    {
        var targetPosition = Camera.main.transform.position + Camera.main.transform.forward * 5;
        var velocity = (targetPosition - transform.position) * 10;
        rigidBody.velocity = velocity;
    }

    private void CheckDragging()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, maxRaycastDistance, interactLayer))
        {
            if (hit.collider.CompareTag("Interactable") && Input.GetButtonDown("Take"))
            {
                dragging = true;
                crosshair.SetActive(false);
            }
        }
    }
}
