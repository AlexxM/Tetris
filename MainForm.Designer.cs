/*
 * Сделано в SharpDevelop.
 * Пользователь: 055makarov
 * Дата: 11/18/2014
 * Время: 15:30
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
namespace Tetris
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.btnStart = new System.Windows.Forms.Button();
			this.btnResume = new System.Windows.Forms.Button();
			this.selectSpeed = new System.Windows.Forms.DomainUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.lblStatus = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.selectFieldSize = new System.Windows.Forms.DomainUpDown();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
			this.pictureBox1.Location = new System.Drawing.Point(24, 26);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(120, 245);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox1Paint);
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(24, 304);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(93, 23);
			this.btnStart.TabIndex = 1;
			this.btnStart.Text = "Игра";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.Button1Click);
			// 
			// btnResume
			// 
			this.btnResume.Location = new System.Drawing.Point(133, 304);
			this.btnResume.Name = "btnResume";
			this.btnResume.Size = new System.Drawing.Size(92, 23);
			this.btnResume.TabIndex = 2;
			this.btnResume.Text = "Пауза";
			this.btnResume.UseVisualStyleBackColor = true;
			this.btnResume.Click += new System.EventHandler(this.BtnResumeClick);
			// 
			// selectSpeed
			// 
			this.selectSpeed.Items.Add("Стандартная");
			this.selectSpeed.Items.Add("Быстрая");
			this.selectSpeed.Items.Add("Очень быстрая");
			this.selectSpeed.Location = new System.Drawing.Point(193, 96);
			this.selectSpeed.Name = "selectSpeed";
			this.selectSpeed.ReadOnly = true;
			this.selectSpeed.Size = new System.Drawing.Size(120, 20);
			this.selectSpeed.TabIndex = 3;
			this.selectSpeed.Text = "Стандартная";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(193, 70);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "Скорость:";
			// 
			// lblStatus
			// 
			this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblStatus.Location = new System.Drawing.Point(193, 26);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(100, 35);
			this.lblStatus.TabIndex = 6;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(193, 124);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 7;
			this.label2.Text = "Размер поля:";
			// 
			// selectFieldSize
			// 
			this.selectFieldSize.Items.Add("Стандартный");
			this.selectFieldSize.Items.Add("Расширенный");
			this.selectFieldSize.Location = new System.Drawing.Point(193, 150);
			this.selectFieldSize.Name = "selectFieldSize";
			this.selectFieldSize.ReadOnly = true;
			this.selectFieldSize.Size = new System.Drawing.Size(120, 20);
			this.selectFieldSize.TabIndex = 8;
			this.selectFieldSize.Text = "Стандартный";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(317, 339);
			this.Controls.Add(this.selectFieldSize);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.selectSpeed);
			this.Controls.Add(this.btnResume);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.pictureBox1);
			this.KeyPreview = true;
			this.Name = "MainForm";
			this.Text = "Tetris";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainFormKeyDown);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.DomainUpDown selectFieldSize;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DomainUpDown selectSpeed;
		private System.Windows.Forms.Button btnResume;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}
