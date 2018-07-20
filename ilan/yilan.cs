using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ilan
{
    class yilan
    {
        Yparcalari[] yilan_parca;
        int yilan_buyuklugu;
        Yon yonumuz;
        public yilan()
        {
            yilan_parca = new Yparcalari[3];
            yilan_buyuklugu = 3;
            yilan_parca[0] = new Yparcalari(150, 150); 
            yilan_parca[1] = new Yparcalari(160, 150);
            yilan_parca[2] = new Yparcalari(170, 150);
        }

        public void ilerle(Yon yon)
        {
            yonumuz = yon;
            if(yon._x==0&&yon._y==0)
            { }

            else
            { 
                for(int i = yilan_parca.Length-1;i>0;i--)
                {
                    yilan_parca[i] = new Yparcalari(yilan_parca[i - 1].x_, yilan_parca[i - 1].y_);
                                    }
                yilan_parca[0] = new Yparcalari(yilan_parca[0].x_ + yon._x, yilan_parca[0].y_ + yon._y);
            }
        }

        public void Buyu()
        {
            Array.Resize(ref yilan_parca, yilan_parca.Length + 1);
            yilan_parca[yilan_parca.Length-1 ] = new Yparcalari(yilan_parca[yilan_parca.Length -2].x_-yonumuz._x, yilan_parca[yilan_parca.Length - 2].y_ - yonumuz._y);
            yilan_buyuklugu++;
        }
        
        public Point Gpos(int number)
        {
            return new Point(yilan_parca[number].x_, yilan_parca[number].y_);
        }
        public int Yilan_buyuklugu
        {
            get { return yilan_buyuklugu; }
        }



    class Yparcalari
    {
        public  int x_;
        public  int y_;
        public readonly int sizex;
        public readonly int sizey;
        public Yparcalari(int x,int y)
        {
            x_ = x; 
            y_ = y;
            sizex = 10;
            sizey = 10;
        }
    }
       public class Yon
        {
            public readonly int _x;
            public readonly int _y;
            public Yon(int x, int y)
            {
                _x = x;
                _y = y;
            }
        }
    }

}
