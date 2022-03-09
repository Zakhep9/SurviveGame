using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezerAnimations : MonoBehaviour
{
    private Animation _animation;
    void Start()
    {
        _animation = GetComponent<Animation>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log(_animation.GetClipCount());
            _animation.Play("Open");
        }
        if (Input.GetMouseButtonDown(1))
        {
            _animation.Play("Open");
        }
    }
}
