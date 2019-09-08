using Clock.Library;

namespace Clock.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            ContraClock funClock = new ContraClock();
            ClockInfo userOne = new SecondsCounter();
            ClockInfo userTwo = new MinutesCounter();

            userOne.Add(funClock);
            funClock.LetWait(4000);

            userTwo.Add(funClock);
            funClock.LetWait(10000);

            userOne.Remove(funClock);
            funClock.LetWait(2000);

            userOne = null;                                    //pay attention that it does not work :)
            funClock.LetWait(4000);
        }
    }
}
