using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Data
{
    /// <summary>
    /// Klassen för en deltagare
    /// </summary>
    public class PersonData
    {
        /// <summary>
        /// Deltagarens förnamn
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// deltagarens efternamn
        /// </summary>
        public string Lastname { get; set; }
        /// <summary>
        /// deltagarens mailadress
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// deltagarens tel.nummer
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}
