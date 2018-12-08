using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProgramLogic.Model;

namespace TestProgramLogic
{
    class RowsComparer : IEqualityComparer<FileRow>
    {

        public bool Equals(FileRow x, FileRow y)
        {
            if (Object.ReferenceEquals(x, y)) return true;

            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            return x.DateTime == y.DateTime && x.Ask == y.Ask && x.Bid == y.Bid && x.CurrentCode == y.CurrentCode;
        }
        public int GetHashCode(FileRow row)
        {
            if (Object.ReferenceEquals(row, null)) return 0;
            int hashRowsName = row.DateTime == null ? 0 : row.DateTime.GetHashCode();
            int hashRowsCode = row.Ask.GetHashCode();
            return hashRowsName ^ hashRowsCode;
        }

    }
}
