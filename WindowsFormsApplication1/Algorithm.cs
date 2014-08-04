using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class Algorithm
    {

        public static int ryzy { get; private set; }
        public static int wolne_miejsce { get; private set; }

        public static Dictionary<int, List<int>> runAlgorithm(int Max, int Tolerance, int Step, int NofTry, Dictionary<int, int> borders, List<int> panelsNumber, List<int> panelspriorNumber, int interspace, Random rand)
        {
            int ctrl;
            int _height, id = 0;
            int pomoc = 0;
            int temp1 = 0;
            int temp2 = 0;
            bool status, flaga1, flaga2;

            Dictionary <int, List<int>> Magazyn = new Dictionary<int, List<int>>();
            List<int> SetofHeight;
            List<int> index1 = new List<int>();
            List<int> index2 = new List<int>();

            ryzy = 0;
            wolne_miejsce = 0;

            //================================================================
            foreach (KeyValuePair<int, int> element in borders.Reverse())
            {

                Max = 0;

            label:                  // Miejsce powrotu programu w przypadku niespełnienia warunku 1
                SetofHeight = new List<int>();
                flaga1 = false;
                flaga2 = false;
                status = false;
                temp1 = 0;
                temp2 = 0;
                ctrl = 0;
                while (!status)
                {

                    // Losowanie jednostajne bez powtórzeń

                    if (index1.Count < panelsNumber.Count || index2.Count < panelspriorNumber.Count)
                    {

                        if (index2.Count < panelspriorNumber.Count)
                        {
                            flaga2 = true;

                        losuj2:          // Miejsce powrotu programu w przypadku niespełnienia warunku 2

                            id = rand.Next(panelspriorNumber.Count);
                            // Warunek 2
                            if (!index2.Contains(id))
                            {
                                _height = panelspriorNumber[id];
                            }
                            else
                            {
                                goto losuj2; // Ponowne losowanie z powodu powtórzenia wylosowanej uprzednio liczby - indeksu
                            }
                        }
                        else
                        {
                            flaga1 = true;

                        losuj1:          // Miejsce powrotu programu w przypadku niespełnienia warunku 2


                            id = rand.Next(panelsNumber.Count);
                            // Warunek 2
                            if (!index1.Contains(id))
                            {
                                _height = panelsNumber[id];
                            }
                            else
                            {
                                goto losuj1; // Ponowne losowanie z powodu powtórzenia wylosowanej uprzednio liczby - indeksu
                            }
                        }
                    }
                    else
                    {
                        _height = panelsNumber[rand.Next(panelsNumber.Count)];
                    }
                    // Koniec losowania ================================   

                    ctrl = SetofHeight.Sum() + SetofHeight.Count * interspace + _height + interspace;

                    // Warunek 3
                    if (ctrl < borders[element.Key])
                    {
                        SetofHeight.Add(_height); // Dodanie nowego osobnika

                        if (flaga1) { index1.Add(id); temp1++; flaga1 = false; }     // Zliczanie dodanych osobników
                        if (flaga2) { index2.Add(id); temp2++; flaga2 = false; }    // Zliczanie dodanych osobników
                    }
                    else
                    {
                        status = true;
                    }


                }//end_while

                ctrl = 0;
                ctrl = SetofHeight.Sum() + SetofHeight.Count * interspace;

                // Warunek 1
                if ((borders[element.Key] - ctrl) > Max)
                {
                    index1.RemoveRange(index1.Count - temp1, temp1); // Usunięcie zbioru elementów, które nie spełniły warunku 1 (losowanie bez powtórzeń)
                    index2.RemoveRange(index2.Count - temp2, temp2);
                    pomoc++;
                    if (pomoc > NofTry) { Max += Step; pomoc = 0; }
                    goto label; // Powrót do tworzenia osobników dla danego pola
                }

                // Zliczanie wolnego miejsca dla całego obszaru roboczego
                wolne_miejsce = wolne_miejsce + (borders[element.Key] - ctrl);

                Magazyn.Add(element.Key,SetofHeight);
            }
            //==================================================================

            // Zliczanie ilości ryz dla całego obszaru roboczego
            foreach (KeyValuePair<int, List<int>> element in Magazyn)
            {
                ryzy = ryzy + element.Value.Count;
            }

            return Magazyn;

        }
    }
}
