using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2Q4
{
    //Author: Shane Doherty
    //Purpose: Program - Creates various classes and objects based on different types of phones/phone components
    //Restrictions: None
    class Program
    {
        //creates a phone object
        public abstract class Phone
        {
            private string phoneNumber;
            public string address;

            public string PhoneNumber
            {
                get
                {
                    return phoneNumber;
                }

                set
                {
                    phoneNumber = value;
                }
            }

            public abstract void Connect();
            public abstract void Disconnect();
        }

        //initializes phone interface
        public interface PhoneInterface
        {
            void Answer();
            void MakeCall();
            void HangUp();

        }

        //creates a rotary phone object
        public class RotaryPhone: Phone, PhoneInterface
        {
            public void Answer()
            {

            }

            public void MakeCall()
            {

            }

            public void HangUp()
            {

            }

            public override void Connect()
            {
                
            }

            public override void Disconnect()
            {
                
            }


        }

        //creates a pushbutton phone object
        public class PushButtonPhone: Phone, PhoneInterface
        {
            public void Answer()
            {

            }

            public void MakeCall()
            {

            }

            public void HangUp()
            {

            }

            public override void Connect()
            {

            }

            public override void Disconnect()
            {

            }
        }

        //creates a Tardis object
        public class Tardis: RotaryPhone
        {
            private bool sonicScrewdriver;
            private byte whichDoctorWho;
            private string femaleSideKick;
            public double exteriorSurfaceArea;
            public double interiorVolume;

            public byte WhichDrWho
            {
                get
                {
                    return whichDoctorWho;
                }
            }

            public string FemaleSideKick
            {
                get
                {
                    return femaleSideKick;
                }
            }

            //operator overload logic
            public static bool operator <(Tardis t1, Tardis t2)
            {
                if (t1.whichDoctorWho == 10 || t2.whichDoctorWho == 10)
                {
                    return true;
                } else
                {
                    return (t1.whichDoctorWho < t2.whichDoctorWho);
                }
                
            }

            public static bool operator >(Tardis t1, Tardis t2)
            {
                if (t1.whichDoctorWho == 10 || t2.whichDoctorWho == 10)
                {
                    return true;
                } else
                {
                    return (t1.whichDoctorWho > t2.whichDoctorWho);
                }
                
            }

            public static bool operator <=(Tardis t1, Tardis t2)
            {
                if (t1.whichDoctorWho == 10 || t2.whichDoctorWho == 10)
                {
                    return true;
                } else
                {
                    return (t1.whichDoctorWho <= t2.whichDoctorWho);
                }
                
            }

            public static bool operator >=(Tardis t1, Tardis t2)
            {
                if (t1.whichDoctorWho == 10 || t2.whichDoctorWho == 10)
                {
                    return true;
                } else
                {
                    return (t1.whichDoctorWho >= t2.whichDoctorWho);
                }
                
            }

            public static bool operator ==(Tardis t1, Tardis t2)
            {
                if (t1.whichDoctorWho == 10 || t2.whichDoctorWho == 10)
                {
                    return true;
                } else
                {
                    return (t1.whichDoctorWho == t2.whichDoctorWho);
                }
                
            }

            public static bool operator !=(Tardis t1, Tardis t2)
            {
                if (t1.whichDoctorWho == 10 || t2.whichDoctorWho == 10)
                {
                    return true;
                } else
                {
                  return (t1.whichDoctorWho != t2.whichDoctorWho);
                }
                
            }

            public void TimeTravel()
            {

            }
        }

        //creates a phone booth object
        public class PhoneBooth: PushButtonPhone
        {
            private bool superMan;
            public double costPerCall;
            public bool phoneBook;

            public void OpenDoor()
            {

            }

            public void CloseDoor()
            {

            }
        }

        //Author: Shane Doherty
        //Purpose: UsePhone - Calls different phone-related methods depending on the type of the passed object
        //Restrictions: None
        static void UsePhone(object obj)
        {
            PhoneInterface iPhone = null;
            PhoneBooth phoneBooth = null;
            Tardis tardis = null;

            if (obj is PhoneInterface)
            {
                iPhone = (PhoneInterface)obj;
                iPhone.MakeCall();
                iPhone.HangUp();

                if (obj is PhoneBooth)
                {
                    phoneBooth = (PhoneBooth)obj;
                    phoneBooth.OpenDoor();

                } else if (obj is Tardis)
                {
                    tardis = (Tardis)obj;
                    tardis.TimeTravel();
                }
            }
        }


        //Author: Shane Doherty
        //Purpose: Program - Calls UsePhone on a Tardis and a phone booth object.
        //Restrictions: None
        static void Main(string[] args)
        {
            Tardis tardis = new Tardis();
            PhoneBooth phoneBooth = new PhoneBooth();

            UsePhone(tardis);
            UsePhone(phoneBooth);

        }
    }
}
