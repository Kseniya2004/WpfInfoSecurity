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
    
    public partial class Activities
    {
        public int Id { get; set; }
        public Nullable<int> EventId { get; set; }
        public string ActivityName { get; set; }
        public Nullable<int> Day { get; set; }
        public Nullable<System.TimeSpan> StartTime { get; set; }
        public Nullable<int> ModeratorId { get; set; }
        public Nullable<int> JuryFirst { get; set; }
        public Nullable<int> JurySecond { get; set; }
        public Nullable<int> JuryThird { get; set; }
        public Nullable<int> JuryFourth { get; set; }
        public Nullable<int> JuryFifth { get; set; }
        public Nullable<int> Winner { get; set; }
    
        public virtual Events Events { get; set; }
        public virtual Juries Juries { get; set; }
        public virtual Juries Juries1 { get; set; }
        public virtual Juries Juries2 { get; set; }
        public virtual Juries Juries3 { get; set; }
        public virtual Juries Juries4 { get; set; }
        public virtual Members Members { get; set; }
        public virtual Moderators Moderators { get; set; }
    }
}
