using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.SPBFC003
{
    public class P100_ACESSA_SEQUENCE_FC085SQ_DB_SEQUENCE_1_Query1 : QueryBasis<P100_ACESSA_SEQUENCE_FC085SQ_DB_SEQUENCE_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT NEXT VALUE FOR FDRCAP.FC085SQ INTO  :LK-OUT-NUM-SEQ-INI FROM SYSIBM.SYSDUMMY1 END-EXEC*/
            #endregion
            var query = @$"
				SELECT NEXT VALUE FOR FDRCAP.FC085SQ
							FROM SYSIBM.SYSDUMMY1";

            return query;
        }
        public string LK_OUT_NUM_SEQ_INI { get; set; }

        public static P100_ACESSA_SEQUENCE_FC085SQ_DB_SEQUENCE_1_Query1 Execute(P100_ACESSA_SEQUENCE_FC085SQ_DB_SEQUENCE_1_Query1 p100_ACESSA_SEQUENCE_FC085SQ_DB_SEQUENCE_1_Query1)
        {
            var ths = p100_ACESSA_SEQUENCE_FC085SQ_DB_SEQUENCE_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P100_ACESSA_SEQUENCE_FC085SQ_DB_SEQUENCE_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P100_ACESSA_SEQUENCE_FC085SQ_DB_SEQUENCE_1_Query1();
            var i = 0;
            dta.LK_OUT_NUM_SEQ_INI = result[i++].Value?.ToString();
            return dta;
        }

    }
}