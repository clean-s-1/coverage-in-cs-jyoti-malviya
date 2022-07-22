using System;

namespace TypewiseAlert
{
  public class TypewiseAlert : ITypewiseAlert
    {
       
        public static string InferBreach(double value, double lowerLimit, double upperLimit)
        {
            return (value < lowerLimit) ? BreachType.TOO_LOW : (value > upperLimit) ? BreachType.TOO_HIGH : BreachType.NORMAL;
        }

        public static void SetUpperLimit(ref int upperlimit, CoolingType coolingtype)
        {
            upperlimit = CoolingType.PASSIVE_COOLING == coolingtype ? 35 :
            CoolingType.HI_ACTIVE_COOLING == coolingtype ? 45 : 40;
        }

        public static string ClassifyTemperatureBreach(
            CoolingType coolingType, double temperatureInC)
        {
            int lowerLimit = 0;
            int upperLimit = 0;
            SetUpperLimit(ref upperLimit, coolingType);
            return InferBreach(temperatureInC, lowerLimit, upperLimit);
        }

        public static void AlertTraget(AlertTarget alertTarget, string breachType)
        {
            if (AlertTarget.TO_CONTROLLER == alertTarget)
            {
                SendToController(breachType);
            }
            else
            {
                SendToEmail(breachType);
            }
        }

        public static void CheckAndAlert(
        AlertTarget alertTarget, BatteryCharacter batteryChar, double temperatureInC)
        {
            string breachType = ClassifyTemperatureBreach(
              batteryChar.coolingType, temperatureInC
            );
            AlertTraget(alertTarget, breachType);
        }

        public static void RecepientMessage(string recepient, string btype)
        {
            Console.WriteLine("To:", recepient, "\n");
            Console.WriteLine("Hi, the temperature is too\n" + btype);
        }

        public static void SendToController(string breachType)
        {
            const ushort header = 0xfeed;
            Console.WriteLine(header.ToString(), ":", breachType, "\n");
        }
        public static void SendToEmail(string breachType)
        {
            string recepient = "a.b@c.com";
            RecepientMessage(recepient, breachType);
        }
    }
}
