using System.IO;
using System.Net.Http;
using System.Collections.Generic;

namespace Events{
  
  public class Log{
    
    public static readonly HttpClient client = new HttpClient();

    public async void Write(string c1, string c2, string c3){

        string[] data = {c1, c2, c3}; 
        string url = "http://localhost/Web_build/index.php";

        var values = new Dictionary<string, string>
        {
            { "EVENT", data[0] },
            { "VALUE", data[1] },
            { "TIME", data[2] }
        };

        var content = new FormUrlEncodedContent(values);

        var response = await client.PostAsync(url, content);

        var responseString = await response.Content.ReadAsStringAsync();

    }

  }

}