using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;

// This application generates a driver report containing total miles driven
// and average speeds sorted by most miles driven to least. The miles driven
// and miles per hour are rounded to the nearest integer.
// Terry Driscoll

namespace DriverStatistics1
{
    public partial class Drivers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Results_Click(object sender, EventArgs e)
        {
            int cnt;
            int index = 0;
            int result = 0;
            bool modify = false;
            bool found = true;
            int location = 0;
            string line;
            string newItem;
            string stringResults;
            DateTime startTime;
            DateTime endTime;
            double totalTime;
            double averageSpeed;
            string resultSpeed;
            string resultMiles;
            double totalMiles;
            TimeSpan totalHour;
            string[] arr2 = new String[0];
            string inputfilepath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            string inputfile = Path.Combine(inputfilepath, "inputfile.txt").Substring(6);
            StreamReader filename = new StreamReader(inputfile);
            List<string> ListResults = new List<string>();
            List<string> ListDriver = new List<string>();
            List<string> ListSorted = new List<string>();
            while ((line = filename.ReadLine()) != null)
            {
                ListBoxOriginal.Items.Add(line);
                string[] arr = line.Split(' ');
                if (arr[0].Equals("Driver")) ListDriver.Add(arr[1]);
                if (arr[0].Equals("Trip"))
                {
                    startTime = DateTime.Parse(arr[2]);
                    endTime = DateTime.Parse(arr[3]);
                    totalHour = endTime.Subtract(startTime);
                    if (ListResults.Count > 0)
                    {
                        cnt = 0;modify = false;
                        foreach (string Item in ListResults)
                        {
                            arr2 = Item.Split(' ');
                            if (Item.Contains(arr[1]))
                            {
                                modify = true; index = cnt;
                                totalMiles = double.Parse(arr2[1]) + double.Parse(arr[4]);
                                totalTime = totalHour.TotalHours + double.Parse(arr2[6]);
                                averageSpeed = totalMiles / totalTime;
                                arr2[1] = totalMiles.ToString();
                                arr2[4] = averageSpeed.ToString();
                                arr2[6] = totalTime.ToString();
                            }
                            cnt++;
                        }
                        if (modify)
                        {
                            ListResults[index] = string.Join(" ", arr2);
                            Array.Clear(arr2, 0, arr2.Length);
                        }
                            
                    }
                    if (!modify)
                    {
                        totalMiles = double.Parse(arr[4]);
                        totalTime = totalHour.TotalHours;
                        averageSpeed = totalMiles / totalTime;
                        resultSpeed = averageSpeed.ToString();
                        resultMiles = totalMiles.ToString();
                        stringResults = string.Concat(arr[1], ": ", resultMiles, " miles @ ", resultSpeed, " mph ", totalTime.ToString());
                        ListResults.Add(stringResults);
                    }
                }
            }
            for (int index1 = 0; index1 < ListResults.Count - 1; index1++)
            {
                for (int index2 = 0; index2 < ListDriver.Count - 1; index2++)
                {
                    if (!ListResults[index1].Contains(ListDriver[index2]))
                    {
                        found = false;
                        location = index2 + 1;
                    }
                }
            }
            if (!found) ListResults.Add(ListDriver[location] + ": 0 miles");
            ListSorted = ListResults.OrderBy(r => (int)(r[1])).ToList();
            foreach (string Item in ListSorted)
            {
                string[] arr = Item.Split(' ');
                if (!arr[1].Contains("0"))
                {
                    arr[6] = string.Empty;
                    result = (int)Math.Round(double.Parse(arr[1]));
                    arr[1] = result.ToString();
                    result = (int)Math.Round(double.Parse(arr[4]));
                    arr[4] = result.ToString();
                    newItem = string.Join(" ", arr);
                    ListBoxResults.Items.Add(newItem);
                }
                else ListBoxResults.Items.Add(Item);
            }
        }
    }
}