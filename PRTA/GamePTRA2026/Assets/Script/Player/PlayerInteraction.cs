using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float pickupRange = 3f;
    public InventoryManager inventoryManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, pickupRange))
            {
                Item item = hit.collider.GetComponent<Item>();
                if (item != null)
                {
                    inventoryManager.AddItem(item.itemName);
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
