using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class TakeElement : MonoBehaviour
{
    public float maxRaycastDistance = 10f;
    public LayerMask interactableLayer;
    public GameObject crosshair;

    private bool isDragging = false;
    private Transform draggedObject;
    private Rigidbody rgBody;

    private void Start()
    {
        rgBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!isDragging)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, maxRaycastDistance, interactableLayer))
            {
                if (hit.collider.CompareTag("Interactable") && Input.GetButtonDown("Take"))
                {
                    isDragging = true;
                    crosshair.SetActive(false);
                    draggedObject = hit.collider.transform;
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (isDragging)
        {
            var targetPosition = Camera.main.transform.position + Camera.main.transform.forward * 5;
            var velocity = (targetPosition - transform.position) * 5;
            rgBody.velocity = velocity;
        }
    }
}
