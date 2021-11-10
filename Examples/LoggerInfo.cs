
public class LoggerInfo
{
    public string Serial { get; set; }
    public List<EpochInfo> Epochs { get; set; }
}

public class EpochInfo
{
    public string Timestamp { get; set; }
    public int Lcf { get; set; }
    public int Cnv { get; set; }
    public double Battery { get; set; }
}

