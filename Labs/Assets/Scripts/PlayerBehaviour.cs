using System.Collections;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public CharacterController controller;

    [Header("Movement Properties")]
    public float maxSpeed = 10.0f;
    public float gravity = -30.0f;
    public float jumpHeight = 3.0f;
    public Vector3 velocity;

    [Header("Ground Detection Properties")]
    public Transform groundPoint;
    public float groundRadius = 0.5f;
    public LayerMask groundMask;
    public bool isGrounded;
    public Transform respawnPlayerPosition;
    private bool isRespawning;

    public Joystick leftJoystick;
    public GameObject miniMap;

    private HealthBarController healthBarController;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        healthBarController = FindAnyObjectByType<HealthBarController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRespawning)
        {
            transform.position = respawnPlayerPosition.position;
            return;
        }
        
        isGrounded = Physics.CheckSphere(groundPoint.position, groundRadius, groundMask);

        if (isGrounded && velocity.y < 0.0f)
        {
            velocity.y = -2.0f;
        }

        float x = Input.GetAxis("Horizontal") + leftJoystick.Horizontal;
        float z = Input.GetAxis("Vertical") + leftJoystick.Vertical;



        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * maxSpeed * Time.deltaTime);

        

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(groundPoint.position, groundRadius);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathPlane") && !isRespawning)
        {
            StartCoroutine(RespawnPlayer());
        }

        if (other.CompareTag("Hazard"))
        {
            healthBarController.GetDamage(20);
        }
    }

    IEnumerator RespawnPlayer()
    {
        isRespawning = true;
        isGrounded = Physics.CheckSphere(groundPoint.position, groundRadius, groundMask);

        yield return new WaitForSeconds(.1f); 

        isRespawning = false;
    }

    public void JumpButton()
    {
        if (isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }
    }

    public void MapButton()
    {
        miniMap.SetActive(!miniMap.activeInHierarchy);
    }

}
