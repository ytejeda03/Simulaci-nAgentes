using System;
using System.Collections.Generic;
using System.Text;

namespace AgentsSimulationProject
{
    public class AmbientElement
    {
        public Tuple<int, int> BoardPosition { get; set; }
        public AmbientElement()
        {

        }
    }
    public class Baby : AmbientElement
    {
        public bool InCrib { get; set; }
        public bool InRobot { get; set; }
        public Crib Crib { get; set; }
        public Baby()
        {
            InCrib = false;
            InRobot = false;
        }
    }
    public class Crib : AmbientElement
    {
        public bool IsFilled { get; set; }
        public Crib()
        {
            IsFilled = false;
        }
    }

    public class Object : AmbientElement
    {
        public Object()
        {
        }
    }
}
