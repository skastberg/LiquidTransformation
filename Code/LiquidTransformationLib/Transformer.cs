using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquidTransformationLib
{
    public class Transformer
    {
        public readonly string Template;
        public readonly bool UseRubyNamingConvention;
        public readonly DotLiquid.Template LiquidTemplate;
        public static Transformer GetTransformerFromFile(string filename, bool useRubyNamingConvention = false)
        {
            string template = File.ReadAllText(filename);
            return new Transformer(template, useRubyNamingConvention);
        }
        public Transformer(string template, bool useRubyNamingConvention = false)
        {
            Template = template;
            UseRubyNamingConvention = useRubyNamingConvention; 
            if(!useRubyNamingConvention)
            {
                DotLiquid.Template.NamingConvention = new DotLiquid.NamingConventions.CSharpNamingConvention();
            }
            LiquidTemplate = DotLiquid.Template.Parse(template);

        }


        public string RenderFromString(string content, string rootElement = null)
        {
            Dictionary<string, object> dicContent;
            JsonSerializerSettings sets = new JsonSerializerSettings
            {
                CheckAdditionalContent = true,
                MaxDepth = null
            };
            var jo = JObject.Parse(content);
            var dic = jo.ToDictionary();

            if (rootElement is null)
            {
                dicContent = (Dictionary<string, object>)dic;
            }
            else
            {
                dicContent = new Dictionary<string, object>
            {
                { rootElement, dic }
            };
            }
            var obj = DotLiquid.Hash.FromDictionary(dicContent);
            return LiquidTemplate.Render(obj);
        }

        public string RenderFromFile(string filename, string rootElement = null)
        {
            string content = System.IO.File.ReadAllText(filename);
            return RenderFromString(content,rootElement);
        }

    }
}
