namespace BusShuttle.Tests;

using BusShuttle;

public class ReportTests
{

    List<PassengerData> sampleData;

    public ReportTests()
    {
        sampleData = new List<PassengerData>();
    }

    [Fact]
    public void Test_FindBusiestStop_Just2stops()
    {
        Stop sampleStop = new Stop("MyStop");
        Loop sampleLoop = new Loop("MyLoop");
        Driver sampleDriver = new Driver("Driver");
        PassengerData data = new PassengerData(5, sampleStop, sampleLoop, sampleDriver);
        sampleData.Add(data);

        Stop sampleStop2 = new Stop("MyStop2");
        PassengerData data2 = new PassengerData(6, sampleStop2, sampleLoop, sampleDriver);
        sampleData.Add(data2);

        var result = Reporter.FindBusiestStop(sampleData);
        Assert.Equal("MyStop2", result.Name);
    }

}