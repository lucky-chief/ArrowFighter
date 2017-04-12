using UnityEngine;
using System.Collections;
public enum BulletDamageAreaType
{
    Point,//单体伤害
    Circle//范围伤害（AOE）
}

public enum BulletDamageOpportunity
{
    Collidion,//碰撞的时候产生伤害
    OnTime//消逝一段时间后产生伤害
}

public abstract class BaseBullet : MonoBehaviour
{
    #region 子弹的战斗属性
    /// <summary>
    /// 子弹的生命周期
    /// 时间到了，子弹会被销毁
    /// </summary>
    public float lifeTime;
    /// <summary>
    /// 子弹的伤害数值
    /// 造成的伤害计算公式：伤害值 = damage - 目标的防御值
    /// </summary>
    public int damage;
    /// <summary>
    /// 子弹的射程
    /// </summary>
    public float range;
    /// <summary>
    /// 子弹的飞行速度
    /// </summary>
    public float speed;
    /// <summary>
    /// 子弹的伤害间隔(s)
    /// 如果填0则表示子弹在碰撞后立即造成伤害，之后子弹被销毁。此时子弹的伤害时机应该选 Collision
    /// 如果填非零值（正数）表示每隔所填时间（包括0时刻）子弹会造成一次伤害，知道其生命周期介绍才被销毁。此时子弹的伤害时机应该选 OnTime
    /// </summary>
    public float damageInterval;
    /// <summary>
    /// 子弹的伤害范围类型
    /// </summary>
    public BulletDamageAreaType damageType;
    /// <summary>
    /// 子弹的伤害时机
    /// </summary>
    public BulletDamageOpportunity damageOpportunity;
    /// <summary>
    /// 子弹的拥有者（玩家），子弹不会对此玩家造成伤害
    /// </summary>
    [HideInInspector]
    public GameObject owner;
    #endregion

    #region 子弹的表现属性
    /// <summary>
    /// 子弹的名称
    /// </summary>
    public string bulletName;
    /// <summary>
    /// 子弹的UI显示图标
    /// </summary>
    public string bulletIcon;
    /// <summary>
    /// 子弹的击中玩家，玩家播放的被击动画
    /// </summary>
    public string anm_HitHero;
    /// <summary>
    /// 子弹的落到地面上的特效
    /// </summary>
    public GameObject eff_HitGround;
    /// <summary>
    /// 子弹的击中墙面的特效
    /// </summary>
    public GameObject eff_HitWall;
    #endregion



    // Use this for initialization
    void Start()
    {
        OnLoad();
        Invoke("OnLifeTime",lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        OnUpdate();
    }

    void OnDestroy()
    {
        Destroy();
    }

    #region 基本逻辑
    void OnLifeTime()
    {

    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        int layer = collision.gameObject.layer;
        if (damageOpportunity == BulletDamageOpportunity.Collidion)
        {
            if(layer == 1 << LayerMask.NameToLayer("Player"))
            {
                if(collision.gameObject == owner)
                {
                    return;
                }
                if(damageInterval == 0)
                {
                    ExcuteDamage(collision.gameObject.GetComponent<RoleController>());
                    Destroy(gameObject);
                }
            }
            else if(layer == 1 << LayerMask.NameToLayer("Ground"))
            {
                Instantiate(eff_HitGround, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else if (layer == 1 << LayerMask.NameToLayer("Wall"))
            {
                Instantiate(eff_HitWall, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

        }
    }
    #endregion

        #region 复写接口
    protected abstract void OnLoad();
    protected abstract void Destroy();
    protected abstract void OnUpdate();
    protected virtual void ExcuteDamage(RoleController player)
    {
        player.Attributes.ChangeAttribute(AttributeName.ATTR_HP, Mathf.Clamp(damage - player.Attributes.Deffence, 1, damage));
    }
    #endregion
}
