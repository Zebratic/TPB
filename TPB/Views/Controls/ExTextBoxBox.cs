using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace HTX_NINJA.Views.Controls
{
    /// <summary>
    /// Represents a windows text box control with extended functionality
    /// </summary>
    class ExTextBoxBox : TextBox, INotifyPropertyChanged
    {
        private bool _shouldSelectAll = true;

        private bool _hasText;
        /// <summary>
        /// Gets or sets whether the TextBox contains text
        /// </summary>
        [Browsable(false)]
        [Bindable(true)]
        public bool HasText
        {
            get { return _hasText; }
            set
            {
                if (value == _hasText) return;
                _hasText = value;
                OnPropertyChanged("HasText");
            }
        }

        /// <summary>
        /// Gets or sets whether the textBox quickly selects all of its text on enter
        /// </summary>
        [DefaultValue(true)]
        [Category("Behavior")]
        [Description("Whether the textBox quickly selects all of its text on enter")]
        public bool QuickSelect { get; set; }

        public ExTextBoxBox()
        {
            QuickSelect = true; // Defaulted to true
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            HasText = TextLength > 0;
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);

            if (QuickSelect && _shouldSelectAll)
            {
                SelectAll();
                _shouldSelectAll = false;
            }
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            _shouldSelectAll = true;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            HasText = TextLength > 0;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            // By default, I cannot select all when readonly is set
            if (e.KeyCode == Keys.A && e.Control && ReadOnly)
                SelectAll();
        }

        /// <summary>
        /// Occurs when a bindable property has changed
        /// </summary>
        [Browsable(false)]
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Raises the PropertyChanged event
        /// </summary>
        /// <param name="propertyName">The name of the property that has changed</param>
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                var args = new PropertyChangedEventArgs(propertyName);
                PropertyChanged(this, args);
            }
        }
    }
}
