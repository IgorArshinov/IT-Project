namespace LiminoAPI.Business
{
    public class VideoDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string VideoUrl { get; set; }
        public long CategoryId { get; set; }

        public override bool Equals(object obj)
        {
            var videoDto = obj as VideoDTO;

            if (videoDto == null)
            {
                return false;
            }

            return Id.Equals(videoDto.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
