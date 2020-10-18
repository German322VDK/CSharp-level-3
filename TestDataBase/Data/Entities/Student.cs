using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestDataBase.Data.Entities
{
    abstract class Entity
    {
        public int Id { get; set; }
    }

    abstract class NamedEntity : Entity
    {
        public string  Name { get; set; }
    }
    class Student : NamedEntity
    {
        [Required, MaxLength(120)]
        public string Surname { get; set; }
        [MaxLength(120)]
        public string Patronymic { get; set; }
        public virtual Group Group { get; set; } //Навигационные свойства 
    }
    
    class Group : NamedEntity
    {
        public string Discription { get; set; }
        public virtual ICollection<Student> Students { get; set; } //Навигационные свойства 
    }
}
