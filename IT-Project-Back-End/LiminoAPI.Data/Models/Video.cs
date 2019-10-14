using System.ComponentModel.DataAnnotations.Schema;

namespace LiminoAPI.Data.Models
{
    public class Video : BaseEntity
    {
        public string VideoUrl { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public long CategoryId { get; set; }

        public override bool Equals(object obj)
        {
            var video = obj as Video;

            if (video == null)
            {
                return false;
            }

            return Id.Equals(video.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
