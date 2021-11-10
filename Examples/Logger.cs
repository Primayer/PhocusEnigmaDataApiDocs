
public class Logger
{
    public string Serial { get; set; }
    public List<Epoch> Epochs { get; set; }
}

public class Epoch
{
    public string Timestamp { get; set; }
    public int Lcf { get; set; }
    public int Cnv { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double Battery { get; set; }
    public double Temperature { get; set; }
    public Histogram Histogram {  get; set; }
}

public class Histogram
{
    public string Timestamp { get; set; }
    public List<int> Bins { get; set; }
}

