using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class TeleportionActivator : MonoBehaviour
{
    public XRRayInteractor teleportInteractor;
    public InputActionProperty teleportActivatorActor;

    private void Start()
    {
        teleportInteractor.gameObject.SetActive(false);
        teleportActivatorActor.action.performed += PerformAction;
    }

    private void Update()
    {
        if (teleportActivatorActor.action.WasReleasedThisFrame())
        {
            teleportInteractor.gameObject.SetActive(false);
        }
    }

    private void PerformAction(InputAction.CallbackContext context)
    {
        teleportInteractor.gameObject.SetActive(true);
    }
}
