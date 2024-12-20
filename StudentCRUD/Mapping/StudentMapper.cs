﻿
using FluentNHibernate.Mapping;
using StudentCRUD.Models;

namespace StudentCRUD.Mapping
{
    public class StudentMapper: CommonMapper<Student>
    {
       
        public StudentMapper():base("Student")
        {
            Table("Student");
            //Id(x => x.Id).GeneratedBy.Identity();
            Map(x=>x.std_Id).Not.Nullable(); 
            Map(x => x.Name).Not.Nullable(); 
            Map(x => x.Age).Not.Nullable(); 
            Map(x => x.Email).Not.Nullable();
            //Map(x => x.CreatedAt).Not.Nullable();
            //Map(x => x.UpdatedAt);

        }
       

    }
}
