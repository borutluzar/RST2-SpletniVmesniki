using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorProject.Shared
{
    public class Subject : EventEntry
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        
        public int ECTS { get; set; }

        public int LectureHours { get; set; }

        public int TutorialHours { get; set; }
    }
}
