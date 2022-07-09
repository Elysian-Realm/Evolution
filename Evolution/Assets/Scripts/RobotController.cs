using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotController : MonoBehaviour
{
    new AudioSource audio;
    public float maxHealth = 20f;
    float health;
    public float moveDistance = 10f;//移动距离,初始向右移动
    public float speed = 5f;//移动速度
    float moveBreak;//转向间隔
    float moveTimer;//转向计时器
    public float transparentDuration = 0.2f;//受击虚化持续时间
    float transparentTimer;//受击虚化计时器
    SpriteRenderer spriteRenderer;
    Slider healthSlider;
    public GameObject boom;//外部绑定死亡爆炸特效

    void Start()
    {
        audio = GetComponent<AudioSource>();
        health = maxHealth;
        moveTimer = moveBreak = moveDistance / speed;
        spriteRenderer = GetComponent<SpriteRenderer>();
        transparentTimer = transparentDuration;
        healthSlider = GetComponentInChildren<Slider>();
        if (GameManager.enemyDestroyed[GameManager.level, GameManager.room,
        int.Parse(gameObject.name.Substring(gameObject.name.Length - 1))]) Destroy(gameObject);
    }

    void Update()
    {
        //move
        Vector2 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        moveTimer -= Time.deltaTime;
        if (moveTimer <= 0)
        {
            speed = -speed;
            moveTimer = moveBreak;
            spriteRenderer.flipX = !spriteRenderer.flipX;
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
            GameManager.robotKilledNumber[GameManager.level]++;
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
}
