using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtävä2
{
    class BLLotto
    {
        public string type;
        private int biggestNumber;
        private int numberAmount;

        private Random rnd = new Random();
        private bool additionalNumbers = false;

        public List<int> draw()
        {
            List<int> tmp = new List<int>();
            switch (type)
            {
                case "System.Windows.Controls.ComboBoxItem: Suomi":
                    biggestNumber = 39;
                    numberAmount = 7;
                    additionalNumbers = false;
                    break;
                case "System.Windows.Controls.ComboBoxItem: Viking":
                    biggestNumber = 48;
                    numberAmount = 6;
                    additionalNumbers = false;
                    break;
                case "System.Windows.Controls.ComboBoxItem: Eurojackpot":
                    biggestNumber = 50;
                    numberAmount = 5;
                    additionalNumbers = true;
                    break;
            }

            for (int i = 0; i < numberAmount; i++)
            {
                bool numberIsUsed;
                int newNumber;
                do
                {
                    newNumber = rnd.Next(1, biggestNumber);
                    numberIsUsed = false;

                    for (int j = 0; j < tmp.Count; j++)
                    {
                        if (tmp[j] == newNumber)
                        {
                            numberIsUsed = true;
                        }
                    }
                } while (numberIsUsed == true);

                tmp.Add(newNumber);
            }

            tmp.Sort();

            if (additionalNumbers == true)
            {
                int firstAdditionalNumber = rnd.Next(1, 8);
                int secondAdditionalNumber;
                do
                {
                    secondAdditionalNumber = rnd.Next(1, 8);
                } while (secondAdditionalNumber == firstAdditionalNumber);
                if (secondAdditionalNumber < firstAdditionalNumber)
                {
                    int tmpInt = firstAdditionalNumber;
                    firstAdditionalNumber = secondAdditionalNumber;
                    secondAdditionalNumber = tmpInt;
                }
                tmp.Add(firstAdditionalNumber);
                tmp.Add(secondAdditionalNumber);
            }

            return tmp;
        }

        public List<int> draw(string selectedType)
        {
            List<int> tmp = new List<int>();

            switch (selectedType)
            {
                case "System.Windows.Controls.ComboBoxItem: Suomi":
                    biggestNumber = 39;
                    numberAmount = 7;
                    additionalNumbers = false;
                    break;
                case "System.Windows.Controls.ComboBoxItem: Viking":
                    biggestNumber = 48;
                    numberAmount = 6;
                    additionalNumbers = false;
                    break;
                case "System.Windows.Controls.ComboBoxItem: Eurojackpot":
                    biggestNumber = 50;
                    numberAmount = 5;
                    additionalNumbers = true;
                    break;
            }
  
            for (int i = 0; i < numberAmount; i++)
            {
                bool numberIsUsed;
                int newNumber;
                do
                {
                    newNumber = rnd.Next(1, biggestNumber);
                    numberIsUsed = false;

                    for (int j = 0; j < tmp.Count; j++)
                    {
                        if (tmp[j] == newNumber)
                        {
                            numberIsUsed = true;
                        }
                    }
                } while (numberIsUsed == true);

                tmp.Add(newNumber);
            }

            tmp.Sort();

            if (additionalNumbers == true)
            {
                int firstAdditionalNumber = rnd.Next(1, 8);
                int secondAdditionalNumber;
                do
                {
                    secondAdditionalNumber = rnd.Next(1, 8);
                } while (secondAdditionalNumber == firstAdditionalNumber);
                if (secondAdditionalNumber < firstAdditionalNumber)
                {
                    int tmpInt = firstAdditionalNumber;
                    firstAdditionalNumber = secondAdditionalNumber;
                    secondAdditionalNumber = tmpInt;
                }
                tmp.Add(firstAdditionalNumber);
                tmp.Add(secondAdditionalNumber);
            }

            return tmp;
        }

        public BLLotto()
        {
            this.numberAmount = 7;
            this.biggestNumber = 39;
            this.type = "System.Windows.Controls.ComboBoxItem: Suomi";
        }
    }
}
