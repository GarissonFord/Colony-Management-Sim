using UnityEngine;
using UnityEngine.InputSystem;

public class IsometricPlayerController : MonoBehaviour
{
    InputAction moveAction;
    [SerializeField] Animator animator;

    [SerializeField] private float moveSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveVector = moveAction.ReadValue<Vector2>();

        animator.SetFloat("X-Direction", moveVector.x);
        animator.SetFloat("Y-Direction", moveVector.y);

        transform.Translate(moveVector * moveSpeed * Time.deltaTime);
    }
}
