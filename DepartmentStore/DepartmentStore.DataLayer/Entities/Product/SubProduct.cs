using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DepartmentStore.DataLayer.Entities.Product
{
    public class SubProduct
    {
        [Key]
        public int SubProductId { get; set; }

        [Required]
        public int ProductId { get; set; }
        
        [Required]
        public int MadeId { get; set; }

        [Display(Name = "عنوان محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string SubProductTitle { get; set; }

        [Display(Name = "ابعاد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Dimention { get; set; }


        [Display(Name = "شرح محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ProductDescription { get; set; }

        [Display(Name = "قیمت محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int ProductPrice { get; set; }

        [Display(Name = "کلمات کلیدی")]
        [MaxLength(600)]
        public string Tags { get; set; }

        [MaxLength(50)]
        public string SubProductImageName { get; set; }

        public bool IsDeleteInOrder { get; set; }

        #region Relations

        public Product Product { get; set; }
        public CountryMade CountryMade { get; set; }


        #endregion

    }
}
