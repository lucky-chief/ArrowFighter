using UnityEngine;
using System.Collections;

public enum FoodType
{
    Exp,
    Hp
}

public class Food : MonoBehaviour
{

    public FoodType foodType;
    public int value;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            RoleController roleCtrl = other.gameObject.GetComponent<RoleController>();
            if(foodType == FoodType.Exp)
            {
                roleCtrl.Attributes.ChangeAttribute(AttributeName.ATTR_EXP, value);
            }
            else if(foodType == FoodType.Hp)
            {
                roleCtrl.Attributes.ChangeAttribute(AttributeName.ATTR_HP, value);
            }
            Destroy(gameObject);
        }
    }
}
