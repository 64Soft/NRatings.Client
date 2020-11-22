using System;
using System.Collections.Generic;
using System.IO;

namespace NRatings.Client.Domain.Collections
{
    public class RatingsFormulaCollection : List<RatingsFormula>
    {
        private static string embeddedFormulasPath = UserSettingsManager.GetApplicationPath() + @"\EmbeddedFormulas";

        public static string EmbeddedFormulasPath
        {
            get { return embeddedFormulasPath; }
        }

        public static string MyFormulasPath
        {
            get { return UserSettingsManager.GetMyFormulasPath(); }
        }

        public static RatingsFormulaCollection GetFormulas()
        {
            RatingsFormulaCollection formulas = new RatingsFormulaCollection();

            if (Directory.Exists(EmbeddedFormulasPath))
            {
                string[] files = Directory.GetFiles(EmbeddedFormulasPath, "*.xml");

                foreach (string file in files)
                {
                    try
                    {
                        RatingsFormula r = RatingsFormula.ReadFromFile(file);

                        if (r != null)
                        {

                            string fileName = file;
                            try
                            {
                                fileName = file.Substring(file.LastIndexOf(@"\") + 1);
                            }
                            catch { }
                            
            
                            r.FileName = fileName;
                            formulas.Add(r);
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("Error while reading formula " + file + ": " + ex.ToString());
                    }
                }

            }

            //user formulas
            if (Directory.Exists(MyFormulasPath))
            {
                string[] files = Directory.GetFiles(MyFormulasPath, "*.xml");

                foreach (string file in files)
                {
                    try
                    {
                        RatingsFormula r = RatingsFormula.ReadFromFile(file);

                        if (r != null)
                        {

                            string fileName = file;
                            try
                            {
                                fileName = file.Substring(file.LastIndexOf(@"\") + 1);
                            }
                            catch { }

                            r.FileName = fileName;
                            formulas.Add(r);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error while reading formula " + file + ": " + ex.ToString());
                    }
                }

            }

            return formulas;
        }
    }
}
