using System.Reflection;
using System.Timers;
using blazordemo.Adapters;
using blazordemo.Pages;
using Bunit;
using Moq;

namespace blazordemotests;

public class PomodoroTests
{
    [Fact]
    public void Returns_Minutes_Remaining()
    {
        var mockTimer = new Mock<IPomTimer>();
        var pom = new Pomodoro(mockTimer.Object);
        Assert.Equal("00", pom.MinutesLeft);
    }

    [Fact]
    public void Returns_Seconds_Remaining()
    {
        var mockTimer = new Mock<IPomTimer>();
        var pom = new Pomodoro(mockTimer.Object);
        Assert.Equal("00", pom.SecondsLeft);
    }

    [Fact]
    public void Sets_Default_Time_Left()
    {
        var mockTimer = new Mock<IPomTimer>();
        var result = new Pomodoro(mockTimer.Object);

        Assert.Equal(20 * 60, result.TimeLeft);
    }

    [Fact]
    public void Shows_Default_Time_Counter_On_Render()
    {
        var ctx = new TestContext();
        var comp = ctx.RenderComponent<Pomodoro>();

        comp.Find("#minutesLeft").MarkupMatches(@"<p role = ""status"" id = ""minutesLeft"" > Time Left: 00 : 00 </ p >");
    }

    [Fact]
    public void Shows_Seconds_Left_When_Timer_Started()
    {
        var ctx = new TestContext();
        var comp = ctx.RenderComponent<Pomodoro>();

        var ctor = typeof(ElapsedEventArgs).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic).First();
        var args = (ElapsedEventArgs)ctor.Invoke(new object[] { DateTime.Now });

        comp.InvokeAsync(() => comp.Instance.OnTimedEvent(new Object(), args));

        comp.Find("#minutesLeft").MarkupMatches(@"<p role = ""status"" id = ""minutesLeft"" > Time Left: 19 : 59 </ p >");
    }
}
