using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject[] slots;
    public Sprite[] itemSprites;
    public string[] itemNames;
    public string[] itemsInSlots;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        itemsInSlots = new string[slots.Length];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(string itemName)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].transform.childCount == 0)
            {
                GameObject itemUI = new GameObject(itemName);
                itemUI.transform.SetParent(slots[i].transform);

                Image image = itemUI.AddComponent<Image>();

                for (int j = 0; j < itemNames.Length; j++)
                {
                    if (itemNames[j] == itemName)
                    {
                        image.sprite = itemSprites[j];
                        break;
                    }
                }

                image.color = Color.white;

                RectTransform rect = itemUI.GetComponent<RectTransform>();
                rect.anchorMin = Vector2.zero;
                rect.anchorMax = Vector2.one;
                rect.offsetMin = Vector2.zero;
                rect.offsetMax = Vector2.zero;
                itemsInSlots[i] = itemName;
                break;
            }
        }
    }

    public string UseItem()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (itemsInSlots[i] == "Apple" || itemsInSlots[i] == "Pear" || itemsInSlots[i] == "Melon")
            {
                string usedItem = itemsInSlots[i];
                itemsInSlots[i] = null;
                Destroy(slots[i].transform.GetChild(0).gameObject);
                return usedItem;
            }
        }
        return null;
    }
}
