﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicalAPIWand
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { 
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "https://github.com/git102347501/MagicalAPIWand",
                UseShellExecute = true
            };
            Process.Start(startInfo);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "https://github.com/git102347501",
                UseShellExecute = true
            };
            Process.Start(startInfo); 
        }
    }
}
