using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI5000B
{
    public class R105_00_VER_COBRANCA_SUSP_DB_SELECT_1_Query1 : QueryBasis<R105_00_VER_COBRANCA_SUSP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*),0)
            INTO :WS-CONTADOR
            FROM SEGUROS.LOTERICO01
            WHERE COD_LOT_FENAL = :SINILT01-COD-LOT-CEF
            AND OPCAO_DEP = 'S'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							,0)
											FROM SEGUROS.LOTERICO01
											WHERE COD_LOT_FENAL = '{this.SINILT01_COD_LOT_CEF}'
											AND OPCAO_DEP = 'S'";

            return query;
        }
        public string WS_CONTADOR { get; set; }
        public string SINILT01_COD_LOT_CEF { get; set; }

        public static R105_00_VER_COBRANCA_SUSP_DB_SELECT_1_Query1 Execute(R105_00_VER_COBRANCA_SUSP_DB_SELECT_1_Query1 r105_00_VER_COBRANCA_SUSP_DB_SELECT_1_Query1)
        {
            var ths = r105_00_VER_COBRANCA_SUSP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R105_00_VER_COBRANCA_SUSP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R105_00_VER_COBRANCA_SUSP_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_CONTADOR = result[i++].Value?.ToString();
            return dta;
        }

    }
}