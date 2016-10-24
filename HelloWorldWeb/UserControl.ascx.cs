using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloWorldWeb
{
    public partial class UserControl : System.Web.UI.UserControl
    {
        private int _minValue;
        private int _maxValue = 100;
        private int _currentNumber = 0;

        public int MinValue
        {
            get { return _minValue; }
            set
            {
                if (value > +this.MaxValue)
                    throw new Exception("MinValue must be less than MaxValue.");
                else
                {
                    _minValue = value;
                }
            }
        }

        public int MaxValue
        {
            get { return _maxValue;  }
            set
            {
                if (value <= this.MinValue)
                    throw new Exception("MaxValue must be greater than MinValue.");
                else
                {
                    _maxValue = value;
                }
            }
        }

        public int CurrentNumber
        {
            get { return _currentNumber; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                _currentNumber = Int32.Parse(ViewState["currentNumber"].ToString());
            }
            else
            {
                _currentNumber = this.MinValue;
            }
            DisplayNumber();
        }

        protected void DisplayNumber()
        {
            txtNumber.Text = this.CurrentNumber.ToString();
            ViewState["currentNumber"] = this.CurrentNumber.ToString();
        }

        protected void btnUp_Click(object sender, EventArgs e)
        {
            if(_currentNumber == this.MaxValue)
                _currentNumber = this.MinValue;
                else
                _currentNumber++;
                DisplayNumber();
            }

    

        protected void btnDown_Click(object sender, EventArgs e)
        {
            if (_currentNumber == this.MinValue)
                _currentNumber = this.MaxValue;
                else
                _currentNumber--;
                DisplayNumber();
        }
    }
}
