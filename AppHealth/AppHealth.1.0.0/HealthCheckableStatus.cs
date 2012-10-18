namespace AppHealth
{
    public class HealthCheckableStatus
    {
        public HealthCheckableStatus(string name, bool isUp) : this(name, isUp, null)
        {
            
        }

        public HealthCheckableStatus(string name, bool isUp, long? responseTime)
        {
            Name = name;
            IsUp = isUp;
            ResponseTime = responseTime;
        }

        public string Name { get; set; }
        public bool IsUp { get; set; }
        public long? ResponseTime { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} ms", Name, IsUp, ResponseTime.HasValue ? ResponseTime.Value.ToString() : "?");
        }
    }
}