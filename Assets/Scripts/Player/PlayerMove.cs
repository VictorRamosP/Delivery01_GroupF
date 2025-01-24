using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float Speed = 5.0f;

    Rigidbody2D _rigidbody;
    Animator _animator;
    private float _horizontalDir; // Horizontal move direction value [-1, 1]

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Vector2 velocity = _rigidbody.linearVelocity;
        velocity.x = _horizontalDir * Speed;
        _rigidbody.linearVelocity = velocity;

        _animator.SetBool("Walking", _horizontalDir != 0);

        //spin the character
        if (_horizontalDir != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(_horizontalDir), 1, 1);
        }
    }

    // NOTE: InputSystem: "move" action becomes "OnMove" method
    void OnMove(InputValue value)
    {
        // Read value from control, the type depends on what
        // type of controls the action is bound to
        var inputVal = value.Get<Vector2>();
        _horizontalDir = inputVal.x;
    }
}
