using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace RunnerExcercise
{
    class FanSpectator
    {
        public void RankChanged(string runnerName, int rank)
        {
            if (rank == 1)
            {
                Console.WriteLine($"\nYou are number One... Fast Fast Fast....{runnerName}");
            }
            else
            {
                Console.WriteLine($"\nRun Fast We have to win the race...");
            }
        }

        public void RaceStarted(string runnerName)
        {
            Console.WriteLine($"\nWe are going to win this race... {runnerName}...");
        }

        public void RaceFinished(string runnerName, int rank, DateTime endtime)
        {
            int lastRank = 0;
            if (rank == 1)
            {
                Console.WriteLine($"\nWelldone...Bravo... {runnerName}... We Won...");
            }
            else if(rank>1 && rank < lastRank)
            {
                Console.WriteLine($"\nI am very disappointed... {runnerName}...");
            }
            else
            {
                Console.WriteLine($"\nYou did'nt ran fast... {runnerName}... That's why we lost...");
            }
        }
    }
}
