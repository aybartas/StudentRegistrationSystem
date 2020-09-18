using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//aaa
namespace StudentRegistrationSystem.Models.Entity
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = " ")]
        [Range(10000000,99999999,ErrorMessage ="Lütfen geçerli bir kullanıcı adı giriniz")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Kullanıcı Adı sadece rakam içerebilir.")]
        public int UserID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public long CitizenshipNo { get; set; }
        public string Gender { get; set; }

        public string Phone { get; set; }
        public string EducationType { get; set; }
       
        [Display(Name = " ")]
        [Required(ErrorMessage ="Parola alanı boş bırakılamaz")]
        [StringLength(50,MinimumLength =1,ErrorMessage ="Lütfen geçerli bir şifre giriniz")]
        public string Password { get; set; }

        public string DepartmentCode { get; set; }

        public int LecturerID { get; set; }
        public string Role { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }

        public Department Department { get; set; }
        public Lecturer Lecturer { get; set; }


    }
}