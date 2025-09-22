using UnityEngine;
using UnityEngine.InputSystem;

public class IsometricPlayerController : MonoBehaviour
{
    InputAction moveAction;
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer sr;

    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector2 rawMoveVector;
    [SerializeField] private Vector2 moveVector;
    [SerializeField] private Vector2 normalizedMoveVector;
    [SerializeField] private int xDirection;
    [SerializeField] private int yDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        rawMoveVector = moveAction.ReadValue<Vector2>();
        moveVector.x = rawMoveVector.x;
        moveVector.y = rawMoveVector.y;
        normalizedMoveVector = moveVector.normalized;

        xDirection = Mathf.RoundToInt(normalizedMoveVector.x);
        yDirection = Mathf.RoundToInt(normalizedMoveVector.y);

        animator.SetInteger("X-Direction", xDirection);
        animator.SetInteger("Y-Direction", yDirection);

        if (xDirection > 0)
            sr.flipX = true;
        else
            sr.flipX = false;

        // transform.Translate(moveVector * moveSpeed * Time.deltaTime);
        rb.linearVelocity = (normalizedMoveVector * moveSpeed); 
    }
}
