using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Task003
{
    public enum BorderStyle {None, Single, Double}
    public class UIControl
    {
        public int PosX { get; private set; }
        public int PosY { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }
        public string Caption { get; private set; }
        public Rect Rect { get; private set; }
        public BorderStyle BorderStyle { get; private set; }
        public ConsoleColor CaptionColor { get; private set; }
        public ConsoleColor BorderColor { get; private set; }
        protected int _offsetX;
        protected int _offsetY;


        public UIControl(int posX, int posY, int height, int width, string caption)
        {
            PosX = posX;
            PosY = posY;
            Height = height;
            Width = width;
            Rect = new Rect(PosX, PosY, Width, Height);
            Caption = caption;
            _offsetX = 0;
            _offsetY = 0;
            BorderStyle = BorderStyle.None;
            CaptionColor = Console.ForegroundColor;
            BorderColor = Console.ForegroundColor;
    }

        public virtual void SetParameters(BorderStyle borderStyle, ConsoleColor captionColor, ConsoleColor borderColor)
        {
            BorderStyle = borderStyle;
            _offsetX = borderStyle == BorderStyle.None ? 0 : 1;
            _offsetY = borderStyle == BorderStyle.None ? 0 : 1;
            CaptionColor = captionColor;
            BorderColor = borderColor;
        }

        private void DrawBorder()
        {
            if (BorderStyle == BorderStyle.None)
                return;

            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = BorderColor;
            Console.SetCursorPosition(PosX, PosY);
            string s = string.Empty;
            if (BorderStyle == BorderStyle.Double)
            {
                Console.Write("╔");
                s = s.PadRight(Width - 2, '═');
            }
            else
            {
                Console.Write("┌");
                s = s.PadRight(Width - 2, '─');
            }
            Console.Write(s);
            if (BorderStyle == BorderStyle.Double)
                Console.Write("╗");
            else
                Console.Write("┐");

            Console.SetCursorPosition(PosX, Height + PosY - 1);
            if (BorderStyle == BorderStyle.Double)
                Console.Write("╚");
            else
                Console.Write("└");
            Console.Write(s);
            if (BorderStyle == BorderStyle.Double)
                Console.Write("╝");
            else
                Console.Write("┘");

            for (int i = PosY + 1; i < Height + PosY - 1; i++)
            {
                Console.SetCursorPosition(PosX, i);
                if (BorderStyle == BorderStyle.Double)
                    Console.Write("║");
                else
                    Console.Write("│");
                Console.SetCursorPosition(PosX + Width - 1, i);
                if (BorderStyle == BorderStyle.Double)
                    Console.Write("║");
                else
                    Console.Write("│");
            }
            Console.ForegroundColor = oldColor;
        }

        public virtual void Draw()
        {
            DrawBorder();

            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = CaptionColor;

            string[] aCaption = (from Match m in Regex.Matches(Caption, @".{1," + (Width - _offsetX * 2) + "}")
                                 select m.Value).ToArray();
            for (int i = 0; i < aCaption.Length; i++)
            {
                if (i >= (Height - _offsetY * 2))
                {
                    break;
                }
                Console.SetCursorPosition(PosX + _offsetX, PosY + _offsetY + i);
                Console.Write(aCaption[i]);
            }

            Console.ForegroundColor = oldColor;
        }

        public bool CoordinatesInRect(int x, int y)
        {
            return Rect.Contains(x, y);
        }
    }

    public class UICaption : UIControl
    {
        public UICaption(int posX, int posY, int height, int width, string caption) : base(posX, posY, height, width, caption)
        {
        }
    }

    public class UIButton : UIControl
    {
        public UIButton(int posX, int posY, int height, int width, string caption) : base(posX, posY, height, width, caption)
        {
            SetParameters(BorderStyle.Single, ConsoleColor.White, ConsoleColor.Blue);
        }

        private void DrawShadow()
        {
            if (BorderStyle == BorderStyle.None)
                return;

            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(PosX + 1, PosY + Height);
            string s = string.Empty;

            s = s.PadRight(Width, '▀');

            Console.Write(s);

            for (int i = PosY + 1; i < Height + PosY; i++)
            {
                Console.SetCursorPosition(PosX + Width, i);
                Console.Write("█");
            }
            Console.ForegroundColor = oldColor;
        }

        public override void Draw()
        {
            base.Draw();
            DrawShadow();
        }
    }

    public class UICheckBox : UIControl
    {
        private bool _checked;
        public bool Checked
        {
            get { return _checked; }
            set 
            {
                _checked = value;
                Draw();
            }
        }

        public UICheckBox(int posX, int posY, int height, int width, string caption) : base(posX, posY, height, width, caption)
        {
            _offsetX = 3;
        }
        public override void Draw()
        {
            base.Draw();
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = CaptionColor;
            Console.SetCursorPosition(PosX + _offsetX - 3, PosY + _offsetY);
            Console.Write($"[{(_checked ? 'X' : ' ')}]");

            Console.ForegroundColor = oldColor;
        }

        public override void SetParameters(BorderStyle borderStyle, ConsoleColor captionColor, ConsoleColor borderColor)
        {
            base.SetParameters(borderStyle, captionColor, borderColor);
            _offsetX = borderStyle == BorderStyle.None ? 3 : 4;
        }
    }

    public class UIEdit : UIControl
    {
        public UIEdit(int posX, int posY, int height, int width) : base(posX, posY, height, width, "")
        {

        }
    }

    class UI
    {
        private List<UIControl> _controls;

        public UI()
        {
            _controls = new List<UIControl>();
        }

        public void AddControl(UIControl control)
        {
            _controls.Add(control);
        }

        public UIControl GetControlOnCursor(int x, int y)
        {
            UIControl result = null;
            foreach (UIControl c in _controls)
            {
                if(c.CoordinatesInRect(x, y))
                {
                    result = c;
                    break;
                }
            }
            return result;
        }

        public void Draw()
        {
            foreach (UIControl c in _controls)
                c.Draw();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Console.CursorVisible = false;

            UI ui = CreateControls(); 
            ui.Draw();

            // Console.ReadKey();


            while (true)
            {
                GetInput();
                
            }
        }

        private static UI CreateControls()
        {
            UI ui = new UI();

            UICaption uiCaption = new UICaption(1, 1, 4, 16, "Текстовое поле с рамкой");
            uiCaption.SetParameters(BorderStyle.Single, uiCaption.CaptionColor, ConsoleColor.Cyan);
            ui.AddControl(uiCaption);

            UICaption uiCaption2 = new UICaption(1, 5, 2, 15, "Текстовое поле без рамки");
            ui.AddControl(uiCaption2);

            UIButton uiButton = new UIButton(1, 8, 3, 18, "Тестовая кнопка");
            ui.AddControl(uiButton);

            UICheckBox uiCheckBox = new UICheckBox(1, 15, 3, 25, "Тестовый чекбокс");
            uiCheckBox.SetParameters(BorderStyle.Double, uiCheckBox.CaptionColor, uiCheckBox.CaptionColor);
            ui.AddControl(uiCheckBox);

            return ui;
        }

        private static ConsoleKey GetInput()
        {
            int posX = Console.CursorLeft;
            int posY = Console.CursorTop;

            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.UpArrow: posY--;
                    break;
                case ConsoleKey.DownArrow:
                    posY++;
                    break;
                case ConsoleKey.LeftArrow:
                    posX--;
                    break;
                case ConsoleKey.RightArrow:
                    posX++;
                    break;
            }

            Console.SetCursorPosition(posX, posY);

            return key;
        }

    }
}
