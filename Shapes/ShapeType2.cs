/*
 * Сделано в SharpDevelop.
 * Пользователь: 055makarov
 * Дата: 19.11.2014
 * Время: 16:47
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Drawing;
namespace Tetris
{
	/// <summary>
	///  # #
	///  # #	
	/// </summary>
	public class ShapeType2 : Shape
	{
		public ShapeType2() : this(Color.Black)
		{
			
		
		}
		
		
		public ShapeType2(Color c)
		{
			this.p=new Point[]{new Point(0,0),new Point(1,0),new Point(0,1),new Point(1,1)};
			this.pe=PivotEnabled.NoPivot;
			this.c=c;
		}
	}
}
