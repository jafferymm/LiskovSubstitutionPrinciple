using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutionPrinciple
{
    public class Rectangle 
    {
        //add virtual
        public int Width { get; set; }
        //add virtual
        public int Height { get; set; }

        public Rectangle()
        {
        }
        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }
        public override string ToString()
        {
            return $"{nameof(Width)}:{Width}, {nameof(Height)}:{Height}";
        }
    }

    //square is a rectangle relationship
    public class Square : Rectangle
    {
        //replace new with virtual 
        public new int Width
        {
            set { base.Width = base.Height = value; }
        }

        //replace new with virtual 
        public new int Height
        {
            set { base.Height = base.Width = value; }
        }

    }
    class Program
    {
        static public int Area(Rectangle r) => r.Width * r.Height;
        static void Main(string[] args)
        {
            Rectangle rc = new Rectangle(2,3);
            Console.WriteLine($"{rc} has area {Area(rc)}");

            Square sq = new Square();
            sq.Width = 4;
            Console.WriteLine($"{sq} has area {Area(sq)}");


            //violation of Liskov Substitution principle 
            Rectangle sq2 = new Square();
            sq2.Width = 2;
            //height and area is 0
            Console.WriteLine($"{sq2} has area {Area(sq2)}");
            
            //To fix, make the properties of Rectangle Virtual, and properties of Square Override instead of New


            Console.ReadLine();

        }
    }
}
