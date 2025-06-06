using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB6249B
{
    public class R0340_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1 : QueryBasis<R0340_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT(*)
            INTO :WSHOST-COUNT:VIND-NULL02
            FROM SEGUROS.MOVIMENTO_COBRANCA
            WHERE COD_BANCO =
            :MOVIMCOB-COD-BANCO
            AND COD_AGENCIA =
            :MOVIMCOB-COD-AGENCIA
            AND NUM_AVISO =
            :MOVIMCOB-NUM-AVISO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COUNT(*)
											FROM SEGUROS.MOVIMENTO_COBRANCA
											WHERE COD_BANCO =
											'{this.MOVIMCOB_COD_BANCO}'
											AND COD_AGENCIA =
											'{this.MOVIMCOB_COD_AGENCIA}'
											AND NUM_AVISO =
											'{this.MOVIMCOB_NUM_AVISO}'
											WITH UR";

            return query;
        }
        public string WSHOST_COUNT { get; set; }
        public string VIND_NULL02 { get; set; }
        public string MOVIMCOB_COD_AGENCIA { get; set; }
        public string MOVIMCOB_COD_BANCO { get; set; }
        public string MOVIMCOB_NUM_AVISO { get; set; }

        public static R0340_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1 Execute(R0340_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1 r0340_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1)
        {
            var ths = r0340_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0340_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0340_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1();
            var i = 0;
            dta.WSHOST_COUNT = result[i++].Value?.ToString();
            dta.VIND_NULL02 = string.IsNullOrWhiteSpace(dta.WSHOST_COUNT) ? "-1" : "0";
            return dta;
        }

    }
}