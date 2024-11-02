using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.IO;
//Abderahman Haouit ,19404086
//MacOS ,VScode

namespace assignment_04_19404086
{      class Program
    {
        static void Main(string[] args)
        {
            bool showTheMenu = true;   // menu control
            // around the menu item functions
            Canvas canvas = new Canvas();
            Originator originator = new Originator();
            Caretaker caretaker = new Caretaker();
            originator.setState(canvas);
            caretaker.add(originator.createMemento());
            //Main terminal menu each time the new terminal executes
            Console.WriteLine("***********************");
            Console.WriteLine("SVG CANVAS Created\n");
            Console.WriteLine("Abderahman Haouit, 19404086");
            Console.WriteLine("***********************\n");
            //Dispaly the menu contents
            message();
            //UNTIL INPUT SATISFIED KEEP PROOMTING FOR CORRECT INPUT WITH THE MENU
            while (showTheMenu)
            {
                showTheMenu = MainMenu(canvas,originator,caretaker);
            }
            Console.Clear();// Clear terminal for tidiness 
        }
        //
        // This section contains the application MENU
        //
        static void message()
            {
            Console.Write("\rCommands: \n");
            Console.WriteLine("H: Help - displays this message");
            Console.WriteLine("A: <Shape> Add <shape to canvas");
            Console.WriteLine("U: Undo last operation");
            Console.WriteLine("R: Redo last operation");
            Console.WriteLine("C: Clear canvas");
            Console.WriteLine("S: Save in the 'shape2.svg' file");
            Console.WriteLine("D: Dispaly canvas to the console");
            Console.WriteLine("Q: Quit application \n");
            }
        //
        // This section contains the application CASES
        //
        public static bool MainMenu(Canvas canvas,Originator originator,Caretaker caretaker)
        {
            string input;
            Console.Write("> ");
            switch (Console.ReadKey().KeyChar)
            {
                case 'H':
                    message();                           //printing out the message method
                    return true;
                case 'A': 
                    input = Console.ReadLine();         //Read the shape entered by the user
                    checkShape(input,canvas,originator,caretaker);          //put the shape and canvas in method
                    return true;
                case 'U':
                    Console.WriteLine("\n"+"Undoing, in svg format!");
                    originator.setState(caretaker.get(caretaker.ShowHistory()).getState());
                    canvas = new Canvas(originator.getState());
                    canvas.DisplayCanvas1();
                    originator.setState(canvas);
                    caretaker.add(originator.createMemento());
                    return true;
                case 'R':
                    Console.WriteLine("\n"+"Redoing, in svg format!");
                    originator.setState(caretaker.get(caretaker.ShowHistory1()).getState());
                    canvas = new Canvas(originator.getState());
                    canvas.DisplayCanvas1();
                    originator.setState(canvas);
                    caretaker.add(originator.createMemento());
                    return true;    
                case 'C':
                    clear(canvas);                //putting canvas into the delete shape method
                    MenuItemClear();             //promting user to enter space bar to continu                            
                    message();                  //printing out the message method
                    return true;   
                case 'S':                 
                    DisplayCanvas(canvas);   //putting canvas into the display method
                    return true;            //This will exit terminal and run new T as we are finished with canvas (created)
                case 'D':
                    DisplayCanvas1(canvas);     //putting canvas into the display1 method
                    return true;  
                case 'Q':
                case 'q':
                    return false;
                default:
                    Console.Clear();
                    Console.WriteLine("Please Enter one of the command keys!\n");//if input is not met keep prompting for correct input
                    message();
                return true;
            }
        }
        //
        // This section contains the menu item functions
        //
        private static void MenuItemClear()
        {
            // menu header output
            do{
                Console.WriteLine("\nPlease enter Space Bar to Continue !");
            }while(Console.ReadKey(true).Key != ConsoleKey.Spacebar); 
        }
        public static void checkShape(string input, Canvas canvas,Originator originator,Caretaker caretaker)
    {
        if(input==" circle"){
            CreateRandomCircle(canvas); 
            originator.setState(canvas);
            caretaker.add(originator.createMemento());
        }
        else if(input==" rectangle"){
            CreateRandomRectangle(canvas);
            originator.setState(canvas);
            caretaker.add(originator.createMemento());
        }
        else if(input==" ellipse"){
            CreateRandomEllipse(canvas); 
            originator.setState(canvas);
            caretaker.add(originator.createMemento());
        }
        else if(input==" line"){
            CreateRandomLine(canvas); 
            originator.setState(canvas);
            caretaker.add(originator.createMemento());
        }
        else if(input==" polyline"){
            CreateRandomPolyLine(canvas); 
            originator.setState(canvas);
            caretaker.add(originator.createMemento());
        }
        else if(input==" polygon"){
            CreateRandomPolygon(canvas);
            originator.setState(canvas);
            caretaker.add(originator.createMemento());
        }
        else if(input==" path"){
            CreateRandomPath(canvas);
            originator.setState(canvas);
            caretaker.add(originator.createMemento());
        }
        else{
            Console.WriteLine("\nPlease enter a shape example from assingment 2!");
            message();
        }
    }    
        private static void CreateRandomCircle(Canvas canvas) 
        {
            // menu header output
            // create the random circle
            Random rnd = new Random(); // random number generator
            int rnd1=rnd.Next(100, 200);
            int rnd2=rnd.Next(100, 200);
            int rnd3=rnd.Next(100, 200);

            Circle c = new Circle("C"+rnd.Next(1, 50),rnd1, rnd2, rnd3);
            Console.WriteLine("Circle (R="+rnd1+",X="+rnd2+",Y="+rnd3+") added to canvas.");
            // add the circle to the canvas - at the end of the list
            canvas.Add(c);
            // write the circle details
        }
        private static void CreateRandomRectangle(Canvas canvas)
        {
            // create the random Rectangle
            Random rnd = new Random(); // random number generator
            int rnd1=rnd.Next(100, 200);
            int rnd2=rnd.Next(100, 200);
            int rnd3=rnd.Next(1, 100);
            int rnd4=rnd.Next(1, 100);

            Rectangle r = new Rectangle("R"+rnd.Next(1, 50),rnd1, rnd2, rnd3, rnd4);
            //Print to user what they created
            Console.WriteLine("Rectangle (X="+rnd1+",Y="+rnd2+",Width="+rnd3+",Height="+rnd4+") added to canvas.");
            // add the Rectangle to the canvas - at the end of the list
            canvas.Add(r);
        }

        private static void CreateRandomEllipse(Canvas canvas)
        {
            // create the random Ellipse
            Random rnd = new Random(); // random number generator
            int rnd1=rnd.Next(100, 200);
            int rnd2=rnd.Next(100, 200);
            int rnd3=rnd.Next(1, 100);
            int rnd4=rnd.Next(1, 100);

            Ellipse e = new Ellipse("E"+rnd.Next(1, 50),rnd1, rnd2, rnd3, rnd4);
            //Print to user what they created
            Console.WriteLine("Ellipse (XR="+rnd1+",YR="+rnd2+",CX="+rnd3+",CY="+rnd4+") added to canvas.");
            // add the Ellipse to the canvas - at the end of the list
            canvas.Add(e);
        }
        private static void CreateRandomLine(Canvas canvas)
        {
            // create the random Line
            Random rnd = new Random(); // random number generator
            int rnd1=rnd.Next(100, 200);
            int rnd2=rnd.Next(100, 200);
            int rnd3=rnd.Next(1, 100);
            int rnd4=rnd.Next(1, 100);

            Line l = new Line("L"+rnd.Next(1, 50),rnd1, rnd2, rnd3, rnd4);
            //Print to user what they created
            Console.WriteLine("Line (X1="+rnd1+",Y1="+rnd2+",X2="+rnd3+",Y2="+rnd4+") added to canvas.");
            // add the Line to the canvas - at the end of the list
            canvas.Add(l);
        }
        private static void CreateRandomPolyLine(Canvas canvas)
        {
            // create the random PolyLine
            Random rnd = new Random(); // random number generator
            int rnd1=rnd.Next(1, 100),rnd2=rnd.Next(100, 200),rnd3=rnd.Next(1, 100),rnd4=rnd.Next(100, 200),rnd5=rnd.Next(1, 100),
                rnd6=rnd.Next(100, 200),rnd7=rnd.Next(1, 100),rnd8=rnd.Next(100, 200),rnd9=rnd.Next(1, 100),rnd10=rnd.Next(100, 200),rnd11=rnd.Next(1, 100),rnd12=rnd.Next(100, 200),
                rnd13=rnd.Next(1, 100),rnd14=rnd.Next(100, 200),rnd15=rnd.Next(1, 100),rnd16=rnd.Next(100, 200),rnd17=rnd.Next(1, 100),rnd18=rnd.Next(100, 200);

            PolyLine p = new PolyLine("P"+rnd.Next(1, 50),rnd1+" "+rnd2+" "+rnd3+" "+rnd4+" "+rnd5+" "+rnd6+" "+rnd7+" "+rnd8+" "+rnd9+" "+rnd10+" "+rnd11+" "+rnd12+" "+rnd13+" "+rnd14+" "+rnd15+" "+rnd16+" "+rnd17+" "+rnd18+" ");
            //Print to user what they created
            Console.WriteLine("Polyline (Points "+rnd1+","+rnd2+","+rnd3+","+rnd4+","+rnd5+","+rnd6+","+rnd7+","+rnd8+","+rnd9+","+rnd10+","+rnd11+","+rnd12+","+rnd13+","+rnd14+","+rnd15+","+rnd16+rnd17+","+rnd18+") added to canvas.");
            // add the PolyLine to the canvas - at the end of the list
            canvas.Add(p);
        }
        private static void CreateRandomPolygon(Canvas canvas)
        {
            // create the random Polygon
            Random rnd = new Random(); // random number generator
            int rnd1=rnd.Next(1, 100),rnd2=rnd.Next(100, 200),rnd3=rnd.Next(1, 100),rnd4=rnd.Next(100, 200),rnd5=rnd.Next(1, 100),
                rnd6=rnd.Next(100, 200),rnd7=rnd.Next(1, 100),rnd8=rnd.Next(100, 200),rnd9=rnd.Next(1, 100),rnd10=rnd.Next(100, 200),rnd11=rnd.Next(1, 100),rnd12=rnd.Next(100, 200),
                rnd13=rnd.Next(1, 100),rnd14=rnd.Next(100, 200),rnd15=rnd.Next(1, 100),rnd16=rnd.Next(100, 200),rnd17=rnd.Next(1, 100),rnd18=rnd.Next(100, 200),
                rnd19=rnd.Next(1, 100),rnd20=rnd.Next(100, 200);

            Polygon pg = new Polygon("PG"+rnd.Next(1, 50),rnd1+" "+rnd2+" "+rnd3+" "+rnd4+" "+rnd5+" "+rnd6+" "+rnd7+" "+rnd8+" "+rnd9+" "+rnd10+" "+rnd11+" "+rnd12+" "+rnd13+" "+rnd14+" "+rnd15+" "+rnd16+" "+rnd17+" "+rnd18+" "+rnd19+" "+rnd20+" ");
            //Print to user what they created
            Console.WriteLine("Polygon (Points "+rnd1+","+rnd2+","+rnd3+","+rnd4+","+rnd5+","+rnd6+","+rnd7+","+rnd8+","+rnd9+","+rnd10+","+rnd11+","+rnd12+","+rnd13+","+rnd14+","+rnd15+","+rnd16+","+rnd17+","+rnd18+","+rnd19+","+rnd20+") added to canvas.");
            // add the Polygon to the canvas - at the end of the list
            canvas.Add(pg);
        }
        private static void CreateRandomPath(Canvas canvas)
        {
            // create the random Path
            Random rnd = new Random(); // random number generator
            int rnd1=rnd.Next(1, 100),rnd2=rnd.Next(200, 250),rnd3=rnd.Next(1, 100),rnd4=rnd.Next(200, 250),rnd5=rnd.Next(1, 100),
                rnd6=rnd.Next(200, 250),rnd7=rnd.Next(1, 100),rnd8=rnd.Next(200, 250);

            Path pt = new Path("Path"+rnd.Next(1, 50),"M"+rnd1+","+rnd2+" "+"Q"+rnd3+","+rnd4+" "+rnd5+","+rnd6+" "+"T"+rnd7+","+rnd8);
            //Print to user what they created
            Console.WriteLine("Path (Points "+"M"+rnd1+","+rnd2+" "+"Q"+rnd3+","+rnd4+" "+rnd5+","+rnd6+" "+"T"+rnd7+","+rnd8+") added to canvas.");
            //add the Polygon to the canvas - at the end of the list
            canvas.Add(pt);
        }
        private static void DisplayCanvas(Canvas canvas)
        {
            // menu header output
            Console.WriteLine("\nDrawing Canvas (as SVG), check the 'shape2.svg' file");
            canvas.DisplayCanvas();
        }
        private static void DisplayCanvas1(Canvas canvas)
        {
            // menu header output 
            Console.WriteLine("\nDrawing Canvas (as SVG), in the Console\n");
            canvas.DisplayCanvas1();
        }
        private static void clear(Canvas canvas)
        {
            // menu header output 
            Console.WriteLine("\nCleared the Canvas!");
            canvas.clear();
        }    
        //
        // This section contains the classes used by the application
        // to create canvas, shapes, etc.
        //
        public class Canvas
        {
            public List<Shape> canvas = new List<Shape>(); // using list to store shapes
            
            public Canvas(Canvas other) { 
            foreach (var shape in other.canvas){
                canvas.Add(shape);
            }
        }
            public void Add(Shape shape)
            {
                canvas.Add(shape);
            }

            public Canvas () { }
            public void DisplayCanvas () {
                // create the opening and closing tags for the svg canvas
                string svgOpen = @"<svg height=""500"" width=""500"" xmlns=""http://www.w3.org/2000/svg"">";
                string svgClose = @"</svg>";
                //draw the canvas (write to the display)
                string svg = @"./shape2.svg";
                using (StreamWriter sw = File.CreateText(svg))
                {
                    sw.WriteLine("\n"+svgOpen);
                    foreach (var shape in canvas) sw.WriteLine("".PadLeft(3, ' ') + shape.ToSVGElement());
                    sw.WriteLine(svgClose+"\n");
                }
            }
            public void DisplayCanvas1 () {
                // create the opening and closing tags for the svg canvas
                string svgOpen = @"<svg height=""500"" width=""500"" xmlns=""http://www.w3.org/2000/svg"">";
                string svgClose = @"./shape2.svg";

                // draw the canvas (write to the display)
                Console.WriteLine("\n"+svgOpen);
                // iterate over all circles in the list
                foreach (var shape in canvas) Console.WriteLine("".PadLeft(3, ' ') + shape.ToSVGElement());
                Console.WriteLine(svgClose+"\n");
            }
            public void clear() 
            {
                canvas.Clear();//Clears all the shapes in the canvas
            }
        } 
        public abstract class Shape{
            public string ID { get; set; }            // shapes have an ID
            public abstract string ToSVGElement();    // shapes must implement to SVG method
        }
        public class Circle : Shape
        {
            public int X { get; set; }        // circle centre x-coordinate
            public int Y { get; set; }        // circle centre y-coordinate
            public int R { get; set; }        // circle radius

            public Circle() { ID="C100"; X = 100; Y = 100; R = 100; }
            public Circle(string id, int x, int y, int r) { ID = id; X = x; Y = y; R = r; }

            public override string ToString()
            {
                // convert the Object to a string
                string dispXYR = String.Format("Circle ({3}) at ({0},{1}) R={2}.", X, Y, R, ID);
                // return the convered string
                return dispXYR;
            }

            public override string ToSVGElement()
            {
                // convert the object to an SVG element descriptor string for circle
                string dispSVG = String.Format(@"<circle id=""{3}"" cx=""{0}"" cy=""{1}"" r=""{2}"" stroke=""black"" stroke-width=""5"" fill=""yellow"" />", X, Y, R, ID);
                return dispSVG;
            }
        }
        public class Rectangle : Shape
        {
            public int X { get; set; }        // Rectangle centre x-coordinate
            public int Y { get; set; }        // Rectangle centre y-coordinate
            public int W { get; set; }        // Rectangle width
            public int H { get; set; }        // Rectangle height

            public Rectangle() { ID="R100"; X = 100; Y = 100; W = 100; H = 100;}

            public Rectangle(string id, int x, int y, int w, int h) { ID = id; X = x; Y = y; W = w; H = h;}

            public override string ToString()
            {
                // convert the Object to a string
                string dispXYR = String.Format("Rectangle ({4}) at ({0},{0}) W={1} H={1}.", X, Y, W, H, ID);
                // return the convered string
                return dispXYR;
            }
            public override string ToSVGElement()
            {
                // convert the object to an SVG element descriptor string for circle
                string dispSVG = String.Format(@"<rect id=""{4}"" x=""{0}"" y=""{0}"" width=""{1}"" height=""{1}"" stroke=""black"" stroke-width=""5"" fill=""purple"" />", X, Y, W, H, ID);
                return dispSVG;
            }

        }
        public class Ellipse : Shape
        {
            public int X { get; set; }        // Ellipse centre x-coordinate
            public int Y { get; set; }        // Ellipse centre y-coordinate
            public int RX { get; set; }       // Ellipse radius x
            public int RY { get; set; }       // Ellipse radius y

            public Ellipse() { ID="E100"; X = 100; Y = 100; RX = 100; RY = 100;}

            public Ellipse(string id, int x, int y, int rx, int ry) { ID = id; X = x; Y = y; RX = rx; RY = ry;}

            public override string ToString()
            {
                // convert the Object to a string
                string dispXYR = String.Format("Ellipse ({4}) at ({0},{0}) RX={2} RY={1}.", X, Y, RX, RY, ID);
                // return the convered string
                return dispXYR;
            }
            public override string ToSVGElement()
            {
                // convert the object to an SVG element descriptor string for circle
                string dispSVG = String.Format(@"<ellipse id=""{4}"" cx=""{0}"" cy=""{0}"" rx=""{2}"" ry=""{1}"" stroke=""black"" stroke-width=""5"" fill=""red"" />", X, Y, RX, RY, ID);
                return dispSVG;
            }
        }

        public class Line : Shape
        {
            public int X1 { get; set; }        // Line centre x1-coordinate
            public int Y1 { get; set; }        // Line centre y1-coordinate
            public int X2 { get; set; }        // Line  x2-coordinate
            public int Y2 { get; set; }        // Line  y2-coordinate

            public Line() { ID="L100"; X1 = 100; Y1 = 100; X2 = 100; Y2 = 100;}
            public Line(string id, int x1, int y1, int x2, int y2) { ID = id; X1 = x1; Y1 = y1; X2 = x2; Y2 = y2;}

            public override string ToString()
            {
                // convert the Object to a string
                string dispXYR = String.Format("Line ({4}) at ({0},{1}) X2={2} Y2={3}.", X1, Y1, X2, Y2, ID);
                // return the convered string
                return dispXYR;
            }
            public override string ToSVGElement()
            {
                // convert the object to an SVG element descriptor string for circle
                string dispSVG = String.Format(@"<line id=""{4}"" x1=""{0}"" y1=""{1}"" x2=""{2}"" y2=""{3}"" stroke=""black"" stroke-width=""5"" fill=""orange"" />", X1, Y1, X2, Y2, ID);
                return dispSVG;
            }
        }

        public class PolyLine : Shape
        {
            public string P {get; set;} //String P(points) for the polyline

            public PolyLine() { ID="P100"; P = "60 110 65 120 70 115 75 130 80 125 85 140 90 135 95 150 100 145";}
            public PolyLine(string id, string p) { ID = id; P = p;}

            public override string ToString()
            {
                // convert the Object to a string
                string dispXYR = String.Format("PolyLine ({1}) at ({0}).", P, ID);
                // return the convered string
                return dispXYR;
            }
            public override string ToSVGElement()
            {
                // convert the object to an SVG element descriptor string for circle
                string dispSVG = String.Format(@"<polyline id=""{1}"" points=""{0}"" stroke=""green"" stroke-width=""5"" fill=""none"" />", P, ID);
                return dispSVG; 
            }    
        }
         public class Polygon : Shape
        {
            public string PG {get; set;}    //String PG(points) for the polygon

            public Polygon() { ID="PG100"; PG = "50 160 55 180 70 180 60 190 65 205 50 195 35 205 40 190 30 180 45 180";}
            public Polygon(string id, string pg) { ID = id; PG = pg;}

            public override string ToString()
            {
                // convert the Object to a string
                string dispXYR = String.Format("Polygon ({1}) at ({0})", PG, ID);
                // return the convered string
                return dispXYR;
            }
            public override string ToSVGElement()
            {
                // convert the object to an SVG element descriptor string for circle
                string dispSVG = String.Format(@"<polygon id=""{1}"" points=""{0}"" stroke=""black"" stroke-width=""5"" fill=""blue"" />", PG, ID);
                return dispSVG; 
            }    
        }
         public class Path : Shape
        {
            public string PT {get; set;}    //String Path(points) for the Path

            public Path() { ID="PT100"; PT = "M20,230 Q40,205 50,230 T90,230";}

            public Path(string id, string pt) { ID = id; PT = pt;}

            public override string ToString()
            {
                // convert the Object to a string
                string dispXYR = String.Format("Path ({1}) at ({0})", PT, ID);
                // return the convered string
                return dispXYR;
            }
            public override string ToSVGElement()
            {
                // convert the object to an SVG element descriptor string for circle
                string dispSVG = String.Format(@"<path id=""{1}"" d=""{0}"" stroke=""brown"" stroke-width=""5"" fill=""none"" />", PT, ID);
                return dispSVG; 
            }    
        }
        
    // Memento Design Pattern Implementation

    //
    // Memento Class
    //
    // This class represents a snapshot and contains the state of an object to be restored to an
    // Originator. It provides get and set state member functions for accessing and setting the 
    // state encapsulated by the Memento object. Note that the setState could just be the constructor!
    // We could have other methods also; perhaps to get some information about the memento! We have
    // specified an interface, IMemento) and the concrete Memento class uses this as a base. 
    //
    public interface IMemento
    {
        public Canvas getState();
        public void setState(Canvas state);
    }

    public class Memento : IMemento
    {
        private Canvas state;
        public Memento(Canvas state)
        {
            this.state = state;
        }

        public Canvas getState()
        {
            return state;
        }
        public void setState(Canvas state)
        {
            this.state = state;
        }
    }
    //
    // Originator Class
    //
    // This is the class which holds the current state. It has a member function that creates and returns
    // a Memento object with the current state of the Originator stored in the returned Memento. It also has a 
    // member function that replaces its current state (snapshot) with the state of a given Memento object
    // (some other snapshot). 
    //

    public interface IOriginator {
        public void setState(Canvas state);
        public Canvas getState();
        public Memento createMemento();
        public void setMemento(Memento Memento);
    }

    public class Originator : IOriginator
    {
        private Canvas state;
        public void setState(Canvas state)
        {
            this.state = state;
        }

        public Canvas getState()
        {
            return state;
        }

        public Memento createMemento()
        {   // return a current snapshot (deep copy)
            return new Memento(new Canvas(state));
        }

        public void setMemento(Memento Memento)
        {  // restore from a snapshot
            state = Memento.getState();
        }
    }

    //
    // Caretaker class
    //
    // This class is a helper class that manages storing and restoring the Originator’s state using 
    // Memento object. Caretaker objects store Mementos, but never modify the Mementos. The Caretaker 
    // encapsulates a list of Mementos, allowing state changes over time to maintained. The Caretaker
    // requests Memento objects from the Originator.
    //

    public interface ICaretaker {
        public void add(Memento state);
        public Memento get(int index);
    }

    public class Caretaker : ICaretaker
    {
        private List<Memento> mementoList = new List<Memento>();
        public void add(Memento state)
        {
            mementoList.Add(state);
        }
        public Memento get(int index)
        {
            return mementoList[index];
        }
        public int ShowHistory1() {
            int i = 0;
            foreach (var m in mementoList) {
                i++;
            }
            return i-2;
        }
        public  int ShowHistory() {
            int i = 0;
            foreach (var m in mementoList) {
                i++;
            }
            return i-2;
        }
    }   
    }
} 