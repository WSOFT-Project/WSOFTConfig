using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSOFT.Config.UI
{
    internal class LimitedTextbox : System.Windows.Forms.TextBox
    {


        #region　コンストラクタ

        public LimitedTextbox()
        {
            this.PermitChars = new char[] { };
        }

        #endregion


        #region　PermitChars プロパティ

        private char[] _PermitChars;


        public char[] PermitChars
        {
            get
            {
                return this._PermitChars;
            }

            set
            {
                this._PermitChars = value;
            }
        }

        #endregion


        #region　WndProc メソッド (override)

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            const int WM_CHAR = 0x0102;
            const int WM_PASTE = 0x0302;

            switch (m.Msg)
            {
                case WM_CHAR:
                    if ((this.PermitChars != null) && (this.PermitChars.Length > 0))
                    {
                        KeyPressEventArgs eKeyPress = new KeyPressEventArgs((char)(m.WParam.ToInt32()));
                        this.OnChar(eKeyPress);

                        if (eKeyPress.Handled)
                        {
                            return;
                        }
                    }
                    break;
                case WM_PASTE:
                    if ((this.PermitChars != null) && (this.PermitChars.Length > 0))
                    {
                        this.OnPaste(new System.EventArgs());
                        return;
                    }
                    break;
            }

            base.WndProc(ref m);
        }

        #endregion


        #region　OnChar メソッド (virtual)

        protected virtual void OnChar(KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            if (!HasPermitChars(e.KeyChar, this.PermitChars))
            {
                e.Handled = true;
            }
        }

        #endregion


        #region　OnPaste メソッド (virtual)

        protected virtual void OnPaste(System.EventArgs e)
        {
            string stString = Clipboard.GetDataObject().GetData(System.Windows.Forms.DataFormats.Text).ToString();

            if (stString != null)
            {
                this.SelectedText = GetPermitedString(stString, this.PermitChars);
            }
        }

        #endregion


        #region　[S] HasPermitChars メソッド

        private static bool HasPermitChars(char chTarget, char[] chPermits)
        {
            foreach (char ch in chPermits)
            {
                if (chTarget == ch)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion


        #region　[S] GetPermitedString メソッド

        private static string GetPermitedString(string stTarget, char[] chPermits)
        {
            string stReturn = string.Empty;

            foreach (char chTarget in stTarget)
            {
                if (HasPermitChars(chTarget, chPermits))
                {
                    stReturn += chTarget;
                }
            }

            return stReturn;
        }

        #endregion

    }
}
