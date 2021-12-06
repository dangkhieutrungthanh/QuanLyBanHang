using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace QuanLyBanHang.Models
{
    public class StringProcess
    {
        public string AutoGennerateKey(string id)
        {
            string numPart, strPart, newKey;
            int intNumber;
            numPart = Regex.Match(id, @"\d+").Value;
            strPart = Regex.Match(id, @"\D+").Value;
            intNumber = Convert.ToInt32(numPart) + 1;
            for (int i = 0; i < numPart.Length - intNumber.ToString().Length; i++)
            {
                strPart += "0";
            }
            newKey = strPart + intNumber;
            return newKey;
        }
    }
}