using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquidTransform
{
    public class TransformOptions
    {
        public string Templatefile
        { get; set; }
        public string Contentfile
        { get; set; }
        public string Destinationfile
        { get; set; }
        public string Rootelement
        { get; set; }
        public bool RubyNamingConvention { get; set; }
        public bool HelpRequested { get; set; }

        public bool Validate()
        {
            if (System.String.IsNullOrWhiteSpace(Templatefile) || File.Exists(Templatefile) == false)
            {
                Console.WriteLine("Template file: '{0}' doesn't exist.", Templatefile);
                return false;
            }
            if (System.String.IsNullOrWhiteSpace(Contentfile) || File.Exists(Contentfile) == false)
            {
                Console.WriteLine("Content file: '{0}' doesn't exist.", Contentfile);
                return false;
            }

            if (System.String.IsNullOrWhiteSpace(Destinationfile) || Directory.Exists( Path.GetDirectoryName(Destinationfile)) == false )
            {
                Console.WriteLine("Directory: '{0}' doesn't exist.", Path.GetDirectoryName(Destinationfile));
                return false;
            }
            return true;
        }
    }
}
