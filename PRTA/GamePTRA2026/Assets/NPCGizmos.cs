using UnityEngine;

public class NPCGizmos : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 2.5f);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 25f);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 50f);
    }
}
