using System.Collections.Generic;
using System.Diagnostics;

namespace ToolAnalyzer.Manager
{
    /// <summary>
    ///     Worker manager class
    /// </summary>
    public class WorkerManager
    {
        /// <summary>
        ///     Working state
        /// </summary>
        public enum WorkingState
        {
            Offset,
            Stop,
            DriverPreDelay,
            RecordPreDelay,
            Record,
            DriverAfterDelay,
            RecordAfterDelay
        }

        /// <summary>
        ///     Offset delay time
        /// </summary>
        public const int OffsetDelay = 100;

        /// <summary>
        ///     Stop delay time
        /// </summary>
        public const int StopDelay = 10000;

        /// <summary>
        ///     Driver run/stop delay time
        /// </summary>
        public const int DrvDelay = 100;

        /// <summary>
        ///     Record start/stop delay time
        /// </summary>
        public const int RecDelay = 500;

        /// <summary>
        ///     Record time
        /// </summary>
        public const int RecordTime = 5000;

        /// <summary>
        ///     AU-BM10 Min frequency
        /// </summary>
        public const int MinFreq = 100;

        /// <summary>
        ///     AU-BM10 Max frequency
        /// </summary>
        public const int MaxFreq = 10000;

        public WorkerManager(ushort min, ushort max)
        {
            // set min/max torque
            MinTorque = min;
            MaxTorque = max;
            // set step
            TorqueStep = (ushort)((MaxTorque - MinTorque) / 5);
        }

        private Stopwatch Watch { get; } = new Stopwatch();

        /// <summary>
        ///     Current state
        /// </summary>
        public WorkingState State { get; private set; }

        /// <summary>
        ///     Max torque
        /// </summary>
        public ushort MaxTorque { get; }

        /// <summary>
        ///     Min torque
        /// </summary>
        public ushort MinTorque { get; }

        /// <summary>
        ///     Torque step
        /// </summary>
        public ushort TorqueStep { get; }

        /// <summary>
        ///     Torque
        /// </summary>
        public ushort Torque { get; set; }

        /// <summary>
        ///     Speed
        /// </summary>
        public ushort Speed { get; set; }

        /// <summary>
        ///     Temperature
        /// </summary>
        public ushort Temp { get; set; }

        /// <summary>
        ///     Values
        /// </summary>
        public List<byte> Values { get; } = new List<byte>();

        /// <summary>
        ///     Change state
        /// </summary>
        /// <param name="state">state</param>
        public void ChangeState(WorkingState state)
        {
            // reset watch
            Watch.Restart();
            // change state
            State = state;
        }

        /// <summary>
        ///     Next record
        /// </summary>
        /// <returns>state</returns>
        public bool NextRecord()
        {
            // check torque
            if (Torque >= MaxTorque)
                // stop record
                return false;
            // check torque
            if (Torque == 0)
            {
                // set min torque
                Torque = MinTorque;
            }
            else
            {
                // change torque
                Torque += TorqueStep;
                // check torque
                if (Torque >= MaxTorque)
                    // set max torque
                    Torque = MaxTorque;
            }

            // return
            return true;
        }

        /// <summary>
        ///     Get time laps
        /// </summary>
        /// <returns>time</returns>
        public long GetLaps()
        {
            return Watch.ElapsedMilliseconds;
        }
    }
}