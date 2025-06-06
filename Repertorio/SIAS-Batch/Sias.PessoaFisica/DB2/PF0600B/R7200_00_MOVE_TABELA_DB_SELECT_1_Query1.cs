using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0600B
{
    public class R7200_00_MOVE_TABELA_DB_SELECT_1_Query1 : QueryBasis<R7200_00_MOVE_TABELA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(DISTINCT DTINIVIG),0)
            INTO :WS-QTD
            FROM SEGUROS.PLANOS_VA_VGAP
            WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE
            AND CODSUBES = :SUBGVGAP-COD-SUBGRUPO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(DISTINCT DTINIVIG)
							,0)
											FROM SEGUROS.PLANOS_VA_VGAP
											WHERE NUM_APOLICE = '{this.SUBGVGAP_NUM_APOLICE}'
											AND CODSUBES = '{this.SUBGVGAP_COD_SUBGRUPO}'
											WITH UR";

            return query;
        }
        public string WS_QTD { get; set; }
        public string SUBGVGAP_COD_SUBGRUPO { get; set; }
        public string SUBGVGAP_NUM_APOLICE { get; set; }

        public static R7200_00_MOVE_TABELA_DB_SELECT_1_Query1 Execute(R7200_00_MOVE_TABELA_DB_SELECT_1_Query1 r7200_00_MOVE_TABELA_DB_SELECT_1_Query1)
        {
            var ths = r7200_00_MOVE_TABELA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R7200_00_MOVE_TABELA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R7200_00_MOVE_TABELA_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_QTD = result[i++].Value?.ToString();
            return dta;
        }

    }
}