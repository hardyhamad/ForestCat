using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D characterController;
    public float runspeed = 40f;
    float horizontalmove = 0f;
    bool jump = false;
    private Animator playerAnimator;


    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontalmove = Input.GetAxisRaw("Horizontal") * runspeed;

        playerAnimator.SetFloat("speed", Mathf.Abs(horizontalmove));


        if (Input.GetButtonDown("Jump"))
        {
            playerAnimator.SetBool("jump", true);
            jump = true;

        }

    }
    private void FixedUpdate()
    {
        characterController.Move(horizontalmove * Time.fixedDeltaTime, false, jump);
        jump = false;
        playerAnimator.SetBool("jump", false);
    }

}
