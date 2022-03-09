using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    [SerializeField] private List<Image> icons = new List<Image>();
    [SerializeField] private List<Text> amounts = new List<Text>();
    [SerializeField] private List<Button> butt = new List<Button>();
    public bool _MouseInPanel;

    public void OnPointerEnter(PointerEventData eventData)
    {
        _MouseInPanel = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _MouseInPanel = false;
    }
    public bool InPanel()
    {
        return _MouseInPanel;
    }
    public void UpdateUI(InventoryClass inv)
    {
        for (int i = 0; i < inv.GetSize() && i < icons.Count; i++)
        {
            icons[i].color = new Color(1, 1, 1, 1);
            icons[i].sprite = inv.GetItem(i).icon;
            amounts[i].text = (inv.GetCount(i) > 1 ? inv.GetCount(i).ToString() : "");
            butt[i].GetComponent<ButtonDragDrop>().TrueItem();
        }
        for (int i = inv.GetSize(); i < icons.Count && i < butt.Count; i++)
        {
            icons[i].color = new Color(1, 1, 1, 0);
            icons[i].sprite = null;
            amounts[i].text = "";
            butt[i].GetComponent<ButtonDragDrop>().NoItem();
        }
    }
}
