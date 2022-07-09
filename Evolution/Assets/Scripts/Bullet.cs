using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum Belong { role, enemy };
    public Belong belong;//外部选择子弹所属单位
    public GameObject bulletHit;//外部选择子弹命中特效
    public float damage = 5f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (belong == Belong.role && other.gameObject.layer == 9)//Enemy图层的id为9
        {
            if (other.tag == "Robot")
            {
                RobotController robotController = other.GetComponent<RobotController>();
                robotController.ChangeHealth(-damage);
                robotController.Hit();
            }
            else
            {
                MechaController mechaController = other.GetComponent<MechaController>();
                mechaController.ChangeHealth(-damage);
                mechaController.Hit();
            }
        }

        else if (belong == Belong.enemy && other.tag == "Role")
        {
            RoleController roleController = other.GetComponent<RoleController>();
            roleController.ChangeHealth(-damage);
            roleController.Hit(transform);
        }

        Instantiate(bulletHit, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
