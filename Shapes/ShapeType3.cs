/*
 * Сделано в SharpDevelop.
 * Пользователь: 055makarov
 * Дата: 20.11.2014
 * Время: 9:17
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Drawing;
namespace Tetris
{
	/// <summary>
	///   #
	/// # 0 #	
	/// </summary>
	public class ShapeType3 : Shape
	{
		public ShapeType3() : this(Color.Black)
		{
			
		
		}
		
		
		public ShapeType3(Color c)
		{
			this.p=new Point[]{new Point(0,1),new Point(1,0),new Point(1,1),new Point(2,1)};
			this.c=c;
			this.pivot=new Point(1,1);
		}
	}
}
