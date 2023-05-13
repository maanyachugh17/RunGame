using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 30f;
    public float gravityY = 9.81f;

    private Rigidbody rb;
    private bool jumped = false;
    private bool onPlane = false;
    private bool isPlayingOnCeiling = false;
    private float defaultGravityY;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        defaultGravityY = Physics.gravity.y;
    }

    void Update()
    {
        float moveZ = Input.GetAxisRaw("Vertical");
        float moveX = Input.GetAxisRaw("Horizontal");
        Vector3 movement = new Vector3(moveX * moveSpeed, 0f, moveZ * moveSpeed);
        rb.velocity = movement;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (Physics.gravity.y > 0)
            {
                rb.AddForce(Vector3.down * 15.0f, ForceMode.Impulse);
            }
            else if (Physics.gravity.y < 0)
            {
                rb.AddForce(Vector3.up * 15.0f, ForceMode.Impulse);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (Physics.gravity.y > 0)
            {
                Physics.gravity = new Vector3(0, -gravityY, 0);
            }
            else if (Physics.gravity.y < 0)
            {
                Physics.gravity = new Vector3(0, gravityY, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumped = true;
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(Vector3.forward * moveSpeed, ForceMode.VelocityChange);
        onPlane = Physics.Raycast(transform.position, -transform.up, 0.6f);
        if (jumped && onPlane)
        {
            if (Physics.gravity.y > 0)
            {
                Physics.gravity = new Vector3(0, -50.0f, 0);
            }
            else if (Physics.gravity.y < 0)
            {
                Physics.gravity = new Vector3(0, 50.0f, 0);
            }
        }
        jumped = false;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Plane"))
        {
            onPlane = true;
        }
    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Plane"))
        {
            onPlane = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}



