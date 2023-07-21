
using Banking.Domain;

namespace Banking.UnitTests.BusinessClock;

public class BusinessClockTests
{
    [Fact]
    public void WeAreClosedBeforeOpening()
    {
        var stubbedClock = new Mock<ISystemTime>();
        stubbedClock.Setup(c => c.GetCurrent())
            .Returns(new DateTime(1969, 4, 20, 8, 59, 59));
        IProvideTheBusinessClock clock = new RegularBusinessClock(stubbedClock.Object);

        Assert.False(clock.IsDuringBusinessHours());
    }

    [Fact]
    public void WeAreOpenAfterNine()
    {
        var stubbedClock = new Mock<ISystemTime>();
        stubbedClock.Setup(c => c.GetCurrent())
            .Returns(new DateTime(1969, 4, 20, 9, 0, 0));
        IProvideTheBusinessClock clock = new RegularBusinessClock(stubbedClock.Object);

        Assert.True(clock.IsDuringBusinessHours());
    }
}
