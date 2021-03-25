using System;
using System.Collections.Generic;
using System.Text;

namespace RunnerExcercise
{
    class OpportunistSpectator
    {
        public void RankChanged(string runnerName, int rank)
        {
            if (rank == 1)
            {
                Console.WriteLine($"\nYou are number One... Fast Fast Fast....{runnerName}... I am your Big Fan...");
            }
        }
        public void RaceFinished(string runnerName, int rank, DateTime endtime)
        {
            if (rank == 1)
            {
                Console.WriteLine($"\nWelldone...Bravo... {runnerName}... We Won...");
            }
        }
    }
}
