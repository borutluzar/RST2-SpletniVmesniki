using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorProject.Shared
{
    public class Conference : EventEntry
    {
        public Guid ID { get; set; }

        public string TalkTitle { get; set; }

        public string Remark { get; set; }
        
        public bool IsInvitedTalk { get; set; }

        public string Place { get; set; }

        public DateTime PresentationDate { get; set; }
    }
}
