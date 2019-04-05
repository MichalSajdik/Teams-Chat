﻿using System;
using System.Collections.Generic;
using Teams.BL.Models.Base;

namespace Teams.BL.Models
{
    public class TeamMemberModel : ModelBase
    {
        public UserModel Member { get; set; }
        public TeamModel Team { get; set; }
    }
}
