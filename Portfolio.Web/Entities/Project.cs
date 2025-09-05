using System.ComponentModel.DataAnnotations;

namespace Portfolio.Web.Entities
{
	public class Project
	{
        public int ProjectId { get; set; }

        [MinLength(5,ErrorMessage ="Proje adı en az 5 karakter olmalıdır !")]
        [MaxLength(50,ErrorMessage ="Proje adı en fazla 50 karakter olmalıdır !")]
        [Required(ErrorMessage ="Proje adı boş bırakılamaz !")]
        public string ProjectName { get; set; }
        [Required(ErrorMessage = "Proje adı boş bırakılamaz !")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Img adı boş bırakılamaz !")]
        public string ImgUrl { get; set; }
        [Required(ErrorMessage = "GitHub Url boş bırakılamaz !")]
        public string GitHubUrl { get; set; }

        [Required(ErrorMessage = "Kategori adı boş bırakılamaz !")]
        public int CategoryId {  get; set; }

        //navigation property
        public Category? Category { get; set; }
    }
}
