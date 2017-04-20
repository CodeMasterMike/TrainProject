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
        double power1 = 0;
        double power2 = 0;
        double power3 = 0;
        Random rnd;

        public PowerController(double m, double mP)
        {
            maxPower = mP;
            rnd = new Random();
        }

        public double getPower(double cS, double sS)
        {
            int choice = rnd.Next(3);
            power1 = getPower1(cS, sS);
            power2 = getPower2(cS, sS);
            power3 = getPower3(cS, sS);
            if (power1 == power2 && power2 == power3)
            {
                if (choice == 0)
                {
                    return (power1 + power2) / 2;
                }
                else if(choice == 1)
                {
                    return (power1 + power3) / 2;
                }
                else
                {
                    return (power2 + power3) / 2;
                }
            }
            else return 0;
        }
        private double getPower1(double cS, double sS)
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
        private double getPower3(double cS, double sS)
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
        private double getPower2(double cS, double sS)
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
