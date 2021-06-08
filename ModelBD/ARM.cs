namespace Ranel.ModelBD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ARM")]
    public partial class ARM
    {
        public int id { get; set; }

        [Column("Хранится На Складе")]
        [StringLength(50)]
        public string Хранится_На_Складе { get; set; }

        [Column("Компания Поставщик")]
        [StringLength(50)]
        public string Компания_Поставщик { get; set; }

        [Column("Поступление Товара")]
        [StringLength(50)]
        public string Поступление_Товара { get; set; }

        [Column("Отправка Товара")]
        [StringLength(50)]
        public string Отправка_Товара { get; set; }
    }
}
