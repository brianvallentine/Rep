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
    public class P2111_00_VALIDA_APOLICE_DB_SELECT_5_Query1 : QueryBasis<P2111_00_VALIDA_APOLICE_DB_SELECT_5_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*),+0)
            INTO :WS-QT-SINISTRO
            FROM SEGUROS.SINISTRO_MESTRE
            WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE
            AND SIT_REGISTRO NOT IN ( '2' )
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							,+0)
											FROM SEGUROS.SINISTRO_MESTRE
											WHERE NUM_APOLICE = '{this.PARCEHIS_NUM_APOLICE}'
											AND SIT_REGISTRO NOT IN ( '2' )
											WITH UR";

            return query;
        }
        public string WS_QT_SINISTRO { get; set; }
        public string PARCEHIS_NUM_APOLICE { get; set; }

        public static P2111_00_VALIDA_APOLICE_DB_SELECT_5_Query1 Execute(P2111_00_VALIDA_APOLICE_DB_SELECT_5_Query1 p2111_00_VALIDA_APOLICE_DB_SELECT_5_Query1)
        {
            var ths = p2111_00_VALIDA_APOLICE_DB_SELECT_5_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P2111_00_VALIDA_APOLICE_DB_SELECT_5_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P2111_00_VALIDA_APOLICE_DB_SELECT_5_Query1();
            var i = 0;
            dta.WS_QT_SINISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}