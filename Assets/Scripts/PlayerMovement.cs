using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigi;

    [SerializeField] private float _speed;     // ความเร็วเดิน
    [SerializeField] private float _jumpPower;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private LayerMask _wallLayer;

    private Animator _ani;
    private BoxCollider2D _boxCollider;
    private float _walljumpcooldown;
    private float _horizontalInput;



    private void Awake()
    {
        _rigi = GetComponent<Rigidbody2D>();
        _ani = GetComponent<Animator>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");


        // Flip player
        if (_horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (_horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);


        // Animation parameters
        _ani.SetBool("run", _horizontalInput != 0);
        _ani.SetBool("grounded", _isGrounded());


        // Wall Jump logic
        if (_walljumpcooldown < 0.2f)
        {

            _rigi.velocity = new Vector2(_horizontalInput * _speed, _rigi.velocity.y);

            if (_onWall() && !_isGrounded())
            {
                _rigi.gravityScale = 0;
                _rigi.velocity = Vector2.zero;
            }
            else
                _rigi.gravityScale = 1;

            if (Input.GetKey(KeyCode.Space))
                Jump();

        }
        else
            _walljumpcooldown += Time.deltaTime;


    }


    private void Jump()
    {
        if (_isGrounded())
        {
            _rigi.velocity = new Vector2(_rigi.velocity.x, _jumpPower);
            _ani.SetTrigger("jump");
        }
        else if (_onWall() && !_isGrounded())
        {
            if (_horizontalInput == 0)
            {
                _rigi.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
                _rigi.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);

            _walljumpcooldown = 0;
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {


    }

    private bool _isGrounded()
    {
        // ยิง box ray ลงไปนิดนึง เพื่อตรวจว่ามี ground ไหม
        RaycastHit2D raycastHit = Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size, 0f, Vector2.down, 0.1f, _groundLayer);
        return raycastHit.collider != null;
    }

    private bool _onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, _wallLayer);
        return raycastHit.collider != null;
    }
}
