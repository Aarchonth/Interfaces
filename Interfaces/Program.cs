using System;
interface IPlayerState
{ 
    void Enter(Player context); // Player Entering?
    void Act(Player context);   // Player Action
    void Exit(Player context); // Player Exit?

}
class Player
{
    protected IPlayerState state;
    public Player()
    {
        state = new Idle();
        state.Enter(this);
    }
    public void DoAction()
    {
        state.Act(this);   
    }
    private void Switch(IPlayerState next)
    {
        if (state != null)
        {
            state.Exit(this); // 1. Switch Current State
        }
        state = next;        // 2. Set New State
        state.Enter(this);   // 3. Enter New State
    }
    public void SetState(IPlayerState next) { 
    Switch(next);
    }
    

}

class Idle : IPlayerState
{
    public void Enter(Player context)
    {
        Console.WriteLine("Enter IdleState");
    }
    public void Act(Player context)
    {
        Console.WriteLine("Player does nothing");
    }
    public void Exit(Player context)
    {
        Console.WriteLine("Exit IdleState");
    }
}
class Attack : IPlayerState
{
    public void Enter(Player context)
    {
        Console.WriteLine("Enter AttackState");
    }
    public void Act(Player context)
    { 
        Console.WriteLine("Player Strikes");
        context.SetState(new Idle());
    }
    public void Exit( Player context) 
    {
        Console.WriteLine("Exit AttackState");
    }
}
class Dead : IPlayerState
{
    public void Enter(Player context)
    {
        Console.WriteLine("Enter DeadState");
    }
    public void Act( Player context)
    {
        Console.WriteLine("Player Dies");
    }
    public void Exit(Player context) 
    {
        Console.WriteLine("Exit DeadState");
    }
}
class Program
{
    public static void Main()
    {
        // Wir können Instanzen der Klassen erstellen und die Methode aufrufen
        // Wir erstellen eine Instanz des Players.
        Player player = new Player();
        
        // Der Spieler ist im Idle-Zustand, also rufen wir seine Aktion auf.
        player.DoAction();

        // Jetzt ändern wir den Zustand des Spielers auf "Attack".
        player.SetState(new Attack());

        // Jetzt rufen wir seine neue Aktion auf.
        player.DoAction();

        // Und jetzt ändern wir den Zustand des Spielers auf "Dead".
        player.SetState(new Dead());

        // Und rufen seine letzte Aktion auf.
        player.DoAction();

    }
}