using System;
using System.Collections.Generic;

public class RoleAttribute : IArrowAttributes
{
    private int _attack;
    public int Attack
    {
        get
        {
            return _attack;
        }

        set
        {
            _attack = value;
            Notify(AttributeName.ATTR_ATK, _attack);
        }
    }

    private float _critical;
    public float Critical
    {
        get
        {
            return _critical;
        }

        set
        {
            _critical = value;
            Notify(AttributeName.ATTR_CRT, _critical);
        }
    }

    private int _deffence;
    public int Deffence
    {
        get
        {
            return _deffence;
        }

        set
        {
            _deffence = value;
            Notify(AttributeName.ATTR_DEF, _deffence);
        }
    }

    private float _dodge;
    public float Dodge
    {
        get
        {
            return _dodge;
        }

        set
        {
            _dodge = value;
            Notify(AttributeName.ATTR_DDG, _dodge);
        }
    }

    private int _hp;
    public int Hp
    {
        get
        {
            return _hp;
        }

        set
        {
            _hp = value;
            Notify(AttributeName.ATTR_HP, _hp);
        }
    }

    private float _speed;
    public float Speed
    {
        get
        {
            return _speed;
        }

        set
        {
            _speed = value;
            Notify(AttributeName.ATTR_SPD, _speed);
        }
    }

    private int _exp;
    public int Exp
    {
        get
        {
            return _exp;
        }

        set
        {
            _exp = value;
            Notify(AttributeName.ATTR_EXP, _exp);
        }
    }

    public event ArrowAttributeChange attributeChgEvent;
    public RoleAttribute(string roleId)
    {
        roleTemplateContainer tpl = new roleTemplateContainer();
        _hp = tpl.TplData[roleId].hp;
        _attack = tpl.TplData[roleId].atk;
        _deffence = tpl.TplData[roleId].def;
        _critical = tpl.TplData[roleId].critical;
        _speed = tpl.TplData[roleId].speed;
        _dodge = tpl.TplData[roleId].dodge;
    }

    public void ChangeAttribute(AttributeName attrName, object value)
    {
        switch(attrName)
        {
            case AttributeName.ATTR_ATK:
                Attack += (int)value;
                break;
            case AttributeName.ATTR_CRT:
                Critical += (float)value;
                break;
            case AttributeName.ATTR_DDG:
                Dodge += (int)value;
                break;
            case AttributeName.ATTR_DEF:
                Deffence += (int)value;
                break;
            case AttributeName.ATTR_EXP:
                Exp += (int)value;
                break;
            case AttributeName.ATTR_HP:
                Hp += (int)value;
                break;
            case AttributeName.ATTR_SPD:
                Speed += (int)value;
                break;
        }
        Notify(attrName, value);
    }

    public void SetAttribute(AttributeName attrName, object value)
    {
        switch (attrName)
        {
            case AttributeName.ATTR_ATK:
                Attack = (int)value;
                break;
            case AttributeName.ATTR_CRT:
                Critical = (float)value;
                break;
            case AttributeName.ATTR_DDG:
                Dodge = (int)value;
                break;
            case AttributeName.ATTR_DEF:
                Deffence = (int)value;
                break;
            case AttributeName.ATTR_EXP:
                Exp = (int)value;
                break;
            case AttributeName.ATTR_HP:
                Hp = (int)value;
                break;
            case AttributeName.ATTR_SPD:
                Speed = (int)value;
                break;
        }
        Notify(attrName, value);
    }

    private void Notify(AttributeName attrName, object value)
    {
        if (value is int)
        {
            if ((int)value == 0)
            {
                return;
            }
        }
        else if (value is float)
        {
            if ((float)value == 0)
            {
                return;
            }
        }
        if (null != attributeChgEvent)
        {
            attributeChgEvent.Invoke(attrName, value);
        }
    }
}
