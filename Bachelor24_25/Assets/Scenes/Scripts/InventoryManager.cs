using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;
    private GameObject somePrefab;

    private void Awake()
    {
        Instance = this;

    }

    public void Add(Item item)
    {
        Debug.Log(item.itemName + " added to Items list");
        Items.Add(item);
        
    }

    public void Remove(Item item)
    {
        Items.Remove(item);

    }
    
    public void ListItems()
    {
        int count = 0;    
        // Clean content before updating UI
        
        foreach (Transform item in ItemContent)
        {
            if (item != null) // Prevent destroying null objects
                Destroy(item.gameObject);
        }
        
        foreach (var item in Items)
        {
            if (InventoryItem == null)
            {
                Debug.LogError("InventoryItem prefab is missing!");
                return;
            }

            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName")?.GetComponent<TextMeshProUGUI>();
            var itemIcon = obj.transform.Find("ItemIcon")?.GetComponent<Image>();
            
            RectTransform rt = obj.GetComponent<RectTransform>();
            rt.localPosition = rt.localPosition + Vector3.right * rt.rect.width * count;
            

            if (itemName != null)
            {
                Debug.Log("added name " + item.itemName);
                itemName.text = item.itemName;
            }

            if (itemIcon != null)
            {
                Debug.Log("added icon " + item.icon.name);

                itemIcon.sprite = item.icon;
            }

            count++;
        }
    }


}
   



