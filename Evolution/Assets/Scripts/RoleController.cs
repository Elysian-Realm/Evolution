using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoleController : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;
    Animator animator;
    AudioSource audio1;
    AudioSource audio2;
    SpriteRenderer spriteRenderer;
    public GameObject bullet;//子弹
    public GameObject groundCheckPoint;//外部绑定地面检查点（通过该点检查角色是否在地面上）
    Slider healthSlider;//血条
    Slider energySlider;//能量条
    public float initialSpeed = 5f;//初始速度
    float speed;//当前速度
    float horizontal;//水平轴输入
    public float flyDuration = 3f;//最长连续飞行时间
    float energy;//当前所剩飞行时间
    bool flyable = true;//判断是否接收飞行输入
    bool onGround;//判断是否在地面上
    public float jumpHeight = 2.5f;//最大跳跃高度
    public float shootBreak = 1f;//射击间隔，与武器种类有关
    float shootTimer;//射击cd计时器
    float lookDirection = 1f;//角色面向的方向，正数表示右，负数表示左
    public float rushBreak = 1f;//冲刺间隔
    float rushTimer;//冲刺cd计时器
    public float rushDistance = 5f;//冲刺距离
    float rushDuration = 0.2f;//完成一次冲刺所需时间
    bool isRushing = false;//判断是否正在冲刺
    public float maxHealth = 100f;//血量上限
    float health;//当前血量
    bool hit;//受击
    public float NonControlDuration = 0.2f;//受击后失控时间,即受击状态持续时间
    public float hitBreak = 0.3f;//两次受击之间的间隔，即受击后无敌时间
    float hitTimer;//受击计时器

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        healthSlider = GetComponentsInChildren<Slider>()[0];
        energySlider = GetComponentsInChildren<Slider>()[1];
        audio1 = GetComponents<AudioSource>()[0];
        audio2 = GetComponents<AudioSource>()[1];
        speed = initialSpeed;
        energy = flyDuration;
        shootTimer = shootBreak;
        health = maxHealth;
        hitTimer = hitBreak;
        energySlider.value = healthSlider.value = 1;
    }

    void Update()
    {
        GameManager.rolePosition = transform.position;

        if (!isRushing && !hit)
        {
            horizontal = Input.GetAxis("Horizontal");

            //jump
            if (onGround && Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("Jump");
                Vector2 v = rigidbody2D.velocity;
                v.y = Mathf.Sqrt(-2 * Physics2D.gravity.y * jumpHeight);
                rigidbody2D.velocity = v;
                flyable = false;
            }
            if (Input.GetKeyUp(KeyCode.Space)) flyable = true;

            if (Mathf.Abs(horizontal) > 0.01f)
            {
                lookDirection = horizontal;
                animator.SetBool("Move", true);
            }
            else
            {
                animator.SetBool("Move", false);
            }
            lookDirection = Mathf.Abs(lookDirection) / lookDirection;
            spriteRenderer.flipX = (lookDirection < 0);

            //shoot
            if (shootTimer == shootBreak && Input.GetKeyDown(KeyCode.J))
            {
                Shoot();
                shootTimer = 0;
            }
            if (shootTimer < shootBreak)
            {
                shootTimer += Time.deltaTime;
                if (shootTimer > shootBreak) shootTimer = shootBreak;
            }
        }

        onGround = Physics2D.OverlapCircle(groundCheckPoint.transform.position, 0.2f, 1 << 3);//Ground图层id为3
        animator.SetBool("OnGround", onGround);

        if (onGround && energy < flyDuration)
        {
            energy += Time.deltaTime;
            if (energy > flyDuration) energy = flyDuration;
            energySlider.value = energy / flyDuration;
        }

        //rush
        if (rushTimer == rushBreak && !hit && Input.GetKeyDown(KeyCode.K))
        {
            isRushing = true;
            rushTimer = 0;
            gameObject.layer = 14;//冲刺无敌帧
        }
        if (rushTimer < rushBreak)
        {
            rushTimer += Time.deltaTime;
            if (rushTimer > rushBreak) rushTimer = rushBreak;
        }
        if (rushTimer >= rushDuration)
        {
            isRushing = false;
            if (!hit) gameObject.layer = 7;//结束冲刺无敌帧
        }
        animator.SetBool("Rush", isRushing);

        if (hitTimer < hitBreak)
        {
            hitTimer += Time.deltaTime;
            if (hitTimer >= hitBreak)
            {
                hitTimer = hitBreak;
                Color color = spriteRenderer.color;
                color.a = 1f;
                spriteRenderer.color = color;
                if (!isRushing) gameObject.layer = 7;
            }
        }
        if (hitTimer >= NonControlDuration)
        {
            hit = false;
        }
    }

    private void FixedUpdate()
    {
        if (!hit)
        {
            if (isRushing)
            {
                rigidbody2D.velocity = new Vector2(lookDirection * rushDistance / rushDuration, 0);
            }
            else
            {
                Vector2 v = rigidbody2D.velocity;
                v.x = speed * horizontal;
                rigidbody2D.velocity = v;

                //fly
                if (flyable && !onGround && energy > 0 && Input.GetKey(KeyCode.Space))
                {
                    animator.SetBool("Fly", true);
                    rigidbody2D.AddForce(-2f * Physics2D.gravity * rigidbody2D.mass);
                    energy -= Time.fixedDeltaTime;
                    energySlider.value = energy / flyDuration;
                }
                else
                {
                    animator.SetBool("Fly", false);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //触碰Enemy
        if (other.gameObject.layer == 9)
        {
            Hit(other.transform);
            ChangeHealth(-10);
        }
    }

    void Shoot()
    {
        audio2.Play();
        animator.SetTrigger("Shoot");
        Vector3 offset = new Vector3(0.5f * transform.localScale.x * lookDirection, 0.2f * transform.localScale.y, 0);
        Instantiate(bullet, transform.position + offset, Quaternion.identity).GetComponent<Rigidbody2D>().AddForce(new Vector2(500 * lookDirection, 0));
    }

    public void ChangeHealth(float value)
    {
        health += value;
        healthSlider.value = health / maxHealth;
        if (health > maxHealth) health = maxHealth;
        else if (health <= 0)//dead
        {
            //转死亡画面
            // print("Game over");
        }
    }

    public void Hit(Transform other)
    {
        lookDirection = other.position.x - transform.position.x;
        lookDirection = Mathf.Abs(lookDirection) / lookDirection;
        spriteRenderer.flipX = (lookDirection < 0);
        hit = true;
        rigidbody2D.velocity = new Vector2(-lookDirection * 15f, 5f);
        Color color = spriteRenderer.color;
        color.a = 0.5f;
        spriteRenderer.color = color;
        gameObject.layer = 14;
        hitTimer = 0;
    }
}
