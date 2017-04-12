using UnityEngine;
using System.Collections;

public enum AttributeName
{
    ATTR_HP,
    ATTR_DEF,
    ATTR_ATK,
    ATTR_SPD,
    ATTR_CRT,
    ATTR_DDG,
}

public interface IArrowAttributes {
    /// <summary>
    /// 血量值
    /// </summary>
    int Hp { get; set; }
    /// <summary>
    /// 防御值
    /// </summary>
    int Deffence { get; set; }
    /// <summary>
    /// 攻击值
    /// </summary>
    int Attack { get; set; }
    /// <summary>
    /// 移速
    /// </summary>
    float Speed { get; set; }
    /// <summary>
    /// 暴击概率
    /// </summary>
    float Critical { get; set; }
    /// <summary>
    /// 闪避概率
    /// </summary>
    float Dodge { get; set; }
    /// <summary>
    /// 属性变化事件
    /// </summary>
    event ArrowAttributeChange attributeChgEvent;

    /// <summary>
    /// 设置属性的值为某值
    /// </summary>
    /// <param name="attrName">属性名称</param>
    /// <param name="value">属性新的值</param>
    void SetAttribute(AttributeName attrName, object value);
    /// <summary>
    /// 设置属性变化值
    /// </summary>
    /// <param name="attrName">属性名称</param>
    /// <param name="value">变化值，正数是加，负数是减</param>
    void ChangeAttribute(AttributeName attrName, object value);
}
