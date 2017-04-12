using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainProject
{
    class PowerController
    {
        double Kp = 40000;
        double Ki = 200;
        double currSpeed;
        double setSpeed;
        double error;
        double power;
        double u;
        double uk;
        double ek;
        double maxPower;

        public PowerController(double m, double mP)
        {
            maxPower = mP;
        }

        public double getPower(double cS, double sS)
        {
            currSpeed = cS;
            setSpeed = sS;
            error = setSpeed - currSpeed;
            u = uk + (1 / 2) * (error + ek);
            ek = error;
            power = Kp * error + Ki * u;
            if (power > maxPower)
            {
                u = uk;
                power = maxPower;
            }
            else uk = u;
            if (power < 0) power = 0;
            return power;
        }
    }
}
