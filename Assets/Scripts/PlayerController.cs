using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;
    public float JumpForce;
    public LayerMask GroundLayer;
    public bool groundcheck;


    private Rigidbody2D _rigidBody;
    public Animator _animator;
    private SpriteRenderer _spriteRenderer;
    public ParticleSystem runDustParticles;

    public bool isJumping;

    [SerializeField] private Transform attackHitbox;
    [SerializeField] private Transform heavyAttackHitbox;
    [SerializeField] private float hitboxOffsetX = 0.9f;
    private bool facingRight = true;

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
        {
            HandleRunParticles();
        }


        if ((isJumping) && groundcheck)
        {
            _rigidBody.AddForce(Vector2.up * JumpForce);
        }

        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), 0);
        transform.Translate(horizontal * Time.deltaTime * MoveSpeed, 0, 0);

        _animator.SetFloat("Horizontal", Mathf.Abs(horizontal));
        if (horizontal > 0 && !facingRight)
            Flip();
        else if (horizontal < 0 && facingRight)
            Flip();
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

    void HandleRunParticles()
    {
        bool isRunning = _animator.GetCurrentAnimatorStateInfo(0).IsName("Run");

        if (isRunning && !runDustParticles.isPlaying)
        {
            runDustParticles.Play();
        }
        else if (!isRunning && runDustParticles.isPlaying)
        {
            runDustParticles.Stop();
        }
    }
    void Flip()
    {
        facingRight = !facingRight;

       
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

       
        Vector3 hitboxPos = attackHitbox.localPosition;
        hitboxPos.x = facingRight ? hitboxOffsetX : -hitboxOffsetX;
        attackHitbox.localPosition = hitboxPos;

        Vector3 heavyPos = heavyAttackHitbox.localPosition;
        heavyPos.x = facingRight ? hitboxOffsetX : -hitboxOffsetX;
        heavyAttackHitbox.localPosition = heavyPos;
    }
}








