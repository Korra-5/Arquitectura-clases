namespace Proyecto1;

 class MainClass
{
    public static void Main(String[] args)
    {
        var character = new Character(50,"Heroe",100,15,10);
        var minion = new Minion("Minion1", 30, 30, 4, 4);
        var axe = new Weapon (){ Damage = 7 };
        var sword = new Weapon() { Damage = 5 };
        var helmet = new Protection(){ Armor = 4 };
        var shield = new Protection(){ Armor = 3 };
        character.AddItem(axe);
        character.AddItem(sword);
        character.AddItem(helmet);
        character.AddItem(shield);

        Console.WriteLine("Manual tests: ");

        Console.WriteLine(character);
        Console.WriteLine(minion);
        
        character.ReceiveDamage(20);
        Console.WriteLine(character);
        
        minion.ReceiveDamageMinion(20);
        Console.WriteLine(minion);
        
        character.Heal(30);
        Console.WriteLine(character);
        
        character.Heal(100);
        Console.WriteLine(character);
        
        character.ReceiveDamage(200);
        Console.WriteLine(character);
        
        minion.ReceiveDamageMinion(200);
        Console.WriteLine(minion);
    }
}