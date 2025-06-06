using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0155B
{
    public class R1910_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1 : QueryBasis<R1910_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SUM(VAL_RCAP)
            INTO :RCAPCOMP-VAL-RCAP:VIND-ORIGEM
            FROM SEGUROS.RCAP_COMPLEMENTAR
            WHERE BCO_AVISO =
            :RCAPCOMP-BCO-AVISO
            AND AGE_AVISO =
            :RCAPCOMP-AGE-AVISO
            AND NUM_AVISO_CREDITO =
            :RCAPCOMP-NUM-AVISO-CREDITO
            AND COD_OPERACAO = 310
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SUM(VAL_RCAP)
											FROM SEGUROS.RCAP_COMPLEMENTAR
											WHERE BCO_AVISO =
											'{this.RCAPCOMP_BCO_AVISO}'
											AND AGE_AVISO =
											'{this.RCAPCOMP_AGE_AVISO}'
											AND NUM_AVISO_CREDITO =
											'{this.RCAPCOMP_NUM_AVISO_CREDITO}'
											AND COD_OPERACAO = 310";

            return query;
        }
        public string RCAPCOMP_VAL_RCAP { get; set; }
        public string VIND_ORIGEM { get; set; }
        public string RCAPCOMP_NUM_AVISO_CREDITO { get; set; }
        public string RCAPCOMP_BCO_AVISO { get; set; }
        public string RCAPCOMP_AGE_AVISO { get; set; }

        public static R1910_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1 Execute(R1910_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1 r1910_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1)
        {
            var ths = r1910_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1910_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1910_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1();
            var i = 0;
            dta.RCAPCOMP_VAL_RCAP = result[i++].Value?.ToString();
            dta.VIND_ORIGEM = string.IsNullOrWhiteSpace(dta.RCAPCOMP_VAL_RCAP) ? "-1" : "0";
            return dta;
        }

    }
}