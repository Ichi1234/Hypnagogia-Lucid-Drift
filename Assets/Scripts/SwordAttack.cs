using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Snow snow = other.GetComponent<Snow>();
            snow.TakeDamaged();
        }

    }
}
