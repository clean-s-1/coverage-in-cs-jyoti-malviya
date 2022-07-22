using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
    public interface ITypewiseAlert
    {
        void SendToEmail(string breachType) => throw new NotImplementedException();

        void SendToController(string breachType) => throw new NotImplementedException();
        void RecepientMessage(string recepient, string btype) => throw new NotImplementedException();

        void CheckAndAlert(
       AlertTarget alertTarget, BatteryCharacter batteryChar, double temperatureInC) => throw new NotImplementedException();
        void AlertTraget(AlertTarget alertTarget, string breachType) => throw new NotImplementedException() ;

        string ClassifyTemperatureBreach(
            CoolingType coolingType, double temperatureInC) => throw new NotImplementedException();

        void SetUpperLimit(ref int upperlimit, CoolingType coolingtype) => throw new NotImplementedException();
        string InferBreach(double value, double lowerLimit, double upperLimit) => throw new NotImplementedException() ;


    }
}
