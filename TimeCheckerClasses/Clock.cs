using System;
using System.Threading;

namespace TimeCheckerClasses;

public class Clock : IDisposable {
    private bool _isRunning = false;
    private readonly object _locker = new();

    private Timer? _timer = null;
    private DateTime _lastTime = DateTime.MinValue;

    public Predicate<DateTime>? Condition { get; private set; } = null;

    public event Action<DateTime, CancellationToken?>? CurTimeChanged;
    public event Action<DateTime, CancellationToken?>? TrueCondition;

    private readonly CancellationTokenSource _tokenSource = new();

    public void StartClock() {
        lock (_locker) {
            if (_isRunning) {
                throw new InvalidOperationException("Часы уже запущены.");
            }
            _isRunning = true;
            _lastTime = DateTime.MinValue;

            // Запускаем таймер с интервалом 500 мс
            _timer = new Timer(Tick, null, 0, 500);
        }
    }

    private void Tick(object? state) {
        DateTime now = DateTime.Now;

        lock (_locker) {
            // Проверяем изменение секунды
            if (now.Second != _lastTime.Second) {
                CurTimeChanged?.Invoke(now, _tokenSource.Token);

                if (Condition?.Invoke(now) == true) {
                    TrueCondition?.Invoke(now, _tokenSource.Token);
                }

                _lastTime = now; // Обновляем время
            }
        }
    }

    public void ChangeCondition(Predicate<DateTime> condition) {
        if (condition is null) throw new ArgumentNullException(nameof(condition));

        lock (_locker) {
            Condition = condition;
        }
    }

    public void Dispose() {
        lock (_locker) {
            _isRunning = false;
            _timer?.Dispose();
            _tokenSource.Cancel();
        }
    }
}
