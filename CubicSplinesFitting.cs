using System;
namespace ToBeBetter
{
    public class CurveFitting
    {
        public static void CubicSplineFitting(double[] x,double[] y)
        {
            if(x.Length!=y.Length || x.Length<3)
                return;
            var len = x.Length;
            /*
            转化为 a*k=b的矩阵形式
            a 三对角矩阵
            [a11 a12 0   ... ... 0
             a21 a22 a23 ... ... 0
             0   a32 a33 a34 ... 0
             ...
             0 ...      ann-1  ann ]
             */
            var a = new double[len,len];
            //a1为a矩阵的逆
            var a1 = new double[len,len];
            var b = new double[len]; 
            var hy1=0.0;
            var hy2=0.0;
            var hx1=0.0;
            var hx2=0.0;
            for(int i=0;i<len;i++)
            {
                if(i==0)
                {
                    hy2=y[i+1]-y[i];
                    hx2=x[i+1]-x[i];
                    b[i]=3*hy2/hx2/hx2;
                    a[i,i]=2/hx2;
                    a[i,i+1]=1/hx2;
                }
                else if(i==len-1)
                {
                    hy1=y[i]-y[i-1];
                    hx1=x[i]-x[i-1];
                    b[i]=3*hy1/hx1/hx1;
                    a[i,i-1]=1/hx1;
                    a[i,i]=2/hx1;
                }
                else
                {
                    hy1=y[i]-y[i-1];
                    hy2=y[i+1]-y[i];
                    hx1=x[i]-x[i-1];
                    hx2=x[i+1]-x[i];
                    b[i]=3*hy1/hx1/hx1+3*hy2/hx2/hx2;
                    a[i,i-1]=1/hx1;
                    a[i,i]=2/hx1+2/hx2;
                    a[i,i+1]=1/hx2;
                }
            }
            //AX=Y=>X=A^-1*Y
            var d=new double[len];
            var e=new double[len];
            for(int i=0;i<len;i++)
            {
                if(i==0)
                {
                    d[i]=a[i,i];
                    e[len-1-i]=a[len-1-i,len-1-i];
                }
                else if(i==1)
                {
                    d[i]=a[i,i]*d[i-1]-a[i-1,i]*a[i-1,i];
                    e[len-1-i]=a[len-1-i,len-1-i]*e[len-1-i+1]-a[len-1-i+1,len-1-i]*a[len-1-i,len-1-i+1];
                }
                else
                {
                    d[i]=a[i,i]*d[i-1]-a[i-1,i]*a[i,i-1]*d[i-2];
                    e[len-1-i]=a[len-1-i,len-1-i]*e[len-1-i+1]-a[len-1-i,len-1-i+1]*a[len-1-i+1,len-1-i]*e[len-1-i+2];
                }
            }
            //系数矩阵逆t,
            var maxij=0;
            var minij=0;
            var d1=0.0;
            var e1=0.0;
            var t = new double[len,len];
            for(int i=0;i<len;i++)
            {
                for(int j=0;j<len;j++)
                {
                    maxij = Math.Max(i,j);
                    minij = Math.Min(i,j);
                    d1 = minij==0?1:d[minij-1];
                    e1 = maxij==len-1?1:e[maxij+1];
                    t[i,j]=d1*e1/d[len-1];
                    if(i<j)
                    {
                        for(int l=i;l<j;l++)
                        {
                            t[i,j]*=(-1)*a[l,l+1];
                        }
                    }
                    else if(i>j)
                    {
                        for(int l=j;l<i;l++)
                        {
                            t[i,j]*=(-1)*a[l+1,l];
                        }
                    }
                    
                }
            }
            //一阶导数向量 k
            var k=new double[len];
            for(int i=0;i<len;i++)
            {
                for(int j=0;j<len;j++)
                {
                    k[i]+=t[i,j]*b[j];
                }
            }
            
            var pa=new double[len-1];
            var pb=new double[len-1];
            var pc=new double[len-1];
            var pd=new double[len-1];
            var ta=0.0;
            var tb=0.0;
            for(int i=0;i<len-1;i++)
            {
                ta=k[i]*(x[i+1]-x[i])-(y[i+1]-y[i]);
                tb=-k[i+1]*(x[i+1]-x[i])+(y[i+1]-y[i]);   
                pa[i]=(ta-tb)/Math.Pow(x[i+1]-x[i],3);
                pb[i]=-(ta-tb)/Math.Pow(x[i+1]-x[i],3)*3*x[i]-(2*ta-tb)/Math.Pow(x[i+1]-x[i],2);
                pc[i]=(ta-tb)/Math.Pow(x[i+1]-x[i],3)*3*x[i]*x[i]+(2*ta-tb)/Math.Pow(x[i+1]-x[i],2)*2*x[i]+(ta+y[i+1]-y[i])/(x[i+1]-x[i]);
                pd[i]=-(ta-tb)/Math.Pow(x[i+1]-x[i],3)*Math.Pow(x[i],3)-(2*ta-tb)/Math.Pow(x[i+1]-x[i],2)*x[i]*x[i]+y[i]-(ta+y[i+1]-y[i])*x[i]/(x[i+1]-x[i]);  
                Console.WriteLine("y={0}*x^3+{1}*x^2+{2}*x+{3}",pa[i],pb[i],pc[i],pd[i]);  
            }

            //x上下限
            var xd1 = (-2*pb[0]-Math.Sqrt(4*pb[0]*pb[0]-12*pa[0]*pc[0]))/6/pa[0];
            var xd2 = (-2*pb[0]-Math.Sqrt(4*pb[0]*pb[0]-12*pa[0]*pc[0]))/6/pa[0];
            var xd=0.0;
            if(double.IsNaN(xd1))
                xd=double.MinValue;
            else if(xd1<x[0]&&xd2<x[0])
                xd=Math.Max(xd1,xd2);
            else if(xd1>x[0] && xd2>x[0])
                xd=double.MinValue;
            else
                xd = Math.Min(xd1,xd2);

            var xu1 = (-2*pb[len-2]-Math.Sqrt(4*pb[len-2]*pb[len-2]-12*pa[len-2]*pc[len-2]))/6/pa[len-2];
            var xu2 = (-2*pb[len-2]-Math.Sqrt(4*pb[len-2]*pb[len-2]-12*pa[len-2]*pc[len-2]))/6/pa[len-2];
            var xu=0.0;
            if(double.IsNaN(xu1))
                xu=double.MaxValue;
            else if(Math.Min(xu1,xu2)>=x[len-2])
                xu=Math.Min(xu1,xu2);
            else if(Math.Max(xu1,xu2)<=x[len-2])
                xu=double.MaxValue;
            else
                xu = Math.Max(xu1,xu2);
            Console.WriteLine("x有效范围为[{0},{1}]",xd,xu);
        }
    }

    public class Poly3thOrderParam
    {
        public double a;
        public double b;
        public double c;
        public double d;
    }
}