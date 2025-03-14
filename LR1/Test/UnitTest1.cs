using ConsolePaint;
using ConsolePaint.Figures;
using ConsolePaint.Tools;

namespace Test
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            FileWorker fileWorker = new FileWorker("test1.txt");
            bool res = fileWorker.Read() is null ? false: true;
            Assert.IsTrue(res);
        }

        [Test]
        public void Test2()
        {
            FileWorker fileWorker = new FileWorker("test1.txt");
            List<IFigure> figures = new List<IFigure>();
            bool res = fileWorker.Write(figures);
            Assert.IsTrue(res);
        }
        [Test]
        public void Test3()
        {
            ChangeAction changeAction = new ChangeAction();
            bool res;
            try
            {
                changeAction.Back();
                res = true;
            }
            catch
            {
                res = false;
            }
            Assert.IsTrue(!res);
        }

        [Test]
        public void Test4()
        {
            ChangeAction changeAction = new ChangeAction();
            bool res;
            try
            {
                changeAction.Forward();
                res = true;
            }
            catch
            {
                res = false;
            }
            Assert.IsTrue(!res);
        }

        [Test]
        public void Test5()
        {
            Drawer drawer = new Drawer(212, 50);
            bool res = drawer.ReDraw();
            Assert.IsTrue(!res);
        }

        [Test]
        public void Test6()
        {
            Drawer drawer = new Drawer(212, 50);
            bool res = drawer.DrawCircle(1);
            Assert.IsTrue(!res);
        }

        [Test]
        public void Test7()
        {
            Drawer drawer = new Drawer(212, 50);
            bool res = drawer.DrawEllipse(1, 1);
            Assert.IsTrue(!res);
        }

        [Test]
        public void Test8()
        {
            Drawer drawer = new Drawer(212, 50);
            bool res = drawer.DrawRectangle(1, 1);
            Assert.IsTrue(!res);
        }

        [Test]
        public void Test9()
        {
            Drawer drawer = new Drawer(212, 50);
            bool res = drawer.DrawSquare(1);
            Assert.IsTrue(!res);
        }

        [Test]
        public void Test10()
        {
            bool res;
            try
            {
                Drawer drawer = new Drawer(212, 50);
                drawer.DrawTriangle(1);
                res = true;
            }
            catch
            {
                res = false;
            }

            Assert.IsTrue(!res);
        }

        [Test]
        public void Test11()
        {
            Drawer drawer = new Drawer(212, 50);
            bool res = drawer.GetFigures().Count == 0;
            Assert.IsTrue(res);
        }

        [Test]
        public void Test12()
        {
            List<IFigure> figures = new List<IFigure>();
            figures.Add(new Circle(1));
            Drawer drawer = new Drawer(212, 50, figures);
            bool res = drawer.GetFigures().Count != 0;
            Assert.IsTrue(res);
        }

        [Test]
        public void Test13()
        {
            List<IFigure> figures = new List<IFigure>();
            figures.Add(new Circle(1));
            Drawer drawer = new Drawer(212, 50, figures);
            bool res = drawer.UnDraw(0);
            Assert.IsTrue(res);
        }

        [Test]
        public void Test14()
        {
            List<IFigure> figures = new List<IFigure>();
            figures.Add(new Circle(1));
            Drawer drawer = new Drawer(212, 50, figures);
            bool res = drawer.Fill(0, '$');
            Assert.IsTrue(res);
        }
    }
}