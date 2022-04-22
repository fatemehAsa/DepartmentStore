using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DepartmentStore.DataLayer.Entities.Product
{
    public class CountryMade
    {
        [Key]
        public int MadeId { get; set; }

        [Required]
        [MaxLength(150)]
        public string MadeTitle { get; set; }

        #region Relations

        public List<SubProduct> SubProducts { get; set; }


        #endregion

    }
}
