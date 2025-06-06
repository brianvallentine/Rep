using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB7537B
{
    public class R0520_00_SELECT_SINISMES_DB_SELECT_1_Query1 : QueryBasis<R0520_00_SELECT_SINISMES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.COD_FONTE ,
            B.COD_PRODUTO ,
            B.RAMO_EMISSOR
            INTO :SINISMES-COD-FONTE ,
            :PRODUTO-COD-PRODUTO ,
            :PRODUTO-RAMO-EMISSOR
            FROM SEGUROS.SINISTRO_MESTRE A,
            SEGUROS.PRODUTO B
            WHERE A.NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO
            AND A.COD_PRODUTO = B.COD_PRODUTO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.COD_FONTE 
							,
											B.COD_PRODUTO 
							,
											B.RAMO_EMISSOR
											FROM SEGUROS.SINISTRO_MESTRE A
							,
											SEGUROS.PRODUTO B
											WHERE A.NUM_APOL_SINISTRO = '{this.SINISMES_NUM_APOL_SINISTRO}'
											AND A.COD_PRODUTO = B.COD_PRODUTO
											WITH UR";

            return query;
        }
        public string SINISMES_COD_FONTE { get; set; }
        public string PRODUTO_COD_PRODUTO { get; set; }
        public string PRODUTO_RAMO_EMISSOR { get; set; }
        public string SINISMES_NUM_APOL_SINISTRO { get; set; }

        public static R0520_00_SELECT_SINISMES_DB_SELECT_1_Query1 Execute(R0520_00_SELECT_SINISMES_DB_SELECT_1_Query1 r0520_00_SELECT_SINISMES_DB_SELECT_1_Query1)
        {
            var ths = r0520_00_SELECT_SINISMES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0520_00_SELECT_SINISMES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0520_00_SELECT_SINISMES_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISMES_COD_FONTE = result[i++].Value?.ToString();
            dta.PRODUTO_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PRODUTO_RAMO_EMISSOR = result[i++].Value?.ToString();
            return dta;
        }

    }
}