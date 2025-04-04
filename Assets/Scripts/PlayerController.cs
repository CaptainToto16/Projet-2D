using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;
    public float JumpForce;
    public LayerMask GroundLayer;
    public bool groundcheck;


    private Rigidbody2D _rigidBody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    public bool isJumping;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        bool isJumping = Input.GetButtonDown("Jump");
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if ((isJumping) && groundcheck)
        {
            _rigidBody.AddForce(Vector2.up * JumpForce);
        }

        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), 0);
        transform.Translate(horizontal * Time.deltaTime * MoveSpeed, 0, 0);
        //if (isJumping) _rigidBody.AddForce(Vector2.up * JumpForce);
        _animator.SetFloat("Horizontal", Mathf.Abs(horizontal));
        if (horizontal > 0)
            _spriteRenderer.flipX = false;
        if (horizontal < 0)
            _spriteRenderer.flipX = true;
        _animator.SetFloat("Vertical", _rigidBody.linearVelocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        groundcheck = true;
        _animator.SetBool("jump", !groundcheck);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        groundcheck = false;
    }
}


