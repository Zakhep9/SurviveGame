using UnityEngine;
//using System.Collections;

public class Move : MonoBehaviour
{
    public float speed = 30;
    public float speed_rotation = 3;
    public float jump_power = 15;
    public float gravity = 20;

    private CharacterController _characterController;
    private float _forward;
    private float _right;
    private Vector3 _moveVector;
    private float _gravityForce;


    void Start()
    {
        _characterController = GetComponent<CharacterController>();

    }

    void FixedUpdate()
    {
        var MZ = Input.GetAxis("Vertical");
        var MX = Input.GetAxis("Horizontal");

        _moveVector = transform.TransformDirection(Vector3.forward) * MZ;
        _moveVector += transform.TransformDirection(Vector3.right) * MX;

        if (_characterController.isGrounded)
        {
            _moveVector *= speed;
        }
        else
        {
            _moveVector *= speed * .3f;
        }

        GravityGame();

        _characterController.Move(_moveVector * Time.deltaTime);

    }

    void GravityGame()
    {
        _moveVector.y = _gravityForce;

        if (!_characterController.isGrounded)
        {
            _gravityForce -= gravity * Time.deltaTime;
        }
        else
        {
            _gravityForce = -1f;
        }

        if (Input.GetKey(KeyCode.Space) && _characterController.isGrounded)
        {
            _gravityForce = jump_power;
        }
    }

}