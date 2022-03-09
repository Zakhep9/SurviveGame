using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;
    public float speed;

    private float _maxDistance;
    private Vector3 _localPosition;
    private Vector3 _vectorRotation;

    private Vector3 _position
    {
        get { return transform.position; }
        set { transform.position = value; }
    }

    void Start()
    {
        _localPosition = target.InverseTransformPoint(_position);//точка относительно цели 
        _maxDistance = Vector3.Distance(_position, target.position);
    }

    void CameraRotation()
    {
        var mX = Input.GetAxis("Mouse X");
        var mY = -Input.GetAxis("Mouse Y");


        if (mY != 0)
        {
            // поворот главной камеры
            _vectorRotation = transform.TransformDirection(Vector3.right);
            transform.RotateAround(target.position, _vectorRotation, mY * speed * Time.deltaTime);

            // поворот персонажа
            target.transform.Rotate(mY * speed * Time.deltaTime, 0, 0);

        }
        if (mX != 0)
        {
            // поворот главной камеры
            _vectorRotation = transform.TransformDirection(Vector3.up);
            transform.RotateAround(target.position, _vectorRotation, mX * speed * Time.deltaTime);


            // поворот персонажа
            target.transform.Rotate(0, mX * speed * Time.deltaTime, 0);
        }
        
    }

    void CameraReact()
    {
        var distance = Vector3.Distance(_position, target.position);
        RaycastHit hit;
        //пускаем луч и смотрим, есть ли преграда
        if (Physics.Raycast(target.position, _position - target.position, out hit, _maxDistance))
        {
            _position = hit.point;
        }//отодвигаем камеру назад
        else if (distance < _maxDistance && !(Physics.Raycast(_position, -transform.forward, .1f)))
        {
            _position -= transform.forward * .05f;
        }
    }
    void LateUpdate()
    {
        _position = target.TransformPoint(_localPosition);
        //CameraRotation();
        CameraReact();
        _localPosition = target.InverseTransformPoint(_position);
    }
}
