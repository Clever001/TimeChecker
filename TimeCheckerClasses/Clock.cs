using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TimeCheckerClasses;
public class Clock : IDisposable {
    private bool _isRunning = false;
    private readonly object _locker = new();
    private readonly CancellationTokenSource _tokenSource = new();
    private Task? _mainTask = null;

    public Predicate<DateTime>? Condition { get; private set; } = null;

    public event Action<DateTime, CancellationToken?>? CurTimeChanged;
    public event Action<DateTime, CancellationToken?>? TrueCondition;

    public void StartClock() {
        _mainTask = Task.Run(() => MainLoopAsync(_tokenSource.Token));
    }

    public void ChangeCondition(Predicate<DateTime> condition) {
        if (condition is null) throw new ArgumentNullException(nameof(condition));
        lock (_locker) {
            Condition = condition;
        }
    }

    private async Task MainLoopAsync(CancellationToken token) {
        lock (_locker) {
            if (_isRunning) {
                throw new ArgumentException("Часы уже запущены.");
            }
            _isRunning = true;
        }

        try {
            DateTime lastTime = DateTime.Now.AddSeconds(-1);

            while (!token.IsCancellationRequested) {
                DateTime now = DateTime.Now;

                if (now.Second != lastTime.Second) {
                    lock (_locker) {
                        CurTimeChanged?.Invoke(now, token);

                        if (Condition?.Invoke(now) == true) {
                            TrueCondition?.Invoke(now, token);
                        }
                    }
                    lastTime = now;
                }

                int msToNextHalfSecond = 500 - (now.Millisecond % 500);
                await Task.Delay(msToNextHalfSecond, token);
            }
        }
        finally {
            lock (_locker) {
                _isRunning = false;
            }
        }
    }

    public void Dispose() {
        _tokenSource.Cancel();
        _mainTask?.ContinueWith(t => {
            if (t.Exception != null && t.Exception.InnerExceptions.All(e => e is TaskCanceledException)) {
                // Игнорируем ошибки отмены
            }
        }, TaskContinuationOptions.OnlyOnFaulted);
    }
}
