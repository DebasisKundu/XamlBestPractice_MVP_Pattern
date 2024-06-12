using GHouseMobile.Core.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace GHouseMobile.Core.Models
{
    public class Field : BaseObservable
    {
        public string Value { get; set; }
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }
        public string PlaceHolder { get; set; }
    }
}
