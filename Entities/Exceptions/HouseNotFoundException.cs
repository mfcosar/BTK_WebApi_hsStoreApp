namespace Entities.Exceptions
{
    public sealed class HouseNotFoundException : NotFoundException
    {
        public HouseNotFoundException(int id): base($"The house with id: {id} could not be found.")
        {
            
        }
    }
}
