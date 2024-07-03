using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayeMove : MonoBehaviour
{
    private float Move;
    private float Walkl;
    private bool IsRight = true;
    [SerializeField] public float speed = 10f;
    [SerializeField] public float Jump = 15f;

    [SerializeField] private Transform GroudCkeck;
    [SerializeField] private Rigidbody2D Rb;
    [SerializeField] private LayerMask GroudLayer;
    [SerializeField] private Animator amin;

    [SerializeField] private float DashBoot;
    [SerializeField] private float DashTime;
    private float _DashTime;
    private bool IsDashing = false;

    [SerializeField] private GameObject GhostEffect;
    private Coroutine DashEffectCorotine;
    [SerializeField] private float GhostDelaySecond;
    
    // Start is called before the first frame update
    void Start()
    {
       Rb = GetComponent<Rigidbody2D>();
        amin = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Rb.velocity = new Vector2(Walkl * speed, Rb.velocity.y);

    }
    void Update()
    {
        Walkl = Input.GetAxisRaw("Horizontal");
        this.jumping();
        this.Animation();
        this.Flip();
        this.Dash();

    }
   private void Dash()
    {
      if(Input.GetKeyDown(KeyCode.RightShift) && _DashTime <= 0 && IsDashing == false)
        {
            speed += DashBoot;
            _DashTime = DashTime;
            IsDashing = true;
            this.StartDashEffect();
        }
      
      if(_DashTime <= 0 && IsDashing == true)
        {
            speed -= DashBoot;
            IsDashing = false;
            this.StopDashEffect();
        }
        else
        {
            _DashTime -=  Time.deltaTime;
        }
    }
    private void Flip()
    {
       
        
        if (IsRight && Walkl < 0f || !IsRight && Walkl > 0F)
        {
            IsRight = !IsRight;
            /*
            Vector3 locascale = transform.localScale;
           locascale.x *= -1f;
            transform.localScale = locascale;
            */
            transform.Rotate(0f, 180f, 0f);
        }
        
    }
    public void Animation()
    {
        amin.SetFloat("Walk", Mathf.Abs(Walkl));
       // if (Input.GetMouseButtonDown(0))
        {
         //   amin.SetTrigger("Atack");
        }
        amin.SetFloat("Walk", Mathf.Abs(Walkl) );
        if(Move >= 0.1f || Move <= -0.1f)
        {
            amin.SetBool("Run",true);
        }
        else
        {
            amin.SetBool("Run", false);
        }
    }
    private void jumping()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1) && IsGrounded())
        {
            Rb.velocity = new Vector2(Rb.velocity.x, Jump);
        }

        if(Input.GetKeyDown(KeyCode.Mouse1) && IsGrounded())
        {
            Rb.velocity = new Vector2(Rb.velocity.x, Rb.velocity.y * 0.5f);
        }
        /*
        if (Input.GetButtonDown("Jump") && IsGrounded( ))
        {
            Rb.velocity = new Vector2(Rb.velocity.x, Jump);
        }
        if(Input.GetButtonUp("Jump") && Rb.velocity.y > 0f)
        {
            Rb.velocity = new Vector2(Rb.velocity.x , Rb.velocity.y * 0.5f);
        }
        */
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(GroudCkeck.position, 0.2f, GroudLayer);

    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Group"))
        {
            amin.SetBool("Jump", false);
        }

      
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Group"))
        {
            amin.SetBool("Jump", true);
        }
    }
    private void StopDashEffect()
    {
        if (DashEffectCorotine != null) StopCoroutine(DashEffectCorotine);
        Sound.instance.dashh();
    }
    private void StartDashEffect()
    {
        if(DashEffectCorotine != null) StopCoroutine(DashEffectCorotine);
        {
            DashEffectCorotine = StartCoroutine(DashEffetCorotine());
        }
    }
  IEnumerator DashEffetCorotine()
    {
        while (true)
        {
            GameObject ghost = Instantiate(GhostEffect , transform.position , transform.rotation);
            yield return new WaitForSeconds(GhostDelaySecond);
            Destroy(ghost , 0.5f);
        }
        
    }
}
