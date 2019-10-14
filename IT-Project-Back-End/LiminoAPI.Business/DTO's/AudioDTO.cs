namespace LiminoAPI.Business.DTO_s
{
    public class AudioDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string FragmentUrl { get; set; }
        public string ImageUrl { get; set; }
        public long CategoryId { get; set; }


        public override bool Equals(object obj)
        {
            var item = obj as AudioDTO;

            if (item == null)
            {
                return false;
            }

            return this.Id.Equals(item.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}