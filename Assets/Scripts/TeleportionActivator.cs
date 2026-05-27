using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class TeleportionActivator : MonoBehaviour
{
    public XRRayInteractor teleportInteractor;
    public XRRayInteractor rayInteractor;
    public InputActionProperty teleportActivatorActor;

    private void Start()
    {
        teleportInteractor.gameObject.SetActive(false);
        teleportActivatorActor.action.performed += PerformAction;
        rayInteractor.uiHoverEntered.AddListener(x => DisableTeleportRay());
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
        if (rayInteractor && rayInteractor.IsOverUIGameObject())
        {
            return;
        }
        teleportInteractor.gameObject.SetActive(true);
    }

    public void DisableTeleportRay()
    {
        teleportInteractor.gameObject.SetActive(false);
    }
}
