﻿using AssetManager.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Core.Entities
{
    public class Departments: Entity
    {
        [Display(Name = "Department Name")]
        public string Name { get; set; }


        [Display(Name = "Company")]
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }


        [Display(Name = "Location")]
        [ForeignKey("Location")]
        public int LocatonId { get; set; }
        public virtual Location Location { get; set; }

        public string ManagerId { get; set; }

        [Display(Name = "Note")]
        public string Note { get; set; }

        [Display(Name = "Image")]
        public string Image { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime DeletedAt { get; set; }
    }
}
