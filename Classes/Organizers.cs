//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfInfoSecurity.Classes
{
    using System;
    using System.Collections.Generic;
    
    public partial class Organizers
    {
        public int Id { get; set; }
        public string Fio { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public Nullable<int> CountryId { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
        public Nullable<int> GenderId { get; set; }
    
        public virtual Country Country { get; set; }
        public virtual Gender Gender { get; set; }
    }
}
