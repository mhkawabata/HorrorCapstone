using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMoveScript : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    private Animator animator;

    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            controller.Move(direction * speed * Time.deltaTime);
            animator.SetBool("walk", true);
        }

        else animator.SetBool("walk", false);

        if (Input.GetButtonDown("Pickup"))
        {
            StartCoroutine(ItemPickup());
        }
    }

    IEnumerator ItemPickup()
    {
        animator.SetBool("pickup", true);
        yield return new WaitForSeconds(1f);
        animator.SetBool("pickup", false);
    }
}
