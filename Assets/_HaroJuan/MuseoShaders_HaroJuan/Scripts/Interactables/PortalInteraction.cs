using UnityEngine;
using UnityEngine.InputSystem;

public class PortalInteraction : AInteractable
{
    public Material rockMat;
    int matVersion = 0;

    public override void Interaction(InputAction.CallbackContext context)
    {
        Debug.Log("MatVer");
        rockMat.SetFloat("_Direction", matVersion);
        matVersion++;
        matVersion %= 3;
        Debug.Log("Ajua");
    }
}
