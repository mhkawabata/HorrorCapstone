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
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    

    private void Awake()
    {
        animator = GetComponent<Animator>();
        instance = this;
    }
    void Update()
    {
        if(wasdMove == false && thirdMove == false)
        {
            //movement
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {
            //rotate model to direction of movement
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

            //move, play walk animation
                controller.Move(direction * speed * Time.deltaTime);
                animator.SetBool("walk", true);
            }
            else animator.SetBool("walk", false);
        }
    
        else if(wasdMove == true)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(vertical, 0, -horizontal).normalized;

            if(direction.magnitude >= 0.1f)
            {
            //rotate model to direction of movement
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0, angle, 0);

            //move, play walk animation
                controller.Move(direction * speed * Time.deltaTime);
                animator.SetBool("walk", true);
            }
            else animator.SetBool("walk", false);
        }

        else if(wasdMove == false && thirdMove == true)
        {
            //movement
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(-horizontal, 0, -vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {
                //rotate model to direction of movement
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                //move, play walk animation
                controller.Move(direction * speed * Time.deltaTime);
                animator.SetBool("walk", true);
            }
            else animator.SetBool("walk", false);
        }
        

     //pick up item
        if (Input.GetButtonDown("Pickup"))
            StartCoroutine(ItemPickup());
        
    }



    IEnumerator ItemPickup()
    {
        animator.SetBool("pickup", true);
        yield return new WaitForSeconds(1f);
        animator.SetBool("pickup", false);
    }

    
}
