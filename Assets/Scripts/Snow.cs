using UnityEngine;

public class Snow : MonoBehaviour
{
    private void Update()
    {
        Camera mainCamera = Camera.main;

        Vector3 targetPosition = mainCamera.transform.position;

        targetPosition.y = transform.position.y;

        transform.LookAt(targetPosition);

        transform.Rotate(0, 180, 0);
    }
}