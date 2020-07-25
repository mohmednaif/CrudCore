using System;
using System.Collections.Generic;

namespace EFDataAccess.Data
{
    public partial class State
    {
        public int StateId { get; set; }
        public int? CountryId { get; set; }
        public string StateName { get; set; }
    }
}
