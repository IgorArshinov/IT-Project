using System.ComponentModel.DataAnnotations.Schema;

namespace LiminoAPI.Data.Models
{
    public class Audio : BaseEntity
    {
        public string FragmentUrl { get; set; }
        public string ImageUrl { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public long CategoryId { get; set; }
        
        
        public override bool Equals(object obj)
        {
            var audio = obj as Audio;

            if (audio == null)
            {
                return false;
            }

            return Id.Equals(audio.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
