using System;

namespace ADOMiniProj;
class Program
{
    static void Main(string[] args)
    {
		try
		{
			App app = new App();
			app.ShowUI();
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
            Console.ReadKey();
        }
    }
}