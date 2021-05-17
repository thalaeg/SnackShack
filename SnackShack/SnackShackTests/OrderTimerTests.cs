using SnackShack;
using System;
using Xunit;

namespace SnackShackTests
{
    public class OrderTimerTests
    {                
        [Fact]
        public void ZeroOrders_ShouldPrint000()
        {
            var orderTimer = new OrderTimer(0);

            var consoleText = orderTimer.MakeSchedule();

            Assert.Equal("0:00", consoleText);
        }

        [Fact]
        public void OneOrders_ShouldPrintZeroAndOne()
        {
            var orderTimer = new OrderTimer(1);

            var consoleText = orderTimer.MakeSchedule();

            Assert.Equal("0:00 1 sandwhich order(s) placed, start making sandwich 1\n1:00 serve sandwich 1", consoleText);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(100)]
        public void GetIntroText(int numberOfSandwhiches)
        {
            var orderTimer = new OrderTimer(numberOfSandwhiches);

            var introText = orderTimer.GetIntroText();
            Assert.Equal($"{numberOfSandwhiches} sandwhich order(s) placed, start making sandwich 1", introText);
        }

        [Fact]
        public void TwoOrders_ShouldPrintZeroOneAndTwo()
        {
            var orderTimer = new OrderTimer(2);

            var consoleText = orderTimer.MakeSchedule();

            Assert.Equal($"0:00 {orderTimer.GetIntroText()}\n1:00 serve sandwich 1\n1:30 make sandwich 2\n2:30 serve sandwich 2", consoleText);
        }

        [Fact]
        public void SixOrders_ShouldPrintPreviousNumbersAndSix()
        {
            var orderTimer = new OrderTimer(6);

            var consoleText = orderTimer.MakeSchedule();

            Assert.Equal($"0:00 {orderTimer.GetIntroText()}\n1:00 serve sandwich 1\n1:30 make sandwich 2\n2:30 serve sandwich 2" 
                +"\n3:00 make sandwich 3\n4:00 serve sandwich 3"
                +"\n4:30 make sandwich 4\n5:30 serve sandwich 4"
                +"\n6:00 make sandwich 5\n7:00 serve sandwich 5"
                +"\n7:30 make sandwich 6\n8:30 serve sandwich 6", consoleText);
        }

        [Fact]
        public void IfOrderTakesMoreThan5Min_RejectAllOrdersAfter()
        {
            var orderTimer = new OrderTimer(4);
            var customerLineText = orderTimer.GetCustomerView();

            Assert.Equal("Sandwhich 4 can not be completed in time.", customerLineText);
        }
    }
}
