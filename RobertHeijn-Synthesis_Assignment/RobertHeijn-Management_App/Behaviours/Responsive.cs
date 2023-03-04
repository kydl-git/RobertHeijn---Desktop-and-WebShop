#region

using System.Configuration;

#endregion

namespace RobertHeijn_Management_App.Behaviours;

internal sealed class Responsive
{
    private readonly float _heightAtDesignTime = (float)Convert.ToDouble
        (ConfigurationManager.AppSettings["DESIGN_TIME_SCREEN_HEIGHT"]);

    private readonly Rectangle _resolution;

    private readonly float _widthAtDesignTime = (float)Convert.ToDouble
        (ConfigurationManager.AppSettings["DESIGN_TIME_SCREEN_WIDTH"]);

    private float _heightMultiplicationFactor;
    private float _widthMultiplicationFactor;

    /// <summary>
    ///     Initializes a new instance of the <see cref="Responsive" /> class.
    /// </summary>
    /// <param name="resolutionParam">The resolution at design time.</param>
    public Responsive(Rectangle resolutionParam)
    {
        _resolution = resolutionParam;
    }

    public void SetMultiplicationFactor()
    {
        _widthMultiplicationFactor = _resolution.Width / _widthAtDesignTime;
        _heightMultiplicationFactor = _resolution.Height / _heightAtDesignTime;
    }

    public int GetMetrics(int componentValue)
    {
        return (int)Math.Floor(componentValue * _widthMultiplicationFactor);
    }

    public int GetMetrics(int componentValue, string direction)
    {
        switch (direction)
        {
            case "Width":
            case "Left":
                return (int)Math.Floor(componentValue * _widthMultiplicationFactor);
            case "Height":
            case "Top":
                return (int)Math.Floor(componentValue * _heightMultiplicationFactor);
            default:
                return 1;
        }
    }
}