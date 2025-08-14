using UnityEngine;
using UnityEngine.InputSystem;

public class ccPlayerMovement3D : MonoBehaviour
{

    public CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    public float playerSpeed = 2.0f;
    public float jumpHeight = 1.0f;
    public float sprintMagnitude = 2.0f;
    private float gravityValue = -9.8f;
    private float initialPlayerSpeed = 0;
    

    public InputSystem_Actions playerMovement;
    private InputAction move;
    private InputAction sprint;
    private InputAction jump;
    private InputAction crouch;
    

    public SPSystem staminaSys;
    public Transform playerHead;

    private Vector3 v3playerHeadPosition;

    private bool DoubleJumpReady = false,canDoubleJump = false;

    private void Awake()
    {
        playerMovement = new InputSystem_Actions();
        initialPlayerSpeed = playerSpeed;
        v3playerHeadPosition = playerHead.position;
    }
    private void OnEnable()
    {
        crouch = playerMovement.Player.Crouch;
        jump = playerMovement.Player.Jump;
        sprint = playerMovement.Player.Sprint;
        move = playerMovement.Player.Move;
        move.Enable();
        sprint.Enable();
        jump.Enable();
        crouch.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        sprint.Disable();
        jump.Disable();
        crouch.Disable();
    }

    void PlayerJump()
    {
        playerVelocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravityValue );
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        //<jump>
        if ((jump.ReadValue<float>() == 1) && (controller.isGrounded))
        {
            canDoubleJump = true;
            PlayerJump();
        }
        if (canDoubleJump && jump.ReadValue<float>() == 0 && !controller.isGrounded)
        {
            DoubleJumpReady = true;
        }
        if ((jump.ReadValue<float>() == 1) && DoubleJumpReady)
        {
            PlayerJump();
            DoubleJumpReady = false;
            canDoubleJump = false;
        }
        //</jump>

        //<sprint>
        if (((sprint.ReadValue<float>() == 1) && staminaSys.SP > 0 && !staminaSys.isSPCooldown) && playerSpeed != (initialPlayerSpeed * sprintMagnitude))
        {
            playerSpeed *= sprintMagnitude;
            staminaSys.isSprinting = true;
        }
        else if ((playerSpeed != initialPlayerSpeed && (sprint.ReadValue<float>() == 0)) || staminaSys.SP <= 0)
        {
            playerSpeed = initialPlayerSpeed;
            staminaSys.isSprinting = false;                    
        }
        

    }
    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0) {
            playerVelocity.y = 0f;
        }
        Vector3 v3move = new (move.ReadValue<Vector2>().x, 0, move.ReadValue<Vector2>().y);
        v3move = Vector3.ClampMagnitude(v3move, 1f); // fix for fast diagonal movement
        
        
       
        //gravity
        playerVelocity.y += gravityValue * Time.deltaTime;

       Vector3 finalMove = transform.TransformDirection((v3move * playerSpeed) + (playerVelocity.y * Vector3.up));
       controller.Move(finalMove * Time.deltaTime);

        //crouch
        /*
        if (crouch.ReadValue<float>() == 1 || playerHead.transform.position == v3playerHeadPosition)
        {
            playerHead.transform.position = v3playerHeadPosition - new Vector3(0,1,0);
        }
        else if (playerHead.transform.position.y != 1 && playerHead.transform.position == v3playerHeadPosition - new Vector3(0, 1, 0)) { playerHead.transform.position = playerHead.transform.position + new Vector3(0, 1, 0); }
        */
        

    }
}
