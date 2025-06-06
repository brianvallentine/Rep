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
    public class R6110_00_INCLUI_AUTO_COMPL_DB_DELETE_1_Delete1 : QueryBasis<R6110_00_INCLUI_AUTO_COMPL_DB_DELETE_1_Delete1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            DELETE FROM SEGUROS.PARCELA_AUTO_COMPL
            WHERE NUM_APOLICE = :AU071-NUM-APOLICE
            AND NUM_ENDOSSO = :AU071-NUM-ENDOSSO
            AND NUM_PARCELA = :AU071-NUM-PARCELA
            AND NUM_VENCTO = :AU071-NUM-VENCTO
            END-EXEC
            */
            #endregion
            var query = @$"
				DELETE FROM SEGUROS.PARCELA_AUTO_COMPL
				WHERE NUM_APOLICE = '{this.AU071_NUM_APOLICE}'
				AND NUM_ENDOSSO = '{this.AU071_NUM_ENDOSSO}'
				AND NUM_PARCELA = '{this.AU071_NUM_PARCELA}'
				AND NUM_VENCTO = '{this.AU071_NUM_VENCTO}'";

            return query;
        }
        public string AU071_NUM_APOLICE { get; set; }
        public string AU071_NUM_ENDOSSO { get; set; }
        public string AU071_NUM_PARCELA { get; set; }
        public string AU071_NUM_VENCTO { get; set; }

        public static void Execute(R6110_00_INCLUI_AUTO_COMPL_DB_DELETE_1_Delete1 r6110_00_INCLUI_AUTO_COMPL_DB_DELETE_1_Delete1)
        {
            var ths = r6110_00_INCLUI_AUTO_COMPL_DB_DELETE_1_Delete1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R6110_00_INCLUI_AUTO_COMPL_DB_DELETE_1_Delete1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}