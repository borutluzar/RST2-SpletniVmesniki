using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorProject.Shared
{
    /// <summary>
    /// The parent class for all models that use created and edited dates
    /// </summary>
    public abstract class EventEntry
    {
        public virtual DateTime DateCreated { get; set; }

        public virtual DateTime DateUpdated { get; set; }
    }
}
