namespace Aug20
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            homeToolStripMenuItem = new ToolStripMenuItem();
            openHomeToolStripMenuItem = new ToolStripMenuItem();
            menu2ToolStripMenuItem = new ToolStripMenuItem();
            aboutUsToolStripMenuItem = new ToolStripMenuItem();
            openAboutUsToolStripMenuItem = new ToolStripMenuItem();
            aboutUs2ToolStripMenuItem = new ToolStripMenuItem();
            menuToolStripMenuItem = new ToolStripMenuItem();
            openMenuToolStripMenuItem = new ToolStripMenuItem();
            menu2ToolStripMenuItem1 = new ToolStripMenuItem();
            contactUsToolStripMenuItem = new ToolStripMenuItem();
            openContactUsToolStripMenuItem = new ToolStripMenuItem();
            contactUs2ToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { homeToolStripMenuItem, aboutUsToolStripMenuItem, menuToolStripMenuItem, contactUsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(880, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            homeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openHomeToolStripMenuItem, menu2ToolStripMenuItem });
            homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            homeToolStripMenuItem.Size = new Size(52, 20);
            homeToolStripMenuItem.Text = "Home";
            homeToolStripMenuItem.Click += homeToolStripMenuItem_Click;
            // 
            // openHomeToolStripMenuItem
            // 
            openHomeToolStripMenuItem.Name = "openHomeToolStripMenuItem";
            openHomeToolStripMenuItem.Size = new Size(139, 22);
            openHomeToolStripMenuItem.Text = "Open Home";
            openHomeToolStripMenuItem.Click += openHomeToolStripMenuItem_Click;
            // 
            // menu2ToolStripMenuItem
            // 
            menu2ToolStripMenuItem.Name = "menu2ToolStripMenuItem";
            menu2ToolStripMenuItem.Size = new Size(139, 22);
            menu2ToolStripMenuItem.Text = "Menu 2";
            // 
            // aboutUsToolStripMenuItem
            // 
            aboutUsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openAboutUsToolStripMenuItem, aboutUs2ToolStripMenuItem });
            aboutUsToolStripMenuItem.Name = "aboutUsToolStripMenuItem";
            aboutUsToolStripMenuItem.Size = new Size(68, 20);
            aboutUsToolStripMenuItem.Text = "About Us";
            aboutUsToolStripMenuItem.Click += aboutUsToolStripMenuItem_Click;
            // 
            // openAboutUsToolStripMenuItem
            // 
            openAboutUsToolStripMenuItem.Name = "openAboutUsToolStripMenuItem";
            openAboutUsToolStripMenuItem.Size = new Size(155, 22);
            openAboutUsToolStripMenuItem.Text = "Open About Us";
            openAboutUsToolStripMenuItem.Click += openAboutUsToolStripMenuItem_Click;
            // 
            // aboutUs2ToolStripMenuItem
            // 
            aboutUs2ToolStripMenuItem.Name = "aboutUs2ToolStripMenuItem";
            aboutUs2ToolStripMenuItem.Size = new Size(155, 22);
            aboutUs2ToolStripMenuItem.Text = "About Us 2";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openMenuToolStripMenuItem, menu2ToolStripMenuItem1 });
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(50, 20);
            menuToolStripMenuItem.Text = "Menu";
            menuToolStripMenuItem.Click += menuToolStripMenuItem_Click;
            // 
            // openMenuToolStripMenuItem
            // 
            openMenuToolStripMenuItem.Name = "openMenuToolStripMenuItem";
            openMenuToolStripMenuItem.Size = new Size(137, 22);
            openMenuToolStripMenuItem.Text = "Open Menu";
            openMenuToolStripMenuItem.Click += openMenuToolStripMenuItem_Click;
            // 
            // menu2ToolStripMenuItem1
            // 
            menu2ToolStripMenuItem1.Name = "menu2ToolStripMenuItem1";
            menu2ToolStripMenuItem1.Size = new Size(137, 22);
            menu2ToolStripMenuItem1.Text = "Menu 2";
            // 
            // contactUsToolStripMenuItem
            // 
            contactUsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openContactUsToolStripMenuItem, contactUs2ToolStripMenuItem });
            contactUsToolStripMenuItem.Name = "contactUsToolStripMenuItem";
            contactUsToolStripMenuItem.Size = new Size(77, 20);
            contactUsToolStripMenuItem.Text = "Contact Us";
            contactUsToolStripMenuItem.Click += contactUsToolStripMenuItem_Click;
            // 
            // openContactUsToolStripMenuItem
            // 
            openContactUsToolStripMenuItem.Name = "openContactUsToolStripMenuItem";
            openContactUsToolStripMenuItem.Size = new Size(180, 22);
            openContactUsToolStripMenuItem.Text = "Open Contact Us";
            openContactUsToolStripMenuItem.Click += openContactUsToolStripMenuItem_Click;
            // 
            // contactUs2ToolStripMenuItem
            // 
            contactUs2ToolStripMenuItem.Name = "contactUs2ToolStripMenuItem";
            contactUs2ToolStripMenuItem.Size = new Size(180, 22);
            contactUs2ToolStripMenuItem.Text = "Contact Us 2";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 599);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Main";
            Text = "Main";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem homeToolStripMenuItem;
        private ToolStripMenuItem aboutUsToolStripMenuItem;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem contactUsToolStripMenuItem;
        private ToolStripMenuItem menu2ToolStripMenuItem;
        private ToolStripMenuItem openHomeToolStripMenuItem;
        private ToolStripMenuItem openAboutUsToolStripMenuItem;
        private ToolStripMenuItem aboutUs2ToolStripMenuItem;
        private ToolStripMenuItem openMenuToolStripMenuItem;
        private ToolStripMenuItem menu2ToolStripMenuItem1;
        private ToolStripMenuItem openContactUsToolStripMenuItem;
        private ToolStripMenuItem contactUs2ToolStripMenuItem;
    }
}
