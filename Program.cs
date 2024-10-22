public abstract class Weapon
{
    public string Name { get; set; }
    public int Damage { get; set; }
    public abstract int GiveDamage(int damage);
}
public class Sword : Weapon
{
    public override int GiveDamage(int damage)
    {
        return damage;
    }
}
public class Bow : Weapon
{
    public override int GiveDamage(int damage)
    {
        return damage;
    }
}
public class Axe : Weapon
{
    public override int GiveDamage(int damage)
    {
        return damage;
    }
}
public class Character
{
    public string Name { get; set; }
    public int Health { get; set; }
    public List<Weapon> Weapons { get; set; } = new List<Weapon>();

    public void Hit(Weapon weapon, Character target)
    {
        int givenDamage = weapon.GiveDamage(weapon.Damage);
        target.TakeDamage(givenDamage);

    }
    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
}
public class Program
{
    public static void Main()
    {
        Sword sword = new Sword
        {
            Name = "Sword1",
            Damage = 15
        };
        Bow bow = new Bow
        {
            Name = "Bow1",
            Damage = 23
        };
        Axe axe = new Axe
        {
            Name = "Axe1",
            Damage = 33
        };
        Character character1 = new Character();
        character1.Name = "John";
        character1.Health = 100;

        character1.Weapons.Add(bow);
        character1.Weapons.Add(axe);

        Character character2 = new Character();
        character2.Name = "Nick";
        character2.Health = 100;

        character2.Weapons.Add(bow);
        character2.Weapons.Add(axe);

        while (character1.Health > 0 && character2.Health > 0)
        {
            character1.Hit(axe, character2);
            Console.WriteLine($"{character1.Name} - health: {character1.Health}");
            if (character1.Health <= 0)
            {
                Console.WriteLine($"{character2.Name} wins");
                break;
            }
            character2.Hit(bow, character1);
            Console.WriteLine($"{character2.Name} - health: {character2.Health}");
            if (character2.Health <= 0)
            {
                Console.WriteLine($"{character1.Name} wins");
                break;
            }
        }
    }

}


