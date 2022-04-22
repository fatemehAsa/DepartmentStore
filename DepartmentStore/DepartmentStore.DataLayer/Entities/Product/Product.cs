using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DepartmentStore.DataLayer.Entities.Product
{
   public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public int GroupId { get; set; }

        public int? SubGroupId { get; set; }

        [Display(Name = "عنوان بخش ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string ProductTitle { get; set; }

        [MaxLength(50)]
        public string ProductImageName { get; set; }

        #region Relations

        [ForeignKey("GroupId")]
        public ProductGroup ProductGroup { get; set; }

        [ForeignKey("SubGroupId")]
        public ProductGroup Group { get; set; }

        public List<SubProduct> SubProducts { get; set; }
        public DateTime CreateDate { get; set; }



        #endregion

    }
}
