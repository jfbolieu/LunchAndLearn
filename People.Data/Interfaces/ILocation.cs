namespace People.Data.Interfaces
{
    public interface ILocation
    {
        string Address { get; set; }
        string City { get; set; }
        string Coordinates { get; set; }
        string Name { get; set; }
        string PostalCode { get; set; }
        int ProvinceId { get; set; }
        string Room { get; set; }
    }
}