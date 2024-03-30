// Context class
class TrafficLight
{
    private TrafficLightState _currentState;

    public TrafficLight()
    {
        // Initially, the traffic light starts with the red state
        _currentState = new RedState();
    }

    public void ChangeState(TrafficLightState state)
    {
        _currentState = state;
    }

    public void ReportState()
    {
        _currentState.ReportState();
    }

    public void PerformAction()
    {
        _currentState.ChangeState(this);
    }
}

// State interface
interface TrafficLightState
{
    void ReportState();
    void ChangeState(TrafficLight trafficLight);
}

// Concrete state classes
class RedState : TrafficLightState
{
    public void ReportState()
    {
        Console.WriteLine("Traffic light is RED");
    }

    public void ChangeState(TrafficLight trafficLight)
    {
        Console.WriteLine("Changing state from RED to GREEN");
        trafficLight.ChangeState(new GreenState());
    }
}

class GreenState : TrafficLightState
{
    public void ReportState()
    {
        Console.WriteLine("Traffic light is GREEN");
    }

    public void ChangeState(TrafficLight trafficLight)
    {
        Console.WriteLine("Changing state from GREEN to YELLOW");
        trafficLight.ChangeState(new YellowState());
    }
}

class YellowState : TrafficLightState
{
    public void ReportState()
    {
        Console.WriteLine("Traffic light is YELLOW");
    }

    public void ChangeState(TrafficLight trafficLight)
    {
        Console.WriteLine("Changing state from YELLOW to RED");
        trafficLight.ChangeState(new RedState());
    }
}