using System.IO;

namespace Events{
  
  public class Log{
    
    public void Write(string c1, string c2, string c3){
        
        string text = "\"" + c1 + "\",\"" + c2 + "\",\"" + c3 + "\"";
        string path = Directory.GetCurrentDirectory();

		using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(path+@"\Logs\Log.csv", true))
        {
            file.WriteLine(text);
        }
    }

  }

}