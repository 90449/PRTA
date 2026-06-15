using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject[] slots;
    public Sprite itemSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
                image.sprite = itemSprite;
                image.color = Color.white;

                RectTransform rect = itemUI.GetComponent<RectTransform>();
                rect.anchorMin = Vector2.zero;
                rect.anchorMax = Vector2.one;
                rect.offsetMin = Vector2.zero;
                rect.offsetMax = Vector2.zero;

                break;
            }
        }
    }
}
