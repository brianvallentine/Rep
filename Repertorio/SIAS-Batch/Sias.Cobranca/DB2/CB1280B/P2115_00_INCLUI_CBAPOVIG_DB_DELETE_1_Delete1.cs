using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB1280B
{
    public class P2115_00_INCLUI_CBAPOVIG_DB_DELETE_1_Delete1 : QueryBasis<P2115_00_INCLUI_CBAPOVIG_DB_DELETE_1_Delete1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            DELETE
            FROM SEGUROS.CB_APOLICE_VIGPROP
            WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE
            END-EXEC
            */
            #endregion
            var query = @$"
				DELETE
				FROM SEGUROS.CB_APOLICE_VIGPROP
				WHERE NUM_APOLICE = '{this.PARCEHIS_NUM_APOLICE}'";

            return query;
        }
        public string PARCEHIS_NUM_APOLICE { get; set; }

        public static void Execute(P2115_00_INCLUI_CBAPOVIG_DB_DELETE_1_Delete1 p2115_00_INCLUI_CBAPOVIG_DB_DELETE_1_Delete1)
        {
            var ths = p2115_00_INCLUI_CBAPOVIG_DB_DELETE_1_Delete1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override P2115_00_INCLUI_CBAPOVIG_DB_DELETE_1_Delete1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}