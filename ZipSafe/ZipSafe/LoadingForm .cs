using System;
using System.Drawing;
using System.Windows.Forms;

namespace ZipSafe
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
            SetRoundedCorners(); // Apply rounded corners
            this.Resize += LoadingForm_Resize; // Adjust rounded corners on resize
        }

        /// <summary>
        /// Adjust rounded corners when the form is resized.
        /// </summary>
        private void LoadingForm_Resize(object sender, EventArgs e)
        {
            SetRoundedCorners();
        }

        /// <summary>
        /// Sets rounded corners for the form.
        /// </summary>
        private void SetRoundedCorners()
        {
            int radius = 30; // Radius for rounded corners
            var path = new System.Drawing.Drawing2D.GraphicsPath();

            // Define arcs for each corner
            path.AddArc(0, 0, radius, radius, 180, 90); // Top-left
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90); // Top-right
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90); // Bottom-right
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90); // Bottom-left
            path.CloseFigure();

            this.Region = new Region(path); // Apply rounded region
        }

        /// <summary>
        /// Updates the status message and progress bar value.
        /// </summary>
        /// <param name="message">Status message to display.</param>
        /// <param name="progress">Progress percentage (0-100).</param>
        public void UpdateStatus(string message, int progress = 0)
        {
            if (label1 != null)
            {
                label1.Text = message; // Update status message
                label1.Refresh(); // Redraw label
            }

            if (progressBar1 != null)
            {
                progressBar1.Value = progress; // Update progress bar
                progressBar1.Refresh(); // Redraw progress bar
            }
        }
    }
}
