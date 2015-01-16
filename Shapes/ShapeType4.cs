/*
 * Сделано в SharpDevelop.
 * Пользователь: 055makarov
 * Дата: 20.11.2014
 * Время: 9:21
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Drawing;
namespace Tetris
{
	/// <summary>
	///   #
	/// 0 #
	/// #	
	/// </summary>
	public class ShapeType4 : Shape
	{
		public ShapeType4() : this(Color.Black)
		{
			
		
		}
		
		
		public ShapeType4(Color c)
		{
			this.p=new Point[]{new Point(1,0),new Point(0,1),new Point(1,1),new Point(0,2)};
			this.c=c;
			this.pivot=new Point(0,1);
		}
	}
}
