using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MechaController : MonoBehaviour
{
    public float maxHealth = 50f;
    float health;
    Animator animator;
    new AudioSource audio;
    new Rigidbody2D rigidbody2D;
    public float attackBreak = 3f;//攻击间隔,只影响mecha2
    float attackTimer;//攻击冷却计时器,只用于mecha2
    public GameObject bullet;//子弹,只用于mecha2
    float attackStateTimer = 0;//攻击状态计时器
    bool attackState = false;//是否处于攻击状态
    public float moveDistance = 10f;//移动距离,初始向右移动
    public float speed = 5f;//移动速度
    float moveBreak;//转向间隔
    float moveTimer;//转向计时器
    SpriteRenderer spriteRenderer;
    public float transparentDuration = 0.2f;//受击虚化持续时间
    float transparentTimer;//受击虚化计时器
    Slider healthSlider;
    public GameObject boom;//外部绑定死亡爆炸特效

    void Start()
    {
        health = maxHealth;
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        attackTimer = attackBreak;
        moveTimer = moveBreak = moveDistance / speed;
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        healthSlider = GetComponentInChildren<Slider>();
        if (GameManager.enemyDestroyed[GameManager.level, GameManager.room,
        int.Parse(gameObject.name.Substring(gameObject.name.Length - 1))]) Destroy(gameObject);
    }

    void Update()
    {
        if (!attackState)
        {
            moveTimer -= Time.deltaTime;
            if (moveTimer <= 0)
            {
                speed = -speed;
                moveTimer = moveBreak;
                spriteRenderer.flipX = !spriteRenderer.flipX;
            }

            attackTimer -= Time.deltaTime;
        }

        if (transparentTimer < transparentDuration)
        {
            transparentTimer += Time.deltaTime;
            if (transparentTimer >= transparentDuration)
            {
                transparentTimer = transparentDuration;
                Color color = spriteRenderer.color;
                color.a = 1;
                spriteRenderer.color = color;
            }
        }

        if (gameObject.name.Contains("Mecha1"))
        {
            if (moveTimer <= 0.1f && moveTimer > 0.01f)
            {
                attackState = true;
                animator.SetTrigger("Attack");
                moveTimer = 0;
            }
            if (attackState)
            {
                attackStateTimer += Time.deltaTime;
                Vector2 v = rigidbody2D.velocity;
                v.x = speed * 2;
                rigidbody2D.velocity = v;
                if (attackStateTimer > 2f)
                {
                    attackState = false;
                    attackStateTimer = 0;
                    animator.SetTrigger("AttackFinish");
                }
            }
        }
        else if (gameObject.name.Contains("Mecha2"))
        {
            if (attackTimer <= 0)
            {
                attackTimer = attackBreak;
                animator.SetTrigger("Attack");
                attackState = true;
                rigidbody2D.velocity = Vector2.zero;
            }
        }
    }

    private void FixedUpdate()
    {
        if (!attackState)
        {
            Vector2 v = rigidbody2D.velocity;
            v.x = speed;
            rigidbody2D.velocity = v;
        }
    }

    public void ChangeHealth(float value)
    {
        health += value;
        healthSlider.value = health / maxHealth;
        if (health > maxHealth) health = maxHealth;
        else if (health <= 0)//dead
        {
            GameManager.enemyDestroyed[GameManager.level, GameManager.room,
            int.Parse(gameObject.name.Substring(gameObject.name.Length - 1))] = true;
            GameManager.mechaKilledNumber[GameManager.level]++;
            GameManager.mechaNumber[GameManager.level, GameManager.room]--;
            Instantiate(boom, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void Hit()
    {
        transparentTimer = 0;
        Color color = spriteRenderer.color;
        color.a = 0.5f;
        spriteRenderer.color = color;
    }

    public void Shoot()
    {
        Vector2 shootPosition = transform.position + new Vector3(0.09f * transform.localScale.x * Mathf.Abs(speed) / speed, 0.55f * transform.localScale.y, 0);//发射子弹的位置
        Vector2 shootDirection = GameManager.rolePosition - shootPosition;//发射方向
        shootDirection.Normalize();
        Instantiate(bullet, shootPosition, Quaternion.identity).GetComponent<Rigidbody2D>().velocity = 20 * shootDirection;
    }

    public void AttackFinish()
    {
        attackState = false;
    }
}
