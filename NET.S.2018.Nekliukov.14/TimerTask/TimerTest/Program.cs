using TimerLib;
using TimerTest;

public static class Program
{
    public static void Main()
    {
        // 5 seconds timer
        TimerManager timerManager = new TimerManager(5);

        // creating of listeners
        Ring ring = new Ring(timerManager);
        Professor anzhelikaIvanovna = new Professor("Anzhelika Ivanovna", timerManager);
        Student roman = new Student("Roman Nekliukov", timerManager);
        Student valery = new Student("Valery Chadovich");
        valery.Register(timerManager);
        
        timerManager.StartTimer();
    }
}