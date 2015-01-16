/*
 * Сделано в SharpDevelop.
 * Пользователь: 055makarov
 * Дата: 20.11.2014
 * Время: 9:35
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Drawing;
namespace Tetris
{
	/// <summary>
	///   #
	///   0
	/// # # 
	/// </summary>
	public class ShapeType7 : Shape
	{
		public ShapeType7() : this(Color.Black)
		{
			
		
		}
		
		
		public ShapeType7(Color c)
		{
			this.p=new Point[]{new Point(1,0),new Point(1,1),new Point(1,2),new Point(0,2)};
			this.c=c;
			this.pivot=new Point(1,1);
		}
	}
}
