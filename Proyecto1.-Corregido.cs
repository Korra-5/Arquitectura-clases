using System.Security.Cryptography;

namespace Proyecto1;
//Clase Characer
public class Character
{
    public string Name { get; set; }
    public int MaxHitPoints { get; set; }
    public int BaseDamage { get; set; }
    public int BaseArmor { get; set; }
    public int ActHp{get; set; }
    private List<Item> _inventory ;

    //Constructor de la clase character
    public Character(List<Item> inventory, int actHp, string name, int maxHitPoints, int baseDamage, int baseArmor)
    {
        this._inventory = inventory;
        Name = name;
        MaxHitPoints = maxHitPoints;
        BaseDamage = baseDamage;
        BaseArmor = baseArmor;
        ActHp = actHp;
    }
    
    //Metodos de la clase character
    
    public int Attack()
    {
        return BaseDamage; 
    }

    public int Defense()
    {
        return BaseArmor;
    }

    public int Heal(int hp)
    {
        ActHp= ActHp + hp;
        if (ActHp > MaxHitPoints)
        {
            ActHp = MaxHitPoints;
        }
return ActHp;
       
    }

    public int ReceiveDamage(int damage)
    {
        int FinalDamage =  damage - BaseArmor;
        if (FinalDamage < 0)
        {
            ActHp = ActHp - 1;
        }
        else if (FinalDamage > 0)
        {
            ActHp = ActHp - FinalDamage;
        }
        return ActHp;
    }

    public void AddItem(Item item)
    {
        _inventory.Add(item);
    }
    
}

//Clase Weapon la cual hereda de la interfaz Item
public class Weapon : Item
{
    public string Name { get; set; }
    public int Damage { get; set; }

    //Metodo heredado de la interfaz
    public void Apply(Character character)
    {
        character.BaseDamage += Damage;
    }
}

//CLase Protection la cual hereda de la interfaz Item
public class Protection : Item
{
    public string Name { get; set; }
    public int Armor { get; set; }

    //Metodo heredado de la interfaz
    public void Apply(Character character)
    {
        character.BaseArmor += Armor;
    }
}

//Clase Sword que hereda de la clase Weapon
public class Sword : Weapon
{
    public string Name = "Sword";
    public int Damage = 140;
}

//Clase Axe que hereda de la clase Weapon
public class Axe : Weapon
{
    public string Name = "Axe";
    public int Damage = 120;
}

//Clase Helmet que hereda de la clase Protection
public class Helmet : Protection
{
    public String Name = "Helmet";
    public int Armor = 100;
}

//Clase Shield que hereda de la clase Protection
public class Shield : Protection
{
    public String Name = "Shield";
    public int Armor = 110;
}


//Interfaz Item
public interface Item
{
    public void Apply(Character character);
}