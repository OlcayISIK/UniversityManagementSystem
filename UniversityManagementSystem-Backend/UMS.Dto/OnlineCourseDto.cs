﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Dto
{
    public class OnlineCourseDto
    {
        public long Id { get; set; }
        public int CourseId { get; set; }
        public string Days { get; set; }
        public DateTime Time { get; set; }
        public string Url { get; set; }

        public virtual CourseDto Course { get; set; }
    }
}
