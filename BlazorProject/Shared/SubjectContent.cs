using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorProject.Shared
{
    public class SubjectContent : EventEntry
    {
        public Guid ID { get; set; }

        public Subject Subject { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public double Hours { get; set; }
    }
}
