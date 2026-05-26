using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;

public class Snow : MonoBehaviour
{
    private void Update()
    {
        Camera mainCamera = Camera.main;
        transform.LookAt(mainCamera.transform.position);
        transform.Rotate(0, 180, 0);
    }
}
