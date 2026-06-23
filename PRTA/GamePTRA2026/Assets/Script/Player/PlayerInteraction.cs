using UnityEngine;
public class PlayerInteraction : MonoBehaviour
{
    public float pickupRange = 3f;
    public LayerMask itemLayer;
    public InventoryManager inventoryManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider[] nearbyItems = Physics.OverlapSphere(transform.position, pickupRange, itemLayer);

            if (nearbyItems.Length > 0)
            {
                Collider closest = nearbyItems[0];
                float closestDistance = Vector3.Distance(transform.position, closest.transform.position);

                foreach (Collider col in nearbyItems)
                {
                    float distance = Vector3.Distance(transform.position, col.transform.position);
                    if (distance < closestDistance)
                    {
                        closest = col;
                        closestDistance = distance;
                    }
                }

                Item item = closest.GetComponent<Item>();
                if (item != null)
                {
                    inventoryManager.AddItem(item.itemName);
                    Destroy(closest.gameObject);
                }
            }
        }
    }
}