using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Vector2 movimento;
    public float speed;
    public bool dash = true;
    bool dashPress = false;
    public float dashTime, dashSpeed, dashCD;
    public Vector3 velocity;
    public TrailRenderer dashEffect;
    public static bool parar = false;
    public Vector3 move;

    private Rigidbody rb;

    private Animator _animator;
    public static Movement instance;

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

        if (movimento != Vector2.zero)
        {
            _animator.SetBool("Moving", true);
        }
        else
        {
            _animator.SetBool("Moving", false);
        }

        Vector3 direction = this.rb.velocity;
        direction.y = 0;

        if (movimento.sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
        {
            this.transform.rotation = Quaternion.LookRotation(-direction, -Vector3.up);
        }
        else
        {
            this.rb.angularVelocity = Vector3.zero;
        }

        move = Vector3.zero;




        //transform.Translate(move * speed * Time.deltaTime, Space.World);
    }

    
    

    private void Look()
    {

    }


    //public Vector3 movementDirection { get; private set; }

    void Update()
    {
        //float horizontal = movimento.x;
        //float vertical = movimento.y;
        
        //movementDirection = new Vector3(horizontal, 0, vertical).normalized;    
    }

    void FixedUpdate()
    {
        MovePlayer();
        STDash();
        
    }

    public IEnumerator Parado()
    {
        yield return new WaitForSeconds(3f);
        Movement.parar = false;

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
        yield return new WaitForSeconds(dashCD);
        dash = true;
        dashEffect.enabled = false;
    }

}