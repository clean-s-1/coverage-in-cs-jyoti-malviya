using Moq;
using System;
using Xunit;

namespace TypewiseAlert.Test
{
  public class TypewiseAlertTest
  {
        private Mock<ITypewiseAlert> TypewiseAlertt = new Mock<ITypewiseAlert>();

        [Fact]
        public void InfersLowerBreachLimit()
        {
            Assert.True(TypewiseAlert.InferBreach(12, 20, 30) ==
              BreachType.TOO_LOW);
        }

        [Fact]
        public void InfersUpperBreachLimit()
        {
            Assert.True(TypewiseAlert.InferBreach(105, 55, 100) ==
              BreachType.TOO_HIGH);
        }

        [Fact]
        public void InfersNormalBreachLimit()
        {
            Assert.True(TypewiseAlert.InferBreach(65, 50, 90) ==
              BreachType.NORMAL);
        }

        [Fact]
        public void ClassifyLowerTempBreach()
        {
            Assert.True(TypewiseAlert.ClassifyTemperatureBreach(CoolingType.PASSIVE_COOLING, -1) ==
              BreachType.TOO_LOW);
        }

        [Fact]
        public void ClassifyNormalTempBreach()
        {
            Assert.True(TypewiseAlert.ClassifyTemperatureBreach(CoolingType.PASSIVE_COOLING, 36) ==
              BreachType.TOO_HIGH);
        }

        [Fact]
        public void ClassifyHighTempBreach()
        {
            Assert.True(TypewiseAlert.ClassifyTemperatureBreach(CoolingType.PASSIVE_COOLING, 20) ==
              BreachType.NORMAL);
        }


        [Fact]
        public void SendEmail()
        {
            TypewiseAlert.SendToEmail(BreachType.TOO_HIGH);
            TypewiseAlertt.Verify(x => x.RecepientMessage(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }


        [Fact]
        public void CheckAndAlert()
        {
            BatteryCharacter b = new BatteryCharacter
            {
                coolingType = CoolingType.PASSIVE_COOLING
            };
            TypewiseAlert.CheckAndAlert(AlertTarget.TO_CONTROLLER,b, 1);
            TypewiseAlertt.Verify(x => x.ClassifyTemperatureBreach(
              It.IsAny<CoolingType>(), It.IsAny<double>()
            ), Times.Never);

            TypewiseAlertt.Verify(x => x.AlertTraget(
             It.IsAny<AlertTarget>(), It.IsAny<string>()
           ), Times.Never);
        }
    }
}
