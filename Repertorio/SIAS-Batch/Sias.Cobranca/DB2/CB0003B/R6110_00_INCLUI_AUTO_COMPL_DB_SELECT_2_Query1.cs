using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0003B
{
    public class R6110_00_INCLUI_AUTO_COMPL_DB_SELECT_2_Query1 : QueryBasis<R6110_00_INCLUI_AUTO_COMPL_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*),0)
            INTO :WS-QT-REG
            FROM SEGUROS.PARCELA_AUTO_COMPL
            WHERE NUM_APOLICE = :AU071-NUM-APOLICE
            AND NUM_ENDOSSO = :AU071-NUM-ENDOSSO
            AND NUM_PARCELA = :AU071-NUM-PARCELA
            AND NUM_VENCTO = :AU071-NUM-VENCTO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							,0)
											FROM SEGUROS.PARCELA_AUTO_COMPL
											WHERE NUM_APOLICE = '{this.AU071_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.AU071_NUM_ENDOSSO}'
											AND NUM_PARCELA = '{this.AU071_NUM_PARCELA}'
											AND NUM_VENCTO = '{this.AU071_NUM_VENCTO}'
											WITH UR";

            return query;
        }
        public string WS_QT_REG { get; set; }
        public string AU071_NUM_APOLICE { get; set; }
        public string AU071_NUM_ENDOSSO { get; set; }
        public string AU071_NUM_PARCELA { get; set; }
        public string AU071_NUM_VENCTO { get; set; }

        public static R6110_00_INCLUI_AUTO_COMPL_DB_SELECT_2_Query1 Execute(R6110_00_INCLUI_AUTO_COMPL_DB_SELECT_2_Query1 r6110_00_INCLUI_AUTO_COMPL_DB_SELECT_2_Query1)
        {
            var ths = r6110_00_INCLUI_AUTO_COMPL_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R6110_00_INCLUI_AUTO_COMPL_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R6110_00_INCLUI_AUTO_COMPL_DB_SELECT_2_Query1();
            var i = 0;
            dta.WS_QT_REG = result[i++].Value?.ToString();
            return dta;
        }

    }
}