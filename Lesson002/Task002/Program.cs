using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task002
{
    class Program
    {
        static void Main(string[] args)
        {
            Data data = new Data();
            View vis = new View(data);

            while (true)
            {
                vis.ShowData();

                vis.GetCommand();

            }

        }
    }
}
