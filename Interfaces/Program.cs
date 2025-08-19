using System.Numerics;
using System.Security.Cryptography.X509Certificates;
interface IWhat { 
    void DoAction(Player player); 
}
class Player
{
    public string state;
}

class Idle : IWhat
{
    public void DoAction(Player player)
    {

        player.state = "Warten";
    }
}
class Attack : IWhat
{
    public void DoAction(Player player)
    {
        player.state = "Angreifen";
    }
}
class Dead : IWhat
{
    public void DoAction(Player player)
    {
        player.state = "Tot";
    }
}
class Program
{
    public static void Main()
    {
        // Wir können Instanzen der Klassen erstellen und die Methode aufrufen
        Player player = new Player();

        IWhat idleState = new Idle();
        idleState.DoAction(player);
        Console.WriteLine(player.state);

        IWhat attackState = new Attack();
        attackState.DoAction(player);
        Console.WriteLine(player.state);
        
        
        IWhat deadState = new Dead();
        deadState.DoAction(player);
        Console.WriteLine(player.state);
    }
}