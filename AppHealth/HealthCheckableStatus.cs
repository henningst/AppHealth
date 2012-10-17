namespace AppHealth
{
    public class HealthCheckableStatus
    {
        public HealthCheckableStatus(string name, bool isUp)
        {
            Name = name;
            IsUp = isUp;
        }

        public string Name { get; set; }
        public bool IsUp { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", Name, IsUp);
        }
    }
}