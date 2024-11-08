using TestCase.DataWriter;
using TestCase.Entities;

namespace TestCase
{
    public class ConsoleDataWriter : IDataWriter
    {
        private static ConsoleDataWriter? writer;

        protected ConsoleDataWriter()
        {
        }

        public static ConsoleDataWriter getWriter()
        {
            if (writer == null)
                writer = new ConsoleDataWriter();
            return writer;
        }

        public void PrintAllPalletsAndBoxesInIt(List<Pallet> pallets)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("***PALLETS AND BOXES IN IT***");
            Console.WriteLine("--------------------------------\n");

            foreach (var pallet in pallets)
            {
                Console.WriteLine(pallet.ToString());
                if (pallet.boxes is not null)
                {
                    foreach (var box in pallet.boxes)
                    {
                        Console.WriteLine(box.ToString());
                    }
                    Console.WriteLine("*******************");

                }
            }
        }

        public void PrintOrderedPalletsByStorageLife(List<Group> groups)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("ORDERED BY STORAGE LIFE AND WEIGHT");
            Console.WriteLine("----------------------------------\n");

            foreach (var group in groups)
            {
                Console.WriteLine(group.ToString());
                Console.WriteLine("*******************");
            }
        }

        public void PrintTopThreePallets(List<Pallet> pallets)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("TAKE 3 PALLET WHERE BOX STORAGE LIFE MAX");
            Console.WriteLine("----------------------------------------\n");

            foreach (var pallet in pallets)
            {
                Console.WriteLine(pallet.ToString());
                foreach (var box in pallet.boxes!)
                {
                    Console.WriteLine(box.ToString());
                }
                Console.WriteLine("*******************");
            }

        }
    }
}