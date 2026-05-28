using System.Collections;
using UnityEngine;

public class Snow : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Material defaultMat;
    [SerializeField] private Material onHitMat;

    private float curHealth = 100;

    private void OnEnable()
    {
        meshRenderer.material = defaultMat;
    }

    private void Update()
    {
        if (curHealth <= 0)
            Destroy(gameObject);

        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        Camera mainCamera = Camera.main;

        Vector3 targetPosition = mainCamera.transform.position;

        targetPosition.y = transform.position.y;

        transform.LookAt(targetPosition);

        transform.Rotate(0, 180, 0);
    }

    public void TakeDamaged()
    {
        curHealth -= 10;

        StartCoroutine(HitEffect());
    }

    private IEnumerator HitEffect()
    {
        meshRenderer.material = onHitMat;

        yield return new WaitForSeconds(0.1f);

        meshRenderer.material = defaultMat;
    }
}