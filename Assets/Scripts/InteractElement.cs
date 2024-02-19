using UnityEngine;

public sealed class InteractElement : MonoBehaviour
{
    public float maxRaycastDistance = 10f;
    public LayerMask interactableLayer;
    public GameObject crosshair;

    private bool dragging = false;
    private Rigidbody rgBody;

    private void Start()
    {
        rgBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!dragging)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, maxRaycastDistance, interactableLayer))
            {
                if (hit.collider.CompareTag("Interactable") && Input.GetButtonDown("Take"))
                {
                    dragging = true;
                    crosshair.SetActive(false);                    
                }
            }
        }
        else
        {
            if (Input.GetButtonDown("Take"))
            {
                dragging = false;
                crosshair.SetActive(true);
            }
            if (Input.GetButtonDown("Fire1"))
            {
                dragging = false;
                crosshair.SetActive(true);
                var targetPosition = Camera.main.transform.position + Camera.main.transform.forward * 10;
                rgBody.velocity = targetPosition;
            }
        }
    }

    void FixedUpdate()
    {
        if (dragging)
        {
            var targetPosition = Camera.main.transform.position + Camera.main.transform.forward * 5;
            var velocity = (targetPosition - transform.position) * 10;
            rgBody.velocity = velocity;
        }
    }
}
