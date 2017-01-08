using System;

namespace CreateAttribute
{
    class Program
    {
        static void Main(string[] args)
        {
            HelpAttribute helpAttribute;
            foreach(var attr in typeof(AnyClass).GetCustomAttributes(true))
            {
                helpAttribute = attr as HelpAttribute;
                if(helpAttribute != null)
                {
                    Console.WriteLine("AnyClass Description:{0}",
                        helpAttribute.Description);
                }
            }
            Console.ReadLine();
        }
    }
    //AttributeUsage这个Attribute的使用范围
    [AttributeUsage(AttributeTargets.Class,AllowMultiple=false,Inherited=false)]
    //AllowMultiple 是否可以放置多个
    //Inherited 继承的类是否继承该Attribute
    public class HelpAttribute:Attribute
    {
        protected string description;
        public HelpAttribute(string _description)
        {
            this.description = _description;
        }
        public string Description
        {
            get 
            {
                return this.description;
            }
        }
        public string Name
        {
            get;
            set;
        }
    }
    //value type, System.Type, object, enum,
    [Help("this is a do-nothing class",Name="zilong")]
    public class AnyClass
    { }
}
