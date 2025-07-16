namespace SidekoOctaApi63CSharp;

public class Environment
{
    public static Environment Environment_ = new Environment("https://api.example.com");
    public static Environment MockServer = new Environment(
        "https://api.sideko-staging.dev/v1/mock/sideko-octa/sideko-octa-api-63/0.1.0"
    );

    public string Url { get; private set; }

    public Environment(string url)
    {
        this.Url = url;
    }
}
