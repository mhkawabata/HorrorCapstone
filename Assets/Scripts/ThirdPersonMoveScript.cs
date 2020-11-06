using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMoveScript : MonoBehaviour
{
    public CharacterController controller;
    private Animator animator;
    UI ui;

    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        ui = UI.instance;
    }
    void Update()
    {
    //movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            controller.Move(direction * speed * Time.deltaTime);
            animator.SetBool("walk", true);
        }

        else animator.SetBool("walk", false);

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

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            ui.Die();
        }

        else return;
    }

    
}
