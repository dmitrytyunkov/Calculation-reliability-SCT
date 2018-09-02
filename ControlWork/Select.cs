using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ControlWork
{
    class Select
    {
        public static List<Electricalradioelement> electricalradioelement;
        public static string titleBlock;
        public static int additionNum;
        public static int variantNumber;

        public static void SelectElectricalradioelement(int selectedGroup)
        {
            electricalradioelement = new List<Electricalradioelement>();
            XDocument xDocument = XDocument.Load("res/Electricradioelement.xml");
            foreach (XElement electricalradioElement in xDocument.Element("electricradioelements").Elements("electricradioelement"))
            {
                XAttribute nameElement = electricalradioElement.Attribute("title");
                XElement lambdaElement = null;
                if (selectedGroup == 0)
                    lambdaElement = electricalradioElement.Element("for_ground");
                else if (selectedGroup == 1)
                    lambdaElement = electricalradioElement.Element("for_see");
                electricalradioelement.Add(new Electricalradioelement(nameElement.Value, Convert.ToDouble(lambdaElement.Value)));
            }
        }

        public static void SelectVariant(decimal variantNum)
        {
            XDocument xDocument = XDocument.Load("res/Variant.xml");
            foreach (XElement variantElement in xDocument.Element("variants").Elements("variant"))
            {
                decimal variant = Convert.ToInt32(variantElement.Attribute("name").Value);
                if (variant == variantNum)
                {
                    variantNumber = Convert.ToInt32(variant);
                    titleBlock = variantElement.Element("title_block").Value;
                    additionNum = Convert.ToInt32(variantElement.Element("addition_num").Value);
                    break;
                }
            }
        }

        public static List<Electricalradioelement> GetElectricalradioelement()
        {
            return electricalradioelement;
        }

        public static string GetTitleBlock()
        {
            return titleBlock;
        }

        public static int GetAdditionNum()
        {
            return additionNum;
        }

        public static int GetVariantNumber()
        {
            return variantNumber;
        }
    }
}
