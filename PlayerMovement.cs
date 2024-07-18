using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public ParticleSystem jumpParticles; // Référence au ParticleSystem pour les particules de saut

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove)); // Mise à jour de la vitesse pour l'animation

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
            StartCoroutine(ActivateJumpParticles());
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    // Coroutine pour activer les particules pendant 0.5 secondes
    private IEnumerator ActivateJumpParticles()
    {
        if (jumpParticles != null)
        {
            jumpParticles.Play();
            yield return new WaitForSeconds(0.5f);
            jumpParticles.Stop();
        }
    }
}
