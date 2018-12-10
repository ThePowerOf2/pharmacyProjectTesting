using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemEntities {
    public class Warning : IWarning{
        #region Warning Variables
        private string warningNo;
        private string warning;
        #endregion

        #region IWarning Variables
        public string WarningNo { get { return warningNo; } set { warningNo = value; } }
        public string theWarning { get { return warning; } set { warning = value; } }
        #endregion

        #region Constructors
        public Warning() {
            throw new System.NotImplementedException();
        }

        public Warning(string warningNo, string warning) {
            this.warningNo = warningNo;
            this.warning = warning;
        }
        #endregion
    }
}