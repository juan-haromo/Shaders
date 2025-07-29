using System;
using UnityEngine;

public abstract class AInteractable : MonoBehaviour
{
    [SerializeField] AudioClip explanationClip;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Movement.Instance.gameObject)
        {
            Movement.Instance.Input.PlayerMovement.Interact.performed += Interaction;
            Movement.Instance.ShowInteraction();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Movement.Instance.gameObject)
        {
            Movement.Instance.Input.PlayerMovement.Interact.performed -= Interaction;
            Movement.Instance.HideInteraction();
        }
    }

    public abstract void Interaction(UnityEngine.InputSystem.InputAction.CallbackContext context);
}
