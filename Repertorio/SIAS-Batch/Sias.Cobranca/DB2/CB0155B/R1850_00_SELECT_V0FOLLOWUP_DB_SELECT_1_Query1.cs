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
    public class R1850_00_SELECT_V0FOLLOWUP_DB_SELECT_1_Query1 : QueryBasis<R1850_00_SELECT_V0FOLLOWUP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SUM(VAL_OPERACAO)
            INTO :FOLLOUP-VAL-OPERACAO:VIND-ORIGEM
            FROM SEGUROS.FOLLOW_UP
            WHERE BCO_AVISO =
            :FOLLOUP-BCO-AVISO
            AND AGE_AVISO =
            :FOLLOUP-AGE-AVISO
            AND NUM_AVISO_CREDITO =
            :FOLLOUP-NUM-AVISO-CREDITO
            AND COD_OPERACAO IN (202,203,204,205,402)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SUM(VAL_OPERACAO)
											FROM SEGUROS.FOLLOW_UP
											WHERE BCO_AVISO =
											'{this.FOLLOUP_BCO_AVISO}'
											AND AGE_AVISO =
											'{this.FOLLOUP_AGE_AVISO}'
											AND NUM_AVISO_CREDITO =
											'{this.FOLLOUP_NUM_AVISO_CREDITO}'
											AND COD_OPERACAO IN (202
							,203
							,204
							,205
							,402)";

            return query;
        }
        public string FOLLOUP_VAL_OPERACAO { get; set; }
        public string VIND_ORIGEM { get; set; }
        public string FOLLOUP_NUM_AVISO_CREDITO { get; set; }
        public string FOLLOUP_BCO_AVISO { get; set; }
        public string FOLLOUP_AGE_AVISO { get; set; }

        public static R1850_00_SELECT_V0FOLLOWUP_DB_SELECT_1_Query1 Execute(R1850_00_SELECT_V0FOLLOWUP_DB_SELECT_1_Query1 r1850_00_SELECT_V0FOLLOWUP_DB_SELECT_1_Query1)
        {
            var ths = r1850_00_SELECT_V0FOLLOWUP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1850_00_SELECT_V0FOLLOWUP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1850_00_SELECT_V0FOLLOWUP_DB_SELECT_1_Query1();
            var i = 0;
            dta.FOLLOUP_VAL_OPERACAO = result[i++].Value?.ToString();
            dta.VIND_ORIGEM = string.IsNullOrWhiteSpace(dta.FOLLOUP_VAL_OPERACAO) ? "-1" : "0";
            return dta;
        }

    }
}