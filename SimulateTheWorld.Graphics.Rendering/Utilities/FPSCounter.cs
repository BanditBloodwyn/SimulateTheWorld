namespace SimulateTheWorld.Graphics.Rendering.Utilities;

public class FPSCounter
{
    private double _timeDifference;
    private int _counter;

    public static int Interval = 100;

    public double FPS { get; private set; }
    public double Milliseconds { get; private set; }

    public double TimeDifference
    {
        set
        {
            _timeDifference = value;
            _counter++;

            if (_timeDifference >= 1.0 / 30.0)
            {
                FPS = 1.0 / _timeDifference * _counter * 1000;
                Milliseconds = _timeDifference / _counter;
                _counter = 0;
            }
        }
    }
}