using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


//public class BoolVolue: MonoBehaviour
//{
//    public bool vol;
//    public bool GetVol()
//    {
//        return vol;
//    }
//}

public class BoxOpen : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public UnityEvent OnTriggerBox;
    [SerializeField] public UnityEvent ContextMenuUpdate;
    public BoxInv _box;
    public bool IsTrigged = false;
    public bool IsExit = false;
    //BoolVolue Trig = new BoolVolue();
    void Start() 
    {
        _box = GetComponent<BoxInv>();
    }

    public bool GetTrigger()
    {
        return IsExit;
    }
    private void OnTriggerEnter(Collider other)
    {
        IsExit = false;
        ContextMenuUpdate.Invoke();
        //Trig.vol = 
        IsTrigged = true;
        
    }
    private void OnTriggerExit(Collider other)
    {
        IsTrigged = false;
        IsExit = true;
        ContextMenuUpdate.Invoke();
        
    }
    void Update()
    {
        //if(IsTrigged)
            OnTriggerBox.Invoke();
    }
}
