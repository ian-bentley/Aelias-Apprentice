
using System.Diagnostics;

public class Timer
{
    // How long the timer lasts
    public float Duration { get; private set; }

    // How much time has passed since the start
    public float Elapsed { get; private set; }

    // Check if timer is running
    public bool IsRunning { get; private set; }

    // Check if timer is finished
    public bool IsFinished => IsRunning && Elapsed >= Duration;

    public Timer(float duration)
    {
        Duration = duration;

        // Reset timer so it's ready to start
        Reset();
    }

    // Starts the timer
    public void Start() => IsRunning = true;

    // Pauses the timer
    public void Stop() => IsRunning = false;

    // Resets the timer so it can start again
    public void Reset()
    {
        Elapsed = 0f;
        IsRunning = false;
    }

    // Updates timer using passed delta time
    public void Update(float deltaTime)
    {
        // If it's running, add the delta time to elapsed time
        if (!IsRunning) return;
        Elapsed += deltaTime;
    }

    // Resets and starts the timer
    public void Restart()
    {
        Elapsed = 0f;
        IsRunning = true;
    }
}
