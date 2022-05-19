﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Client.Dtos
{
    public class OnsiteCourseDto
    {
        public long Id { get; set; }
        public int CourseId { get; set; }
        public string Url { get; set; }

        public virtual CourseDto Course { get; set; }
    }
}