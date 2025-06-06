using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0531S
{
    public class R1100_00_BUSCAR_ULT_SEQ_DB_SELECT_1_Query1 : QueryBasis<R1100_00_BUSCAR_ULT_SEQ_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MAX(SEQ_REGISTRO)
            INTO :WS-SEQ-PESSOA-LOG
            FROM SIUS.GE_PESSOA_VALIDA_LOG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT MAX(SEQ_REGISTRO)
											FROM SIUS.GE_PESSOA_VALIDA_LOG";

            return query;
        }
        public string WS_SEQ_PESSOA_LOG { get; set; }

        public static R1100_00_BUSCAR_ULT_SEQ_DB_SELECT_1_Query1 Execute(R1100_00_BUSCAR_ULT_SEQ_DB_SELECT_1_Query1 r1100_00_BUSCAR_ULT_SEQ_DB_SELECT_1_Query1)
        {
            var ths = r1100_00_BUSCAR_ULT_SEQ_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_BUSCAR_ULT_SEQ_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_BUSCAR_ULT_SEQ_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_SEQ_PESSOA_LOG = result[i++].Value?.ToString();
            return dta;
        }

    }
}