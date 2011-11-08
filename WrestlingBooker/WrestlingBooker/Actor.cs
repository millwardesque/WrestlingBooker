using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WrestlingBooker
{
    /// <summary>
    /// Describes an actor entity
    /// </summary>
    class Actor
    {
        private string _name;   // Name of the actor

        /// <summary>
        /// Name of the actor
        /// </summary>
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
