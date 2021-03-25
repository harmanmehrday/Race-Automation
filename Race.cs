using System;
using System.Collections.Generic;
using System.Threading;

namespace RunnerExcercise
{
    class Race
    {
        public double Length { get; }
        public bool RaceInProgress { get; private set; }
        private List<Runner> runners;
        public IReadOnlyList<Runner> Runners => runners;
        public Race(double length)
        {
            runners = new List<Runner>();
            Length = length;
        }

        public void AddRunner(Runner runner)
        {
            runners.Add(runner);
        }

        public bool RemoveRunner(Runner runner)
        {
            return runners.Remove(runner);
        }

        public bool StartRace()
        {
            if (RaceInProgress)
            {
                return false;
            }

            RaceInProgress = true;
            
            foreach(Runner runner in runners)
            {
                runner.StartRace(Length);
            }
            
            new Thread(() => AnimateRunners()).Start();
            
            return RaceInProgress;
        }
        
        public void AnimateRunners()
        {
            while (RaceInProgress)
            {
                int runnerCount = 0;
                foreach (Runner runner in runners)
                {
                    Thread.Sleep(1000);
                    if (runner.Running) 
                    {
                        runner.SetRandomSpeed();
                        runner.Position += runner.Speed;
                        runner.Rank = SetRank(runner.Position);
                    }
                    if (runner.Position >= Length)
                    {
                        runnerCount++;
                        runner.Rank = runnerCount;
                        runner.FinishRace();
                    }
                }
            }
        }

        public int SetRank(double position)
        {
            int rank = 0;
            foreach(Runner runner in runners)
            {
                if(position > runner.Position)
                {
                    rank++;
                }
            }
            return rank;
        }
    }
}