using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10395938_PROG6221_POEPart1
{
    // The GreetingBase class is an abstract class, which means it cannot be instantiated directly.
    // It serves as a base class for other classes that provide specific implementations of the PlayGreeting method.
    public abstract class GreetingBase
    {
        // The PlayGreeting method is an abstract method. This means any derived class must provide 
        // its own implementation of how the greeting should be played.
        public abstract void PlayGreeting();
    }
}
