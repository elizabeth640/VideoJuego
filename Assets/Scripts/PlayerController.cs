using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController obj;

    public GameObject bulletP;
    private Rigidbody2D rig2D;//3 variable para controlar el componente
    private float horizontal;//1
    private Animator animator;

    public float jump = 4;
    public float lastShoot;

    public int health = 5;

    public bool isInmune = false;
    public float isInmuneTimeCnt = 0.0f;
    public float inmuneTime = 0.5f;
    private SpriteRenderer spr;
    // Start is called before the first frame update
    private void Awake()
    {
        obj = this;
        rig2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        animator = GetComponent<Animator>();//Se tiene acceso al componente animator
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(UIManager.obj.gamePause)
        {
            horizontal = 0.0f;
            return;
        }
        horizontal = Input.GetAxisRaw("Horizontal");//2 Capturar el input del teclado, saber lo que se esta pulsando 1 o -1
        
        if(horizontal<0.0f)
        {
            transform.localScale= new Vector2(-1.0f, 1.0f);
        }
        else if (horizontal > 0.0f)
        {
            transform.localScale= new Vector2(1.0f, 1.0f);
        }

        if(isInmune)
        {
            spr.enabled = !spr.enabled;
            isInmuneTimeCnt -= Time.deltaTime;
            if(isInmuneTimeCnt <= 0.0f)
            {
                isInmune = false;
                spr.enabled = true;
            } 
        }
    }

    private void FixedUpdate()//6
    {
        rig2D.velocity = new Vector2(horizontal, rig2D.velocity.y);//7 modificar la velocidad en x y se queda igual
        if(Input.GetButton("Jump")&& Jump.isGrounded && UIManager.obj.gamePause == false)//9
        {
            rig2D.velocity = new Vector2(rig2D.velocity.x,jump);//10
            AudioController.obj.playJump();
        }

        if(Input.GetButtonDown("Fire1") && Time.time > lastShoot + 0.25f && UIManager.obj.gamePause == false) 
        {
            Shoot();
            lastShoot = Time.deltaTime;
        }

        if(Jump.isGrounded == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }

        if(Jump.isGrounded == true)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Run", horizontal != 0.0f);
        }
    }
    private void Shoot()
    {
        Vector3 direc;
        if(transform.localScale.x == 1.0f)
        {
            direc = Vector2.right;
        }
        else 
        {
            direc = Vector2.left;
        }
       GameObject bullet = Instantiate(bulletP, transform.position + direc * 0.3f, Quaternion.identity); 

       bullet.GetComponent<Bullet>().SetDirection(direc);
       AudioController.obj.playShoot();
    }

    public void addLive()
    {
        health++;

        if(health > UIManager.obj.maxHealth)
        {
            health = UIManager.obj.maxHealth;
        }
    }

    public void Hit()
    {
        if(health <= 0)
        {
            return;
        }
        health--;
        goInmune();
        UIManager.obj.updateLives();
        if(health == 0)
        {
            animator.SetBool("Dead", true);
            //Destroy(gameObject, 0.5f);
        }
    }

    private void OnDestroy()
    {
        obj = null;
    }

    public void goInmune()
    {
        isInmune = true;
        isInmuneTimeCnt = inmuneTime;
    }
}
