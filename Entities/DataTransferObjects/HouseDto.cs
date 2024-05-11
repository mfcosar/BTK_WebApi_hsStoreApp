namespace Entities.DataTransferObjects
{
    /* */

    //[Serializable] -->propları açık yazınca kaldırmazsan, _backfieldlarla karmakarışık bir output gelir.
    public record HouseDto
    {
        public int Id { get; init; }
        public String Type { get; init; }
        public decimal Price { get; init; }
        public String Location { get; init; }
    }
}
