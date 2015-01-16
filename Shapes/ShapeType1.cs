/*
 * Сделано в SharpDevelop.
 * Пользователь: 055makarov
 * Дата: 19.11.2014
 * Время: 16:37
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Drawing;
namespace Tetris
{
	/// <summary>
	///   # 0 # #
	/// </summary>
	public class ShapeType1 : Shape
	{
		public ShapeType1() : this(Color.Black)
		{
			
		
		}
		
		
		public ShapeType1(Color c)
		{
			this.p=new Point[]{new Point(0,0),new Point(1,0),new Point(2,0),new Point(3,0)};
			this.pivot=new Point(1,0);
			this.c=c;
		}
	}
}
