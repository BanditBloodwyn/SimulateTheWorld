namespace SimulateTheWorld.Graphics.Rendering.Utilities;

public class FPSCounter
{
    private double _currentTime;
    private double _previousTime;
    private double _timeDifference;
    private int _counter;

    public double FPS { get; private set; }
    public double Milliseconds { get; private set; }

    public double CurrentTime
    {
        set
        {
            _currentTime = value;
            _timeDifference = _currentTime - _previousTime;
            _counter++;

            if (_timeDifference >= 1.0 / 30.0)
            {
                FPS = 1.0 / _timeDifference * _counter;
                Milliseconds = _timeDifference / _counter * 1000;
                _counter = 0;
                _previousTime = _currentTime;
            }
        }
    }
}