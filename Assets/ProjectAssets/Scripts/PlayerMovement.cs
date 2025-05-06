using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private int maxExtraJumps;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpRaycastLenght;
    [SerializeField] private LayerMask jumpLayerMask;

    private int currentExtraJumps;
    private float movementAxis;
    private bool isGrounded;
    private bool canJump;

    private Rigidbody2D rigidBody2D;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();

        currentExtraJumps = maxExtraJumps;
    }

    private void FixedUpdate()
    {
        rigidBody2D.linearVelocityX = movementAxis * movementSpeed;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, jumpRaycastLenght, jumpLayerMask);

        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isGrounded)
        {
            canJump = true;
            currentExtraJumps = maxExtraJumps;
        }
        if (collision.transform.tag == "FinishObject")
        {
            SceneManager.LoadScene("Results");
        }
    }
    public void OnMovement(InputAction.CallbackContext context)
    {
        movementAxis = context.ReadValue<float>();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (canJump || currentExtraJumps > 0)
            {
                rigidBody2D.linearVelocityY = 0;
                rigidBody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                canJump = false;

                if (!isGrounded)
                {
                    currentExtraJumps--;
                }
            }
        }
    }
}