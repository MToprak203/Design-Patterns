TrafficLight trafficLight = new TrafficLight();

trafficLight.ReportState(); // Output: Traffic light is RED

trafficLight.PerformAction(); // Output: Changing state from RED to GREEN
trafficLight.ReportState(); // Output: Traffic light is GREEN

trafficLight.PerformAction(); // Output: Changing state from GREEN to YELLOW
trafficLight.ReportState(); // Output: Traffic light is YELLOW

trafficLight.PerformAction(); // Output: Changing state from YELLOW to RED
trafficLight.ReportState(); // Output: Traffic light is RED