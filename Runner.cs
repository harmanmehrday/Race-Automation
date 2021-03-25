using System;
using System.Collections.Generic;
using System.Text;

namespace RunnerExcercise
{
    class Runner
    {
        public delegate void RankChangedHandler(string runnerName, int rank);
        public delegate void PositionChangedHandler(string runnerName, double position);
        public delegate void OnStartRaceHandler(string runnerName);
        public delegate void OnFinishRaceHandler(string runnerName,int rank,DateTime endTime);

        public event RankChangedHandler RankChanged;
        public event PositionChangedHandler PositionChanged;
        public event OnStartRaceHandler RaceStarted;
        public event OnFinishRaceHandler RaceFinished;

        public string Name { get; }
        public bool Running { get; private set; }
        public double MaxSpeed { get; }
        public double Speed { get; set; }
        public double? RaceLength { get; private set; }
        public DateTime? RaceStartTime { get; private set; }
        public DateTime? RaceEndTime { get; private set; }
        private int rank;
        public int Rank
        {
            get
            {
                return rank;
            }
            set
            {
                rank = value;
                RankChanged?.Invoke(Name, rank);
            }
        }
        private double position;
        public double Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
                PositionChanged?.Invoke(Name, position);
            }
        }
        public TimeSpan? RaceDuration
        {
            get
            {
                if (RaceEndTime == null && RaceStartTime == null || RaceStartTime==null)
                {
                    return null;
                }
                else if(RaceEndTime==null)
                {
                    RaceEndTime = DateTime.Now;
                }
                return RaceEndTime - RaceStartTime;
            }
        }
        public Runner(string name, double maxSpeed)
        {
            Name = name;
            MaxSpeed = maxSpeed;
            Rank = 0;
            Position = 0;
            Speed = 0;
            Running = false;
            RaceStartTime = null;
            RaceEndTime = null;
            RaceLength = null;
        }
        public double GetRandomSpeed(double maxSpeed)
        {
            Random random = new Random();
            double randomValue = (random.NextDouble() * (maxSpeed - (maxSpeed * 0.75))) + (maxSpeed * 0.75);
            randomValue = Math.Round(randomValue, 2);
            return randomValue;
        }
        public void SetRandomSpeed()
        {
            Speed = GetRandomSpeed(MaxSpeed);
        }
        public void StartRace(double raceLength)
        {
            RaceStarted?.Invoke(Name);
            RaceLength = raceLength;
            RaceStartTime = DateTime.Now;
            RaceEndTime = null;
            Position = 0;
            Rank = 1;
            Running = true;
            Speed = GetRandomSpeed(MaxSpeed);
        }
        public void FinishRace()
        { 
            RaceEndTime = DateTime.Now;
            RaceFinished?.Invoke(Name, rank, DateTime.Now);
            Running = false;
            Speed = 0;
        }
    }
}
