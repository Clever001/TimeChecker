using System;
using System.Threading.Tasks;

namespace TimeCheckerClasses;
public class Clock {
    public DateTime CurTime { get; private set; }

    public Clock(Predicate<DateTime> condition, Action<DateTime> curTimeChanged, Action<DateTime> trueCondition, DateTime? startTime = null) {
        if (startTime is not null && startTime.Value.Equals(default)) {
            throw new ArgumentOutOfRangeException(nameof(startTime), "StartTime cannot be default.");
        }
        Condition = condition;
        CurTimeChanged = curTimeChanged;
        TrueCondition = trueCondition;
        if (startTime is not null) {
            CurTime = startTime.Value;
        }
    }

    public Predicate<DateTime> Condition { get; set; }

    public event Action<DateTime> CurTimeChanged;
    public event Action<DateTime> TrueCondition;

    private void Main() {
        if (CurTime.Equals(default)) {
            CurTime = DateTime.Now;
        }


    }
}
