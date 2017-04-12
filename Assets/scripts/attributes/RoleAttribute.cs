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

    public event ArrowAttributeChange attributeChgEvent;

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
        }
    }

    public void SetAttribute(AttributeName attrName, object value)
    {
        throw new NotImplementedException();
    }

    private void Notify(AttributeName attrName, object value)
    {
        if(null != attributeChgEvent)
        {
            attributeChgEvent.Invoke(attrName, value);
        }
    }
}
