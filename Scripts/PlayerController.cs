using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private float _moveSpeed;
    private Vector2 _moveDirection;

    public void OnMove(InputAction.CallbackContext context)  
    {
        _moveDirection = context.ReadValue<Vector2>();
    }

    private void Move(Vector2 direction)
    {
        float scaleMoveSpeed = _moveSpeed * Time.deltaTime;

        Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);
        transform.position += moveDirection * scaleMoveSpeed;
    }

    private void Start()
    {
        
        gameManager = GameManager.instance;
        print(gameManager != null);
    }

    private void Update()
    {
        Move(_moveDirection);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (gameManager != null)
            {
                gameManager.IncreaseScore(1);
            }
            Destroy(other.gameObject);
        }
    }

}
