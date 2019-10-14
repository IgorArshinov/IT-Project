namespace LiminoAPI.Business.DTO_s
{
    public class CategoryDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        
        public override bool Equals(object obj)
        {
            var item = obj as CategoryDTO;

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
