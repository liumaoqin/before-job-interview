using System;

namespace Event
{
    public delegate void EventHandler2(object sender,EventArgs e);
    class Program
    {
        static void Main(string[] args)
        {
            var e = new EventTest(5);
            e.SetValue(10);
            e.ChangeNum += 
                new EventTest.NumMainipulationHandler(EventTest.EventFired);
            e.SetValue(100);

            Console.WriteLine("------------------------");
            I i = new MyClass();
            i.MyEvent += new MyDelegate(f);
            i.FireAway();

            Console.ReadLine();
        }
        public static void f()
        {
            Console.WriteLine("This is called when the event fired");
        }
    }
    class EventTest
    {
        private int value;
        public delegate void NumMainipulationHandler();
        //那一种的Delegate可以绑定到Event上
        public event NumMainipulationHandler ChangeNum;
        //规定Delegate的范围(Delegate也可以实现Event的所有功能)
        //但是Delegate限制的是Method,Event限制的是Delegate
        //Button.Click为EventHanlder类型的Event
        public EventTest(int n)
        {
            SetValue(n);
        }
        public static void EventFired()
        {
            Console.WriteLine("Binded event fired");
        }
        public virtual void OnNumChanged()
        {
            if (ChangeNum != null)
            {
                ChangeNum();
            }
            else
            {
                Console.WriteLine("Event Fired");
            }
        }
        public void SetValue(int n)
        {
            if (value != n)
            {
                value = n;
                OnNumChanged();
            }
        }
    }

    public delegate void MyDelegate();
    public interface I
    {
        event MyDelegate MyEvent;
        event EventHandler MyGuidlineEvent;//sender,EventArgs
        void FireAway();
    }
    public class MyClass : I
    {
        public event MyDelegate MyEvent;
        public void FireAway()
        {
            if(MyEvent != null)
            {
                MyEvent();
            }
        }
    }
}
