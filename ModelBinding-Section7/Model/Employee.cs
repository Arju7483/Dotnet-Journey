namespace ModelBinding_Section7.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string toString()
        {
            return $"Employee Id = {Id} \n Employee Name = {Name}";
        }
    }
}
