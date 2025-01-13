using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DeathMovement : MonoBehaviour
{
    private Vector2 movimento;
    public float speed;
    public bool dash = true;
    bool dashPress = false;
    public float dashTime, dashSpeed, dashCD;
    public Vector3 velocity;
    public TrailRenderer dashEffect;
    public float StopTime = 1f;
    public float StopTimeDash = 0.15f;
    private Vector3 move;
    private Rigidbody rb;

    private Animator _animator;
    public static DeathMovement instance;

    public void Awake()
    {
        dashEffect = GetComponentInChildren<TrailRenderer>();
        dashEffect.enabled = false;
        _animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        instance = this;
    }


    public void SetMovement(InputAction.CallbackContext value)
    {
        movimento = value.ReadValue<Vector2>();
    }

    public void SetDash(InputAction.CallbackContext context)
    {
        if(context.action.triggered && context.action.ReadValue<float>() != 0 && context.action.phase == InputActionPhase.Performed) 
        { 
            dashPress = true;
            if(dash == true)
            {
                _animator.SetTrigger("Dash");
            }

        } else
        {
            dashPress = false;
        }
    } 

    public void MovePlayer()
    {

        move = new Vector3(movimento.x, 0, movimento.y);
        rb.AddForce(move * speed, ForceMode.Impulse);

        if(movimento != Vector2.zero){
            _animator.SetBool("Moving", true);
        } else {
            _animator.SetBool("Moving", false);
        }

        Vector3 direction = this.rb.velocity;
        direction.y = 0;


        if (movimento.sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
        {
            this.transform.rotation = Quaternion.LookRotation(-direction, Vector3.up);
        }
        else
        {
            this.rb.angularVelocity = Vector3.zero;
        }


        //var Angle = Mathf.Atan2(-move.x, -move.z) * Mathf.Rad2Deg;
        //var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, Angle, ref currentVelocity, smoothTime);
        //this.transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);

        move = Vector3.zero;
       

        //transform.Translate(move * speed * Time.deltaTime, Space.World);
    }



    private void Look()
    {

    }

    void Update()
    {


    }

    void FixedUpdate()
    {
        if (GameController.ReaperParar == true)
        {
            rb.velocity = Vector3.zero;
            speed = 0;
            StartCoroutine(Parado());
        }
        MovePlayer();
        STDash();
    }

    public void STDash()
    {
        if (dash == true && dashPress == true) 
        {
            if (PlayerAttack.instance.isAttacking == false)
            {
                StartCoroutine(Dash());

            }
        }

    }

    public IEnumerator Dash()
    {

        dashEffect.enabled = true;
        dash = true;
        velocity = new Vector3(movimento.x * dashSpeed, 0, movimento.y * dashSpeed);
        transform.Translate(velocity * Time.deltaTime, Space.World);
        yield return new WaitForSeconds(dashTime);
        dash = false;
        velocity = Vector3.zero;
        move = Vector3.zero;
        dashEffect.enabled = false;
        //GameController.ReaperParar = true;
        //StartCoroutine(ParadoDash());
        yield return new WaitForSeconds(dashCD);
        dash = true;
        
    }

    public IEnumerator Parado()
    {
        yield return new WaitForSeconds(StopTime);
        GameController.ReaperParar = false;
        speed = 1;
    }

    public IEnumerator ParadoDash()
    {
        yield return new WaitForSeconds(StopTimeDash);
        GameController.ReaperParar = false;
        speed = 1;
    }

}
