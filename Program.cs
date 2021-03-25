using System;

namespace RunnerExcercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Spectator spec = new Spectator();
            Race myRace = new Race(100);
            Runner Harman = new Runner("Harman",8);
            Runner Mani = new Runner("Mani", 8);
            Runner Manish = new Runner("Manish", 8);
            Runner Vishal = new Runner("Vishal", 6);

            myRace.AddRunner(Harman);
            myRace.AddRunner(Mani);
            myRace.AddRunner(Manish);
            myRace.AddRunner(Vishal);

            Harman.RankChanged += spec.RankChanged;
            Mani.RankChanged += spec.RankChanged;
            Manish.RankChanged += spec.RankChanged;
            Vishal.RankChanged += spec.RankChanged;

            Harman.PositionChanged += spec.PositionChanged;
            Mani.PositionChanged += spec.PositionChanged;
            Manish.PositionChanged += spec.PositionChanged;
            Vishal.PositionChanged += spec.PositionChanged;

            Harman.RaceFinished += spec.RaceFinished;
            Mani.RaceFinished += spec.RaceFinished;
            Manish.RaceFinished += spec.RaceFinished;
            Vishal.RaceFinished += spec.RaceFinished;

            myRace.StartRace();

        }
    }
}
