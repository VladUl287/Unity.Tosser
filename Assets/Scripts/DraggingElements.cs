using UnityEngine;

public sealed class DraggingElements : MonoBehaviour
{
    public float MaxRaycastDistance = 10f;
    public LayerMask InteractLayer;
    public GameObject Crosshair;

    private bool Dragging = false;
    private Rigidbody RigidBody;
    private Transform Transform;

    void Update()
    {
        if (!Dragging)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, MaxRaycastDistance, InteractLayer))
            {
                if (hit.collider.CompareTag("Interactable") && Input.GetButtonDown("Take"))
                {
                    RigidBody = hit.collider.GetComponent<Rigidbody>();
                    Transform = hit.collider.transform;
                    Crosshair.SetActive(false);
                    Dragging = true;
                }
            }
            return;
        }

        if (Input.GetButtonDown("Take"))
        {
            Crosshair.SetActive(true);
            Dragging = false;
            return;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            RigidBody.velocity = Camera.main.transform.position + Camera.main.transform.forward * 10;
            Crosshair.SetActive(true);
            Dragging = false;
            return;
        }

        var targetPosition = Camera.main.transform.position + Camera.main.transform.forward * 5;
        var velocity = (targetPosition - Transform.position) * 10;
        RigidBody.velocity = velocity;
    }
}
