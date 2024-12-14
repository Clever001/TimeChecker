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

    //public Clock() {
    //    _mainTask = Task.Run(() => MainAsync(_tokenSource.Token));
    //}

    public Predicate<DateTime>? Condition { get; set; } = null;

    public event Action<DateTime>? CurTimeChanged;
    public event Action<DateTime>? TrueCondition;

    public void StartClock() {
        _mainTask = Task.Run(() => MainLoopAsync(_tokenSource.Token));
    }

    private async Task MainLoopAsync(CancellationToken token) {
        lock (_locker) {
            if (_isRunning) {
                throw new ArgumentException("Часы уже запущены.");
            }
            _isRunning = true;
        }

        while (!token.IsCancellationRequested) {
            DateTime now = DateTime.Now;
            CurTimeChanged?.Invoke(now);
            if (Condition?.Invoke(now) == true) {
                TrueCondition?.Invoke(now);
            }
            await Task.Delay(1000, token);
        }

        lock (_locker) {
            _isRunning = false;
        }
    }

    public void Dispose() {
        _tokenSource.Cancel();
        try {
            _mainTask?.Wait();
        }
        catch (AggregateException ex) when (ex.InnerExceptions.All(e => e is TaskCanceledException)) {
            // Игнорируем исключение отмены задачи
        }
    }
}
