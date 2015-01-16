/*
 * Сделано в SharpDevelop.
 * Пользователь: 055makarov
 * Дата: 11/18/2014
 * Время: 16:00
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Drawing;
namespace Tetris
{
	/// <summary>
	/// Description of Shape.
	/// </summary>
	public enum PivotEnabled
	{
		Pivot,
		NoPivot
	}
	
	public class Shape
	{
		public Point[] p;
		public Point pivot;
		public Color c;
		public PivotEnabled pe=PivotEnabled.Pivot;
		public Shape()
		{
		
		}
		
		public Shape(Point[] p,Point pivot) : this(p,pivot,Color.Black)
		{
			
		}
		
		public Shape(Point[] p,Point pivot,Color c)
		{
			this.p=p;
			this.pivot=pivot;
			this.c=c;
			
		}
		
		public int GetShapeWidth()
		{
			int max=p[0].X;
			for(int i=1;i<p.Length;i++)
			{
				if(max<p[i].X)
				{
					max=p[i].X;
				}
			}
			
			return max;
		}
		
		public void ShapeRotate()
		{
			if(this.p!=null && pe==PivotEnabled.Pivot)
			{
				Point[] tempPoint = new Point[p.Length];
				for(int i=0;i<tempPoint.Length;i++)
				{
					tempPoint[i].X=p[i].X-pivot.X;
					tempPoint[i].Y=p[i].Y-pivot.Y;
				}
				
				for(int i=0;i<p.Length;i++)
				{
					p[i].X=-tempPoint[i].Y;
					p[i].Y=tempPoint[i].X;
				}
				
				for(int i=0;i<p.Length;i++)
				{
					p[i].X=p[i].X+pivot.X;
					p[i].Y=p[i].Y+pivot.Y;
				}
			}
		}
		
		public Shape Clone()
		{
			Shape s = (Shape)this.MemberwiseClone();
			s.p = (Point[])this.p.Clone();
		
			return s;
		}
	}
}
