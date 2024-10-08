using System.Security.Cryptography;

namespace Proyecto1;
//Clase Characer


public class Character
{
    public string Name { get; set; }
    public int MaxHitPoints { get; set; }
    public int BaseDamage { get; set; }
    public int BaseArmor { get; set; }
    public int HitPoints{get; set; }
    private List<Item> _inventory ;

    //Constructor de la clase character
    public Character(int hitPoints, string name, int maxHitPoints, int baseDamage, int baseArmor)
    {
        this._inventory =  new List<Item>();
        Name = name;
        MaxHitPoints = maxHitPoints;
        BaseDamage = baseDamage;
        BaseArmor = baseArmor;
        HitPoints = hitPoints;
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
        HitPoints= HitPoints + hp;
        if (HitPoints > MaxHitPoints)
        {
            HitPoints = MaxHitPoints;
        }
return HitPoints;
       
    }

    public int ReceiveDamage(int damage)
    {
        int FinalDamage =  damage - BaseArmor;
        if (FinalDamage < 0)
        {
            HitPoints = HitPoints - 1;
        }
        else if (FinalDamage > 0)
        {
            HitPoints = HitPoints - FinalDamage;
            if (HitPoints < 0)
            {
                HitPoints = 0;
            }
        }
        return HitPoints;
    }

    public void AddItem(Item item)
    {
        _inventory.Add(item);
        item.Apply(this);
    }
    
    public override string ToString()
    {
        string result = $"Character: {Name} | HP: {HitPoints}/{MaxHitPoints}\n";
        result += "  Inventory:\n";
        foreach (var item in _inventory)
        {
            result += $"{item}\n";
        }
        result += $"  Attack: {Attack()}\n";
        result += $"  Defense: {Defense()}\n";
        return result;
    }

}

//Clase Weapon la cual hereda de la interfaz Item
public class Weapon : Item
{
    public string Name;
    public int Damage;

    //Metodo heredado de la interfaz
    public void Apply(Character character)
    {
        character.BaseDamage += Damage;
    }
 
}

//CLase Protection la cual hereda de la interfaz Item
public class Protection : Item
{
    public string Name;
    public int Armor;

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
    public int Damage;
    
    public override string ToString()
    {
        return Name;
    }
    
}

//Clase Axe que hereda de la clase Weapon
public class Axe : Weapon
{
    public string Name = "Axe";
    public int Damage;
    
    public override string ToString()
    {
        return Name;
    }
}

//Clase Helmet que hereda de la clase Protection
public class Helmet : Protection
{
    public String Name = "Helmet";
    public int Armor;
    
    public override string ToString()
    {
        return Name;
    }
    
}

//Clase Shield que hereda de la clase Protection
public class Shield : Protection
{
    public String Name = "Shield";
    public int Armor;
    
    public override string ToString()
    {
        return Name;
    }
}

public class Baston : Weapon
{
    //Este es el arma encargada de generar minions, la idea es recorrer la lista en busca del arma,
    //en caso de que el arma se enuentre en el inventario se devuelve un booleano que genera el minion,
    //aunque dicha verificacion se haria en el main
    
    public string Name = "Baston";
    public int Damage;

    public override string ToString()
    {
        return Name;
    }
}

public class Minion
{
    public String Name { get; set; }
    public int MinionMaxHitPoints { get; set; }
    public int MinionHitPoints { get; set; }
    public int MinionAttack { get; set; }
    public int MinionArmor { get; set; }

    public Minion(string name, int minionMaxHitPoints, int minionHitPoints, int minionAttack, int minionArmor)
    {
        Name = name;
        MinionMaxHitPoints = minionMaxHitPoints;
        MinionHitPoints = minionHitPoints;
        MinionAttack = minionAttack;
        MinionArmor = minionArmor;
    }

    public int AttackMinion()
    {
        return MinionAttack;
    }

    public int DefenseMinion()
    {
        return MinionArmor;
    }

    public int ReceiveDamageMinion(int damage)
    {
        int FinalDamage =  damage - MinionArmor;
        if (FinalDamage < 0)
        {
            MinionHitPoints = MinionHitPoints - 1;
        }
        else if (FinalDamage > 0)
        {
            MinionHitPoints = MinionHitPoints - FinalDamage;
            if (MinionHitPoints < 0)
            {
                MinionHitPoints = 0;
            }
        }
        return MinionHitPoints;
    }
    
    public override string ToString()
    {
        string result = $"Character: {Name} | HP: {MinionHitPoints}/{MinionMaxHitPoints}\n";
        result += $"  Minion Attack: {MinionAttack}\n";
        result += $"  Minion Defense: {MinionArmor}\n";
        return result;
    }
}

//Interfaz Item
public interface Item
{
    public void Apply(Character character);
}

