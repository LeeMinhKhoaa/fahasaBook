namespace Fahasa.ViewModel
{
    public class CartItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public int Quanlity { get; set; }
        public double ThanhTien => Quanlity * Price;
    }
}
