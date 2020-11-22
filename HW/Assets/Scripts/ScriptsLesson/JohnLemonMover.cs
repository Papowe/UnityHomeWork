using UnityEngine;

public class JohnLemonMover : MonoBehaviour
{    
    [SerializeField] private float speedPlayer = 4f;
    [SerializeField] private float speedRotation = 90f;
    [SerializeField] private float forceJump = 5f;
    [SerializeField] private bool isFloor = true;

    private float rotation;
    private float direction;
    private Rigidbody playerRigidbody;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {        
        direction = Input.GetAxis("Vertical");
        rotation = Input.GetAxis("Horizontal");

        if (direction < 0)
        {
            rotation = -rotation;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isFloor.Equals(true))
        {
            playerRigidbody.AddForce(Vector3.up * forceJump, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {  
        playerRigidbody.MovePosition(transform.position + transform.forward * direction * speedPlayer * Time.fixedDeltaTime);

        Quaternion deltaRotation = Quaternion.Euler(Vector3.up * rotation * speedRotation * Time.deltaTime);
        playerRigidbody.MoveRotation(playerRigidbody.rotation * deltaRotation);              
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            isFloor = true;
        }        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            isFloor = false;
        }
    }
}
