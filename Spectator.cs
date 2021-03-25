using System;
using System.Collections.Generic;
using System.Text;

namespace RunnerExcercise
{
    class Spectator
    {
        public void RankChanged(string runnerName,int rank)
        {
            Console.WriteLine($"\n Runner Name : {runnerName} || Rank : {rank}");
        }
        public void PositionChanged(string runnerName, double position)
        {
            Console.WriteLine($"\n Runner Name : {runnerName} || Position : {Math.Round(position,2)}");
        }
        public void RaceFinished(string runnerName, int rank, DateTime endtime)
        {
            Console.WriteLine($"\n RACE FINISHED!!  Runner Name : {runnerName} || Rank : {rank} || End Time : {endtime.ToString("hh.mm.ss.fff")}");
        }
    }
}
