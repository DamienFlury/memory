namespace Memory.Models
{
    public class Card
    {
        public Card(int id, int pairId, string image)
            => (Id, PairId, Image) = (id, pairId, image);
            
        public int Id { get; }
        public int PairId { get; }
        public string Image { get; }
        
    }
}