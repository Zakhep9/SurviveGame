using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ButtonDragDrop : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public UnityEvent Dropping;
    public UnityEvent Giving;
    public RectTransform _Parent;
    public RectTransform _DifferentPanel;
    public int _index;
    private Vector3 temp;
    private bool IsItem = false;
    // Start is called before the first frame update

    public void Start (){
        
        _Parent = this.transform.parent.GetComponent<RectTransform>();
        temp = this.transform.position;
    }

    public void NoItem()
    {
        IsItem = false;
    }

    public void TrueItem()
    {
        IsItem = true;
    }

    public void Sort()
    {
        //for (int i = 0; i < _Parent.transform.childCount - 1; i++)
        //    _Parent.GetChild(i).SetSiblingIndex(_index);
        for (int i = 0; i < _Parent.transform.childCount-1; i++)
        {
            
            for (int j = i+1;j < _Parent.transform.childCount-1; j++)
            {
                var obj1 = _Parent.GetChild(i).GetComponent<ButtonDragDrop>();
                var obj2 = _Parent.GetChild(j).GetComponent<ButtonDragDrop>();
                if ((!obj1.IsItem && !obj2.IsItem) && (obj1._index < obj2._index) && (obj1.transform.position.x - obj2.transform.position.x > 0))
                {
                    temp = _Parent.GetChild(i).position;
                    _Parent.GetChild(i).position = _Parent.GetChild(j).position;
                    _Parent.GetChild(j).position = temp;
                }
            }
                
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //canvas = FindInParents<Canvas>();
        //_index = transform.GetSiblingIndex();
        if (IsItem)
        {
            temp = transform.position;
            transform.SetParent(_Parent.parent);
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        if(IsItem)
            transform.position = Input.mousePosition;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(_Parent, transform.position))
            Replace();
        else 
        if(RectTransformUtility.RectangleContainsScreenPoint(_DifferentPanel, transform.position))
        {
            Give();
            transform.position = temp;
            transform.SetParent(_Parent);
            if (IsItem)
                Replace();
            else
                Sort();
        }
        else
        {
            Drop();
            transform.position = temp;
            transform.SetParent(_Parent);
            if (IsItem)
                Replace();
            else
                Sort();
        }
    }
    public void Replace()
    {
        if (IsItem)
        {
            int closetIndex = 0;

            for (int i = 0; i < _Parent.transform.childCount; i++)
            {
                if (Vector3.Distance(transform.position, _Parent.GetChild(i).position) <
                    Vector3.Distance(transform.position, _Parent.GetChild(closetIndex).position))
                    closetIndex = i;
            }
            transform.SetParent(_Parent);
            transform.position = _Parent.GetChild(closetIndex).position;
            _Parent.GetChild(closetIndex).position = temp;
            //_Parent.GetChild(closetIndex).SetSiblingIndex()
            //transform.SetSiblingIndex(closetIndex);
            this.Sort();
        }
    }
    public void Drop()
    {
        Dropping?.Invoke();
    }
    public void Give()
    {
        Giving?.Invoke();
    }
}
