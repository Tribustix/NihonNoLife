using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlotUI : MonoBehaviour
{
    public Button button;
    public Image icon;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI typeText;
    public TextMeshProUGUI quantityText;
    private ItemSlot curSlot;

    public int index;

    

    //sets the item to be displayed in the slot
    public void Set(ItemSlot slot)
    {

        curSlot = slot;

        icon.gameObject.SetActive(true);
        icon.sprite = slot.item.icon;
        nameText.text = slot.item.name;
        typeText.text = slot.item.type.ToString();
        quantityText.text = slot.quantity > 1 ? slot.quantity.ToString() : string.Empty;

    }

    //clears the item slot
    public void Clear()
    {
        curSlot = null;

        icon.gameObject.SetActive(false);
        nameText.text = string.Empty;
        typeText.text = string.Empty;
        quantityText.text = string.Empty;
    }

    //called when we click on the slot
    public void OnButtonClick()
    {
        Inventory.instance.SelectItem(index);
    }
    
}
