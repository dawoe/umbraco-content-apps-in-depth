namespace TaskListApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    using NPoco;

    using Umbraco.Core.Persistence.DatabaseAnnotations;

    [TableName("CAID_Tasks")]
    [PrimaryKey("id", AutoIncrement = false)]
    [DataContract(Name = "task")]
    public class Task
    {
        public Task()
        {
            this.Id = Guid.NewGuid();
        }

        [Column("id")]
        [PrimaryKeyColumn(AutoIncrement = false, Name = "PK_CAID_Tasks")]
        [DataMember(Name = "id")]
        public Guid Id { get; set; }
        
        [Column("createdate")]
        [NullSetting(NullSetting = NullSettings.NotNull)]
        [DataMember(Name = "createDate")]
        public DateTime CreateDate { get; set; }

        [Column("createdby")]
        [NullSetting(NullSetting = NullSettings.NotNull)]
        [DataMember(Name = "createdBy")]
        public int CreatedBy { get; set; }

        [Column("assignedto")]
        [NullSetting(NullSetting = NullSettings.NotNull)]
        [DataMember(Name = "assignedTo")]
        public int AssignedTo { get; set; }

        [Column("title")]
        [NullSetting(NullSetting = NullSettings.NotNull)]
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [Column("description")]
        [NullSetting(NullSetting = NullSettings.NotNull)]
        [DataMember(Name = "description")]
        public string Description { get; set; }

        [Column("contentid")]
        [NullSetting(NullSetting = NullSettings.NotNull)]
        [DataMember(Name = "contentId")]
        public int ContentId { get; set; }
    }
}