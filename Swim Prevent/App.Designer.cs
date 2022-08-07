
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Swim_Prevent {
    partial class App {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            clickInfoBox = new System.Windows.Forms.TextBox();
            logBox = new System.Windows.Forms.TextBox();
            timeInfoBox = new System.Windows.Forms.TextBox();
            systemInfoBox = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            leftTotal = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            leftAverage = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            leftCPS = new System.Windows.Forms.Label();
            leftWithDC = new System.Windows.Forms.Label();
            leftTotalText = new System.Windows.Forms.Label();
            ratioLeftText = new System.Windows.Forms.Label();
            rightCPS = new System.Windows.Forms.Label();
            rightWithDC = new System.Windows.Forms.Label();
            rightRecord = new System.Windows.Forms.Label();
            rightTotal = new System.Windows.Forms.Label();
            rightAverage = new System.Windows.Forms.Label();
            leftDcLabel = new System.Windows.Forms.Label();
            leftDcCount = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            rightDcCount = new System.Windows.Forms.Label();
            clockLabel = new System.Windows.Forms.Label();
            leftRecordLabel = new System.Windows.Forms.Label();
            leftRecordText = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // clickInfoBox
            // 
            clickInfoBox.BackColor = System.Drawing.Color.Black;
            clickInfoBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            clickInfoBox.ForeColor = System.Drawing.Color.White;
            clickInfoBox.Location = new System.Drawing.Point(12, 12);
            clickInfoBox.Multiline = true;
            clickInfoBox.Name = "clickInfoBox";
            clickInfoBox.ReadOnly = true;
            clickInfoBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            clickInfoBox.ShortcutsEnabled = false;
            clickInfoBox.Size = new System.Drawing.Size(388, 134);
            clickInfoBox.TabIndex = 1;
            clickInfoBox.MouseClick += new System.Windows.Forms.MouseEventHandler(hideCaret);
            // 
            // logBox
            // 
            logBox.BackColor = System.Drawing.Color.Black;
            logBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            logBox.ForeColor = System.Drawing.Color.White;
            logBox.Location = new System.Drawing.Point(419, 12);
            logBox.MaxLength = 2147483647;
            logBox.Multiline = true;
            logBox.Name = "logBox";
            logBox.ReadOnly = true;
            logBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            logBox.ShortcutsEnabled = false;
            logBox.Size = new System.Drawing.Size(369, 426);
            logBox.TabIndex = 2;
            logBox.MouseClick += new System.Windows.Forms.MouseEventHandler(hideCaret);
            // 
            // timeInfoBox
            // 
            timeInfoBox.BackColor = System.Drawing.Color.Black;
            timeInfoBox.ForeColor = System.Drawing.Color.White;
            timeInfoBox.Location = new System.Drawing.Point(12, 166);
            timeInfoBox.Multiline = true;
            timeInfoBox.Name = "timeInfoBox";
            timeInfoBox.ReadOnly = true;
            timeInfoBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            timeInfoBox.ShortcutsEnabled = false;
            timeInfoBox.Size = new System.Drawing.Size(388, 126);
            timeInfoBox.TabIndex = 3;
            timeInfoBox.MouseClick += new System.Windows.Forms.MouseEventHandler(hideCaret);
            // 
            // systemInfoBox
            // 
            systemInfoBox.BackColor = System.Drawing.Color.Black;
            systemInfoBox.ForeColor = System.Drawing.Color.White;
            systemInfoBox.Location = new System.Drawing.Point(12, 312);
            systemInfoBox.Multiline = true;
            systemInfoBox.Name = "systemInfoBox";
            systemInfoBox.ReadOnly = true;
            systemInfoBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            systemInfoBox.ShortcutsEnabled = false;
            systemInfoBox.Size = new System.Drawing.Size(388, 126);
            systemInfoBox.TabIndex = 4;
            systemInfoBox.MouseClick += new System.Windows.Forms.MouseEventHandler(hideCaret);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Black;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.ForeColor = System.Drawing.Color.White;
            label1.Location = new System.Drawing.Point(23, 20);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(81, 20);
            label1.TabIndex = 5;
            label1.Text = "Left CPS: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.Black;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.ForeColor = System.Drawing.Color.White;
            label2.Location = new System.Drawing.Point(200, 20);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(87, 20);
            label2.TabIndex = 6;
            label2.Text = "Right CPS:";
            // 
            // leftTotal
            // 
            leftTotal.AutoSize = true;
            leftTotal.BackColor = System.Drawing.Color.Black;
            leftTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            leftTotal.ForeColor = System.Drawing.Color.White;
            leftTotal.Location = new System.Drawing.Point(23, 81);
            leftTotal.Name = "leftTotal";
            leftTotal.Size = new System.Drawing.Size(48, 20);
            leftTotal.TabIndex = 7;
            leftTotal.Text = "Total:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = System.Drawing.Color.Black;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.ForeColor = System.Drawing.Color.White;
            label4.Location = new System.Drawing.Point(200, 81);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(52, 20);
            label4.TabIndex = 8;
            label4.Text = "Total: ";
            // 
            // leftRecordLabel
            // 
            leftRecordLabel.AutoSize = true;
            leftRecordLabel.BackColor = System.Drawing.Color.Black;
            leftRecordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            leftRecordLabel.ForeColor = System.Drawing.Color.White;
            leftRecordLabel.Location = new System.Drawing.Point(23, 61);
            leftRecordLabel.Name = "Record:";
            leftRecordLabel.Size = new System.Drawing.Size(65, 20);
            leftRecordLabel.TabIndex = 9;
            leftRecordLabel.Text = "Record:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = System.Drawing.Color.Black;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.ForeColor = System.Drawing.Color.White;
            label6.Location = new System.Drawing.Point(200, 41);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(76, 20);
            label6.TabIndex = 10;
            label6.Text = "With DC: ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = System.Drawing.Color.Black;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.ForeColor = System.Drawing.Color.White;
            label7.Location = new System.Drawing.Point(23, 40);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(72, 20);
            label7.TabIndex = 11;
            label7.Text = "With DC:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = System.Drawing.Color.Black;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label8.ForeColor = System.Drawing.Color.White;
            label8.Location = new System.Drawing.Point(200, 61);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(69, 20);
            label8.TabIndex = 12;
            label8.Text = "Record: ";
            // 
            // leftAverage
            // 
            leftAverage.AutoSize = true;
            leftAverage.BackColor = System.Drawing.Color.Black;
            leftAverage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            leftAverage.ForeColor = System.Drawing.Color.White;
            leftAverage.Location = new System.Drawing.Point(23, 121);
            leftAverage.Name = "leftAverage";
            leftAverage.Size = new System.Drawing.Size(72, 20);
            leftAverage.TabIndex = 13;
            leftAverage.Text = "% Filtered:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = System.Drawing.Color.Black;
            label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label10.ForeColor = System.Drawing.Color.White;
            label10.Location = new System.Drawing.Point(200, 119);
            label10.Name = "% Filtered";
            label10.Size = new System.Drawing.Size(72, 20);
            label10.TabIndex = 14;
            label10.Text = "% Filtered";
            // 
            // leftCPS
            // 
            leftCPS.AutoSize = true;
            leftCPS.BackColor = System.Drawing.Color.Black;
            leftCPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            leftCPS.ForeColor = System.Drawing.Color.White;
            leftCPS.Location = new System.Drawing.Point(110, 20);
            leftCPS.Name = "leftCPS";
            leftCPS.Size = new System.Drawing.Size(18, 20);
            leftCPS.TabIndex = 15;
            leftCPS.Text = "0";
            // 
            // leftWithDC
            // 
            leftWithDC.AutoSize = true;
            leftWithDC.BackColor = System.Drawing.Color.Black;
            leftWithDC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            leftWithDC.ForeColor = System.Drawing.Color.White;
            leftWithDC.Location = new System.Drawing.Point(110, 41);
            leftWithDC.Name = "leftWithDC";
            leftWithDC.Size = new System.Drawing.Size(18, 20);
            leftWithDC.TabIndex = 16;
            leftWithDC.Text = "0";
            // 
            // leftRecordText
            // 
            leftRecordText.AutoSize = true;
            leftRecordText.BackColor = System.Drawing.Color.Black;
            leftRecordText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            leftRecordText.ForeColor = System.Drawing.Color.White;
            leftRecordText.Location = new System.Drawing.Point(110, 61);
            leftRecordText.Name = "leftRecord";
            leftRecordText.Size = new System.Drawing.Size(18, 20);
            leftRecordText.TabIndex = 17;
            leftRecordText.Text = "0";
            // 
            // leftTotalText 
            // 
            leftTotalText .AutoSize = true;
            leftTotalText .BackColor = System.Drawing.Color.Black;
            leftTotalText .Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            leftTotalText .ForeColor = System.Drawing.Color.White;
            leftTotalText .Location = new System.Drawing.Point(110, 81);
            leftTotalText .Name = "leftTotalText ";
            leftTotalText .Size = new System.Drawing.Size(18, 20);
            leftTotalText .TabIndex = 18;
            leftTotalText .Text = "0";
            // 
            // ratioLeftText
            // 
            ratioLeftText.AutoSize = true;
            ratioLeftText.BackColor = System.Drawing.Color.Black;
            ratioLeftText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ratioLeftText.ForeColor = System.Drawing.Color.White;
            ratioLeftText.Location = new System.Drawing.Point(110, 121);
            ratioLeftText.Name = "ratioLeftText";
            ratioLeftText.Size = new System.Drawing.Size(18, 20);
            ratioLeftText.TabIndex = 19;
            ratioLeftText.Text = "0";
            // 
            // rightCPS
            // 
            rightCPS.AutoSize = true;
            rightCPS.BackColor = System.Drawing.Color.Black;
            rightCPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            rightCPS.ForeColor = System.Drawing.Color.White;
            rightCPS.Location = new System.Drawing.Point(300, 20);
            rightCPS.Name = "rightCPS";
            rightCPS.Size = new System.Drawing.Size(18, 20);
            rightCPS.TabIndex = 20;
            rightCPS.Text = "0";
            // 
            // rightWithDC
            // 
            rightWithDC.AutoSize = true;
            rightWithDC.BackColor = System.Drawing.Color.Black;
            rightWithDC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            rightWithDC.ForeColor = System.Drawing.Color.White;
            rightWithDC.Location = new System.Drawing.Point(300, 41);
            rightWithDC.Name = "rightWithDC";
            rightWithDC.Size = new System.Drawing.Size(18, 20);
            rightWithDC.TabIndex = 21;
            rightWithDC.Text = "0";
            // 
            // rightRecord
            // 
            rightRecord.AutoSize = true;
            rightRecord.BackColor = System.Drawing.Color.Black;
            rightRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            rightRecord.ForeColor = System.Drawing.Color.White;
            rightRecord.Location = new System.Drawing.Point(300, 61);
            rightRecord.Name = "rightRecord";
            rightRecord.Size = new System.Drawing.Size(18, 20);
            rightRecord.TabIndex = 22;
            rightRecord.Text = "0";
            // 
            // rightTotal
            // 
            rightTotal.AutoSize = true;
            rightTotal.BackColor = System.Drawing.Color.Black;
            rightTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            rightTotal.ForeColor = System.Drawing.Color.White;
            rightTotal.Location = new System.Drawing.Point(300, 81);
            rightTotal.Name = "rightTotal";
            rightTotal.Size = new System.Drawing.Size(18, 20);
            rightTotal.TabIndex = 23;
            rightTotal.Text = "0";
            // 
            // rightAverage
            // 
            rightAverage.AutoSize = true;
            rightAverage.BackColor = System.Drawing.Color.Black;
            rightAverage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            rightAverage.ForeColor = System.Drawing.Color.White;
            rightAverage.Location = new System.Drawing.Point(300, 121);
            rightAverage.Name = "rightAverage";
            rightAverage.Size = new System.Drawing.Size(18, 20);
            rightAverage.TabIndex = 24;
            rightAverage.Text = "0";
            // 
            // leftDcLabel
            // 
            leftDcLabel.AutoSize = true;
            leftDcLabel.BackColor = System.Drawing.Color.Black;
            leftDcLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            leftDcLabel.ForeColor = System.Drawing.Color.White;
            leftDcLabel.Location = new System.Drawing.Point(23, 101);
            leftDcLabel.Name = "leftDcLabel";
            leftDcLabel.Size = new System.Drawing.Size(85, 20);
            leftDcLabel.TabIndex = 25;
            leftDcLabel.Text = "Prevented:";
            // 
            // leftDcCount
            // 
            leftDcCount.AutoSize = true;
            leftDcCount.BackColor = System.Drawing.Color.Black;
            leftDcCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            leftDcCount.ForeColor = System.Drawing.Color.White;
            leftDcCount.Location = new System.Drawing.Point(110, 101);
            leftDcCount.Name = "leftDcCount";
            leftDcCount.Size = new System.Drawing.Size(18, 20);
            leftDcCount.TabIndex = 26;
            leftDcCount.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = System.Drawing.Color.Black;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.ForeColor = System.Drawing.Color.White;
            label3.Location = new System.Drawing.Point(200, 99);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(85, 20);
            label3.TabIndex = 27;
            label3.Text = "Prevented:";
            // 
            // rightDcCount
            // 
            rightDcCount.AutoSize = true;
            rightDcCount.BackColor = System.Drawing.Color.Black;
            rightDcCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            rightDcCount.ForeColor = System.Drawing.Color.White;
            rightDcCount.Location = new System.Drawing.Point(300, 101);
            rightDcCount.Name = "rightDcCount";
            rightDcCount.Size = new System.Drawing.Size(18, 20);
            rightDcCount.TabIndex = 28;
            rightDcCount.Text = "0";
            // 
            // clockLabel
            // 
            clockLabel.AutoSize = true;
            clockLabel.BackColor = System.Drawing.Color.Black;
            clockLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            clockLabel.ForeColor = System.Drawing.Color.White;
            clockLabel.Location = new System.Drawing.Point(20, 220);
            clockLabel.Name = "00:00:00";
            clockLabel.Size = new System.Drawing.Size(18, 20);
            clockLabel.TabIndex = 21;
            clockLabel.Text = "00:00:00";
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(799, 451);
            this.Controls.Add(clockLabel);
            this.Controls.Add(rightDcCount);
            this.Controls.Add(label3);
            this.Controls.Add(leftDcCount);
            this.Controls.Add(leftDcLabel);
            this.Controls.Add(rightAverage);
            this.Controls.Add(rightTotal);
            this.Controls.Add(rightRecord);
            this.Controls.Add(rightWithDC);
            this.Controls.Add(rightCPS);
            this.Controls.Add(ratioLeftText);
            this.Controls.Add(leftTotalText );
            this.Controls.Add(leftWithDC);
            this.Controls.Add(leftCPS);
            this.Controls.Add(label10);
            this.Controls.Add(leftAverage);
            this.Controls.Add(label8);
            this.Controls.Add(label7);
            this.Controls.Add(label6);
            this.Controls.Add(label4);
            this.Controls.Add(leftTotal);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Controls.Add(systemInfoBox);
            this.Controls.Add(timeInfoBox);
            this.Controls.Add(logBox);
            this.Controls.Add(leftRecordText);
            this.Controls.Add(leftRecordLabel);
            this.Controls.Add(clickInfoBox);
            this.MaximumSize = new System.Drawing.Size(815, 490);
            this.MinimumSize = new System.Drawing.Size(815, 490);
            this.Name = "App";
            this.ShowIcon = false;
            this.Text = "Swim Prevent";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public static Label label1;
        public static TextBox clickInfoBox;
        public static TextBox logBox;
        public static TextBox timeInfoBox;
        public static TextBox systemInfoBox;
        public static Label label2;
        public static Label leftTotal;
        public static Label label4;
        public static Label leftRecord;
        public static Label label6;
        public static Label label7;
        public static Label label8;
        public static Label leftAverage;
        public static Label label10;
        public static Label leftCPS;
        public static Label leftWithDC;
        public static Label leftRecordText;
        public static Label leftTotalText ;
        public static Label ratioLeftText;
        public static Label rightCPS;
        public static Label rightWithDC;
        public static Label rightRecord;
        public static Label rightTotal;
        public static Label rightAverage;
        public static Label leftDcLabel;
        public static Label leftDcCount;
        public static Label label3;
        public static Label rightDcCount;
        public static Label clockLabel;
        public static Label leftRecordLabel;
    }
}

