using Microsoft.VisualBasic.CompilerServices;
using System.Drawing;
using System.Diagnostics;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Globalization;
using System;

namespace InterviewProject.DataHelper
{
    public class DateTimeTransformer
    {
        /// <summary>
        ///     Calculated date and time, based on the given template value
        /// </summary>
        /// <param name="points">start and end date and time of a specific tripitem</param>
        /// <param name="templateValue">contains the definition for calculation i.e. 'first', 'last', 'first-(minutes)', 'first+(minutes)', 'last+(minutes)' or 'last-(minutes)'</param>
        /// <returns>Returns the calculated date and time</returns>
        public static DateTimeOffset? CalculateToRightDateTime(PointDate points, string templateValue)
        {          
            try
            {    
                if(!(points.DateTimeEnd == null && points.DateTimeStart == null))
                {               
                    if (!(string.IsNullOrEmpty(templateValue)))
                    {
                        // date_push_notification store date & time when a push should be sent
                        DateTimeOffset? date_push_notification = new DateTimeOffset?();                     

                        string first_or_last = Verify_If_Last_Or_First(templateValue);                  

                        switch(first_or_last)
                        {                      
                            case "last":                        
                                if(Verify_Template_Value_Has_Numbers(templateValue))                             
                                {
                                    int numbers = Convert.ToInt16(getNumbers(templateValue));                                                               
                                
                                    date_push_notification = points.DateTimeEnd.Value.AddMinutes(numbers);                                                                                                                                                                                                                                                 
                                }
                                else
                                {
                                    date_push_notification = points.DateTimeEnd;                                                              
                                }
                                return date_push_notification; 
                                                                                                                     
                            case "first":
                                if(Verify_Template_Value_Has_Numbers(templateValue))
                                {
                                    int numbers = Convert.ToInt16(getNumbers(templateValue));       

                                    date_push_notification = points.DateTimeStart.Value.AddMinutes(numbers);                                                            
                                }
                                else
                                {
                                    date_push_notification = (points.DateTimeStart);                              
                                }
                                return date_push_notification; 

                            default:
                                return null; 
                        }                                                                                                                          
                    }   
                    else return null;  
                }
                else throw new NotImplementedException("Error There is no Date Available!");                                                                                                           
            }
            catch (Exception)
            {
                // Implement business logic here
                throw new NotImplementedException("Error Data!");
            }                  
        }  

        // Verify if templateValue has Last & First and convert to LowerCase 
        public static string Verify_If_Last_Or_First(string templateValue)
        {
            string first_or_last = Regex.Replace(templateValue, @"[^A-Za-z]+", String.Empty);
            return first_or_last.ToLower();
        }

        // Verify if TemplateValues has numbers
        public static bool Verify_Template_Value_Has_Numbers(string templateValue)
        {          
            bool containsNum = System.Text.RegularExpressions.Regex.IsMatch(templateValue, @"\d");
            return containsNum;
        }

        // Get Numbers from TemplateValue
        public static string getNumbers(string templateValue)
        {
            string getNum = Regex.Match(templateValue, @"\-*\d+").Value;
            return getNum;
        }            
    }
}
