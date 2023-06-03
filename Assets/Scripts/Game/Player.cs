using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player")]
    public Camera playerCamera;
    public float walkSpeed;
    public float runSpeed;
    public float jumpPower;
    public float gravity;

    public float lookSpeed;
    public float lookXLimit;

    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public bool canMove = true;

    CharacterController charachterController;

    private void Start()
    {
        charachterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (SinematicCam.Instance.isPlay == true)
        {
            if (ItemPick.Instance.isCar == false)
            {
                #region Movement
                Vector3 forward = transform.TransformDirection(Vector3.forward);
                Vector3 right = transform.TransformDirection(Vector3.right);

                bool isRunning = Input.GetKey(KeyCode.LeftShift);
                float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
                float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
                float movementDirectionY = moveDirection.y;
                moveDirection = (forward * curSpeedX) + (right * curSpeedY);
                #endregion
                #region Jumping
                if (Input.GetButton("Jump") && canMove && charachterController.isGrounded)
                {
                    moveDirection.y = jumpPower;
                }
                else
                {
                    moveDirection.y = movementDirectionY;
                }
                if (!charachterController.isGrounded)
                {
                    moveDirection.y -= gravity * Time.deltaTime;
                }
                #endregion
                #region Rotation
                charachterController.Move(moveDirection * Time.deltaTime);

                if (canMove)
                {
                    rotationX += Input.GetAxis("Mouse Y") * lookSpeed;
                    rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
                    playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
                    transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
                }
                #endregion
            }

        }

    }

}
