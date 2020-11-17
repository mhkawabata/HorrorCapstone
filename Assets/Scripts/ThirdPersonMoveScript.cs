using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMoveScript : MonoBehaviour
{
    public static ThirdPersonMoveScript instance;
    public CharacterController controller;
    private Animator animator;
    public bool wasdMove = false;
    public bool thirdMove = false;
    public bool fourthMove = false;
    public bool movementEnabled = true;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    float horizontal, vertical;
    

    private void Awake()
    {
        animator = GetComponent<Animator>();
        instance = this;
    }
    void Update()
    {
        if (movementEnabled == true)
        {

            if (wasdMove == false && thirdMove == false && fourthMove == false)
            {
                GetInput(out horizontal, out vertical);
                Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

                if (direction.magnitude >= 0.1f)
                {
                    Walk(direction);
                }
                else animator.SetBool("walk", false);
            }

            else if (wasdMove == true)
            {
                GetInput(out horizontal, out vertical);
                Vector3 direction = new Vector3(vertical, 0, -horizontal).normalized;

                if (direction.magnitude >= 0.1f)
                    Walk(direction);
                else animator.SetBool("walk", false);
            }

            else if (wasdMove == false && thirdMove == true)
            {
                //movement
                GetInput(out horizontal, out vertical);
                Vector3 direction = new Vector3(-horizontal, 0, -vertical).normalized;

                if (direction.magnitude >= 0.1f)
                    Walk(direction);
                else animator.SetBool("walk", false);
            }

            else if (fourthMove == true)
            {
                GetInput(out horizontal, out vertical);
                Vector3 direction = new Vector3(-vertical, 0, horizontal).normalized;

                if (direction.magnitude >= 0.1f)
                    Walk(direction);
                else animator.SetBool("walk", false);
            }

            //pick up item
            if (Input.GetButtonDown("Pickup"))
                StartCoroutine(ItemPickup());
        }
    }

    IEnumerator ItemPickup()
    {
        animator.SetBool("pickup", true);
        yield return new WaitForSeconds(1f);
        animator.SetBool("pickup", false);
    }

    public IEnumerator EnterNewRoom()
    {
        animator.SetBool("walk", false);
        movementEnabled = false;
        yield return new WaitForSeconds(1f);
        movementEnabled = true;
    }

    private static void GetInput(out float horizontal, out float vertical)
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void Walk(Vector3 direction)
    {
        //rotate model to direction of movement
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        //move, play walk animation
        controller.Move(direction * speed * Time.deltaTime);
        animator.SetBool("walk", true);
    }
}
