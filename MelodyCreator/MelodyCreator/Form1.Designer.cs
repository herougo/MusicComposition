namespace MelodyCreator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tBMaxIntervalBtnThemes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cBStyle = new System.Windows.Forms.ComboBox();
            this.lblStyle = new System.Windows.Forms.Label();
            this.cBKeyQuality = new System.Windows.Forms.ComboBox();
            this.cBKeyTonic = new System.Windows.Forms.ComboBox();
            this.lblKey = new System.Windows.Forms.Label();
            this.lblHarmonicNotes = new System.Windows.Forms.Label();
            this.tBMaxNoteRepeat = new System.Windows.Forms.TextBox();
            this.lblMaxNoteRepeat = new System.Windows.Forms.Label();
            this.tBRange = new System.Windows.Forms.TextBox();
            this.lblExtraNotes = new System.Windows.Forms.Label();
            this.lblRange = new System.Windows.Forms.Label();
            this.tBHarmonicNotes = new System.Windows.Forms.TextBox();
            this.tBMaxInterval = new System.Windows.Forms.TextBox();
            this.tBExtraNotes = new System.Windows.Forms.TextBox();
            this.lblMaxInterval = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.rTBThemeBHarmony = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rTBThemeAHarmony = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dGVProcedure = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.rTBMelodyNoteForm = new System.Windows.Forms.RichTextBox();
            this.btnCreateMelody = new System.Windows.Forms.Button();
            this.rTBMelody = new System.Windows.Forms.RichTextBox();
            this.btnPlay = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVProcedure)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1098, 591);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tBMaxIntervalBtnThemes);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.cBStyle);
            this.tabPage1.Controls.Add(this.lblStyle);
            this.tabPage1.Controls.Add(this.cBKeyQuality);
            this.tabPage1.Controls.Add(this.cBKeyTonic);
            this.tabPage1.Controls.Add(this.lblKey);
            this.tabPage1.Controls.Add(this.lblHarmonicNotes);
            this.tabPage1.Controls.Add(this.tBMaxNoteRepeat);
            this.tabPage1.Controls.Add(this.lblMaxNoteRepeat);
            this.tabPage1.Controls.Add(this.tBRange);
            this.tabPage1.Controls.Add(this.lblExtraNotes);
            this.tabPage1.Controls.Add(this.lblRange);
            this.tabPage1.Controls.Add(this.tBHarmonicNotes);
            this.tabPage1.Controls.Add(this.tBMaxInterval);
            this.tabPage1.Controls.Add(this.tBExtraNotes);
            this.tabPage1.Controls.Add(this.lblMaxInterval);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1090, 565);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Basic Data";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tBMaxIntervalBtnThemes
            // 
            this.tBMaxIntervalBtnThemes.Location = new System.Drawing.Point(169, 146);
            this.tBMaxIntervalBtnThemes.Name = "tBMaxIntervalBtnThemes";
            this.tBMaxIntervalBtnThemes.Size = new System.Drawing.Size(77, 20);
            this.tBMaxIntervalBtnThemes.TabIndex = 49;
            this.tBMaxIntervalBtnThemes.Text = "6";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "Max Interval Between Themes";
            // 
            // cBStyle
            // 
            this.cBStyle.FormattingEnabled = true;
            this.cBStyle.Items.AddRange(new object[] {
            "Henri Song"});
            this.cBStyle.Location = new System.Drawing.Point(152, 9);
            this.cBStyle.Name = "cBStyle";
            this.cBStyle.Size = new System.Drawing.Size(76, 21);
            this.cBStyle.TabIndex = 47;
            this.cBStyle.Text = "Henri Song";
            // 
            // lblStyle
            // 
            this.lblStyle.AutoSize = true;
            this.lblStyle.Location = new System.Drawing.Point(12, 12);
            this.lblStyle.Name = "lblStyle";
            this.lblStyle.Size = new System.Drawing.Size(30, 13);
            this.lblStyle.TabIndex = 46;
            this.lblStyle.Text = "Style";
            // 
            // cBKeyQuality
            // 
            this.cBKeyQuality.FormattingEnabled = true;
            this.cBKeyQuality.Items.AddRange(new object[] {
            "Major",
            "Natural Minor",
            "Harmonic Minor"});
            this.cBKeyQuality.Location = new System.Drawing.Point(252, 224);
            this.cBKeyQuality.Name = "cBKeyQuality";
            this.cBKeyQuality.Size = new System.Drawing.Size(99, 21);
            this.cBKeyQuality.TabIndex = 45;
            this.cBKeyQuality.Text = "Major";
            // 
            // cBKeyTonic
            // 
            this.cBKeyTonic.FormattingEnabled = true;
            this.cBKeyTonic.Items.AddRange(new object[] {
            "C",
            "C♯/D♭",
            "D",
            "D♯/E♭",
            "E",
            "F",
            "F♯/G♭",
            "G",
            "G♯/A♭",
            "A",
            "A♯/B♭",
            "B"});
            this.cBKeyTonic.Location = new System.Drawing.Point(170, 224);
            this.cBKeyTonic.Name = "cBKeyTonic";
            this.cBKeyTonic.Size = new System.Drawing.Size(76, 21);
            this.cBKeyTonic.TabIndex = 44;
            this.cBKeyTonic.Text = "C";
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(12, 227);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(25, 13);
            this.lblKey.TabIndex = 43;
            this.lblKey.Text = "Key";
            // 
            // lblHarmonicNotes
            // 
            this.lblHarmonicNotes.AutoSize = true;
            this.lblHarmonicNotes.Location = new System.Drawing.Point(13, 71);
            this.lblHarmonicNotes.Name = "lblHarmonicNotes";
            this.lblHarmonicNotes.Size = new System.Drawing.Size(83, 13);
            this.lblHarmonicNotes.TabIndex = 33;
            this.lblHarmonicNotes.Text = "Harmonic Notes";
            // 
            // tBMaxNoteRepeat
            // 
            this.tBMaxNoteRepeat.Location = new System.Drawing.Point(169, 198);
            this.tBMaxNoteRepeat.Name = "tBMaxNoteRepeat";
            this.tBMaxNoteRepeat.Size = new System.Drawing.Size(77, 20);
            this.tBMaxNoteRepeat.TabIndex = 42;
            this.tBMaxNoteRepeat.Text = "3";
            // 
            // lblMaxNoteRepeat
            // 
            this.lblMaxNoteRepeat.AutoSize = true;
            this.lblMaxNoteRepeat.Location = new System.Drawing.Point(12, 201);
            this.lblMaxNoteRepeat.Name = "lblMaxNoteRepeat";
            this.lblMaxNoteRepeat.Size = new System.Drawing.Size(134, 13);
            this.lblMaxNoteRepeat.TabIndex = 41;
            this.lblMaxNoteRepeat.Text = "Max Repeated Note Times";
            // 
            // tBRange
            // 
            this.tBRange.Location = new System.Drawing.Point(169, 172);
            this.tBRange.Name = "tBRange";
            this.tBRange.Size = new System.Drawing.Size(77, 20);
            this.tBRange.TabIndex = 40;
            this.tBRange.Text = "2";
            // 
            // lblExtraNotes
            // 
            this.lblExtraNotes.AutoSize = true;
            this.lblExtraNotes.Location = new System.Drawing.Point(13, 97);
            this.lblExtraNotes.Name = "lblExtraNotes";
            this.lblExtraNotes.Size = new System.Drawing.Size(62, 13);
            this.lblExtraNotes.TabIndex = 34;
            this.lblExtraNotes.Text = "Extra Notes";
            // 
            // lblRange
            // 
            this.lblRange.AutoSize = true;
            this.lblRange.Location = new System.Drawing.Point(12, 175);
            this.lblRange.Name = "lblRange";
            this.lblRange.Size = new System.Drawing.Size(88, 13);
            this.lblRange.TabIndex = 39;
            this.lblRange.Text = "Range (Octaves)";
            // 
            // tBHarmonicNotes
            // 
            this.tBHarmonicNotes.Location = new System.Drawing.Point(170, 68);
            this.tBHarmonicNotes.Name = "tBHarmonicNotes";
            this.tBHarmonicNotes.Size = new System.Drawing.Size(77, 20);
            this.tBHarmonicNotes.TabIndex = 35;
            this.tBHarmonicNotes.Text = "6";
            // 
            // tBMaxInterval
            // 
            this.tBMaxInterval.Location = new System.Drawing.Point(170, 120);
            this.tBMaxInterval.Name = "tBMaxInterval";
            this.tBMaxInterval.Size = new System.Drawing.Size(77, 20);
            this.tBMaxInterval.TabIndex = 38;
            this.tBMaxInterval.Text = "4";
            // 
            // tBExtraNotes
            // 
            this.tBExtraNotes.Location = new System.Drawing.Point(170, 94);
            this.tBExtraNotes.Name = "tBExtraNotes";
            this.tBExtraNotes.Size = new System.Drawing.Size(77, 20);
            this.tBExtraNotes.TabIndex = 36;
            this.tBExtraNotes.Text = "3";
            // 
            // lblMaxInterval
            // 
            this.lblMaxInterval.AutoSize = true;
            this.lblMaxInterval.Location = new System.Drawing.Point(13, 123);
            this.lblMaxInterval.Name = "lblMaxInterval";
            this.lblMaxInterval.Size = new System.Drawing.Size(65, 13);
            this.lblMaxInterval.TabIndex = 37;
            this.lblMaxInterval.Text = "Max Interval";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.rTBThemeBHarmony);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.rTBThemeAHarmony);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1090, 565);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Harmony Structure";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(244, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Theme B:";
            // 
            // rTBThemeBHarmony
            // 
            this.rTBThemeBHarmony.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rTBThemeBHarmony.Location = new System.Drawing.Point(248, 132);
            this.rTBThemeBHarmony.Name = "rTBThemeBHarmony";
            this.rTBThemeBHarmony.ReadOnly = true;
            this.rTBThemeBHarmony.Size = new System.Drawing.Size(169, 155);
            this.rTBThemeBHarmony.TabIndex = 2;
            this.rTBThemeBHarmony.Text = "IV  -   I   -\n\nV   -   vi  -\n\nIV  -   I   -\n\nV   -   I   -";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Theme A:";
            // 
            // rTBThemeAHarmony
            // 
            this.rTBThemeAHarmony.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rTBThemeAHarmony.Location = new System.Drawing.Point(39, 132);
            this.rTBThemeAHarmony.Name = "rTBThemeAHarmony";
            this.rTBThemeAHarmony.ReadOnly = true;
            this.rTBThemeAHarmony.Size = new System.Drawing.Size(169, 155);
            this.rTBThemeAHarmony.TabIndex = 0;
            this.rTBThemeAHarmony.Text = "I   -   -   -\n\nV   -   -   -\n\nI   -   -   -\n\nIV  V   I   - ";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1090, 565);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Other";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.dGVProcedure);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1090, 565);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Procedure";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dGVProcedure
            // 
            this.dGVProcedure.AllowUserToAddRows = false;
            this.dGVProcedure.AllowUserToDeleteRows = false;
            this.dGVProcedure.AllowUserToResizeColumns = false;
            this.dGVProcedure.AllowUserToResizeRows = false;
            this.dGVProcedure.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVProcedure.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dGVProcedure.Location = new System.Drawing.Point(3, 3);
            this.dGVProcedure.Name = "dGVProcedure";
            this.dGVProcedure.RowHeadersVisible = false;
            this.dGVProcedure.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVProcedure.Size = new System.Drawing.Size(487, 559);
            this.dGVProcedure.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Bar";
            this.Column1.Name = "Column1";
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Procedure";
            this.Column2.Name = "Column2";
            this.Column2.Width = 200;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnPlay);
            this.tabPage4.Controls.Add(this.rTBMelodyNoteForm);
            this.tabPage4.Controls.Add(this.btnCreateMelody);
            this.tabPage4.Controls.Add(this.rTBMelody);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1090, 565);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Created Piece";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // rTBMelodyNoteForm
            // 
            this.rTBMelodyNoteForm.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rTBMelodyNoteForm.Location = new System.Drawing.Point(482, 71);
            this.rTBMelodyNoteForm.Name = "rTBMelodyNoteForm";
            this.rTBMelodyNoteForm.Size = new System.Drawing.Size(587, 407);
            this.rTBMelodyNoteForm.TabIndex = 17;
            this.rTBMelodyNoteForm.Text = "";
            // 
            // btnCreateMelody
            // 
            this.btnCreateMelody.Location = new System.Drawing.Point(235, 14);
            this.btnCreateMelody.Name = "btnCreateMelody";
            this.btnCreateMelody.Size = new System.Drawing.Size(56, 51);
            this.btnCreateMelody.TabIndex = 15;
            this.btnCreateMelody.Text = "Create";
            this.btnCreateMelody.UseVisualStyleBackColor = true;
            this.btnCreateMelody.Click += new System.EventHandler(this.btnCreateMelody_Click);
            // 
            // rTBMelody
            // 
            this.rTBMelody.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rTBMelody.Location = new System.Drawing.Point(3, 71);
            this.rTBMelody.Name = "rTBMelody";
            this.rTBMelody.Size = new System.Drawing.Size(473, 407);
            this.rTBMelody.TabIndex = 16;
            this.rTBMelody.Text = "";
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(640, 14);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(67, 50);
            this.btnPlay.TabIndex = 18;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 615);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVProcedure)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ComboBox cBStyle;
        private System.Windows.Forms.Label lblStyle;
        private System.Windows.Forms.ComboBox cBKeyQuality;
        private System.Windows.Forms.ComboBox cBKeyTonic;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.Label lblHarmonicNotes;
        private System.Windows.Forms.TextBox tBMaxNoteRepeat;
        private System.Windows.Forms.Label lblMaxNoteRepeat;
        private System.Windows.Forms.TextBox tBRange;
        private System.Windows.Forms.Label lblExtraNotes;
        private System.Windows.Forms.Label lblRange;
        private System.Windows.Forms.TextBox tBHarmonicNotes;
        private System.Windows.Forms.TextBox tBMaxInterval;
        private System.Windows.Forms.TextBox tBExtraNotes;
        private System.Windows.Forms.Label lblMaxInterval;
        private System.Windows.Forms.RichTextBox rTBMelodyNoteForm;
        private System.Windows.Forms.Button btnCreateMelody;
        private System.Windows.Forms.RichTextBox rTBMelody;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rTBThemeBHarmony;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rTBThemeAHarmony;
        private System.Windows.Forms.TextBox tBMaxIntervalBtnThemes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView dGVProcedure;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button btnPlay;
    }
}

