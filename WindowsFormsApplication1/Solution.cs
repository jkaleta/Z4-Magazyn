using System.Collections.Generic;

namespace WindowsFormsApplication1
{
    public class Solution
    {

        public Dictionary<int, List<int>> list { get; set; } // Zawiera informacje o zbiorze wysokosci paneli dla poszczególnych pól

        public int ryzy { get; set; }            // Ilość ryz w całym obszarze roboczym
        public int wolne_miejsce { get; set; }   // Ilość pozostałego, wolnego miejsca w całym obszarze roboczym (suma z poszczególnych pól)

        public Solution (Dictionary<int, List<int>> list, int ryzy, int wolne_miejsce)
        {
            this.list = list;
            this.ryzy = ryzy;
            this.wolne_miejsce = wolne_miejsce;
        }
    }
}
