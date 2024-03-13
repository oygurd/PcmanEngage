using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
    public class StarterAssetsInputs : MonoBehaviour
    {
        [Header("Character Input Values")]
        public Vector2 move;
        public Vector2 look;
        public bool jump;
        public bool sprint;

        [Header("Movement Settings")]
        public bool analogMovement;

        [Header("Mouse Cursor Settings")]
        public bool cursorLocked = true;
        public bool cursorInputForLook = true;

        [Header("Old Input System Settings")]
        [Range(0.05f, 100.0f)]
        public float lookSensetivity = 0.2f;
        public KeyCode sprintKey = KeyCode.LeftShift;


#if ENABLE_LEGACY_INPUT_MANAGER
	    private void Update()
		{
			float horizontalInput = Input.GetAxisRaw("Horizontal");
			float verticalInput = Input.GetAxisRaw("Vertical");

            float mouseHorizontalDelta = Input.GetAxis("Mouse X");
            float mouseVerticalDelta = Input.GetAxis("Mouse Y");

            Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized;
			Vector2 lookDirection = new Vector2(mouseHorizontalDelta, -mouseVerticalDelta)*lookSensetivity;
			MoveInput(moveDirection);
			LookInput(lookDirection);
			JumpInput(Input.GetButton("Jump"));
			SprintInput(Input.GetKey(sprintKey));
		}
        
#elif ENABLE_INPUT_SYSTEM
//essentially could have been an #else, but wanted to be explicit about new input system events.

        public void OnMove(InputValue value)
        {
            MoveInput(value.Get<Vector2>());
        }

        public void OnLook(InputValue value)
        {
            if (cursorInputForLook)
            {
                LookInput(value.Get<Vector2>());
            }
        }

        public void OnJump(InputValue value)
        {
            JumpInput(value.isPressed);
        }

        public void OnSprint(InputValue value)
        {
            SprintInput(value.isPressed);
        }

#endif

            public void MoveInput(Vector2 newMoveDirection)
        {
            move = newMoveDirection;
        }

        public void LookInput(Vector2 newLookDirection)
        {
            look = newLookDirection;
        }

        public void JumpInput(bool newJumpState)
        {
            jump = newJumpState;
        }

        public void SprintInput(bool newSprintState)
        {
            sprint = newSprintState;
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            SetCursorState(cursorLocked);
        }

        private void SetCursorState(bool newState)
        {
            Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }

}