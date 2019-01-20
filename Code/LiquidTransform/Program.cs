using Microsoft.Extensions.CommandLineUtils;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquidTransform
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = GetOptions(args);
            if (options.HelpRequested == true || options.Validate() == false)
            { return; }

            var transformer = LiquidTransformationLib.Transformer.GetTransformerFromFile(options.Templatefile, options.RubyNamingConvention);
            var transformedString = transformer.RenderFromFile(options.Contentfile, options.Rootelement);

            var tw = File.CreateText(options.Destinationfile);
            tw.WriteLine(transformedString);
            tw.Flush();
            tw.Close();
        }

        private static TransformOptions GetOptions(string[] args)
        {

            CommandLineApplication cmd = new CommandLineApplication();
            var argTemplate = cmd.Option("-t | --template=<value>", "Liquid template. Required", CommandOptionType.SingleValue);
            var argContent = cmd.Option("-c | --content=<value>", "Full path to Content file. Required", CommandOptionType.SingleValue);
            var argDestination = cmd.Option("-d | --destination=<value>", "Full path to destination file. Required", CommandOptionType.SingleValue);
            var argRootelement = cmd.Option("-r | --rootelement=<value>", "Root element to add before render. Optional", CommandOptionType.SingleValue);
            var argUseRuby = cmd.Option("-u | --rubynaming", "Use RubyNamingConvention. Optional", CommandOptionType.NoValue);


            cmd.HelpOption("-? | -h | --help");
            try
            {
                int result = cmd.Execute(args);
            }
            catch (Microsoft.Extensions.CommandLineUtils.CommandParsingException ex)
            {
                Console.WriteLine(ex.Message);
                return new TransformOptions() { HelpRequested = true };
            }
            
            if (cmd.IsShowingInformation == true)
            {
                return new TransformOptions() { HelpRequested = true };
            }
            if (argTemplate.Values.Count == 0 || argContent.Values.Count == 0 || argDestination.Values.Count == 0)
            {
                Console.WriteLine(cmd.GetHelpText());
                return new TransformOptions() { HelpRequested = true };
            }
            var to = new TransformOptions() { Templatefile = argTemplate.Value()
                                            , Contentfile = argContent.Value()
                                            , Destinationfile = argDestination.Value()
                                            , RubyNamingConvention = (argUseRuby.Value() == "on")
                                            , Rootelement = argRootelement.Value()
                                            , HelpRequested = false };
            return to;
        }
    }
}
