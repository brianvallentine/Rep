using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0811B
{
    public class R0500_00_SELECT_SINISMES_DB_SELECT_1_Query1 : QueryBasis<R0500_00_SELECT_SINISMES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE,
            COD_PRODUTO
            INTO :SINISMES-NUM-APOLICE,
            :SINISMES-COD-PRODUTO
            FROM SEGUROS.SINISTRO_MESTRE
            WHERE NUM_APOL_SINISTRO = :COSHISSI-NUM-SINISTRO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
							,
											COD_PRODUTO
											FROM SEGUROS.SINISTRO_MESTRE
											WHERE NUM_APOL_SINISTRO = '{this.COSHISSI_NUM_SINISTRO}'
											WITH UR";

            return query;
        }
        public string SINISMES_NUM_APOLICE { get; set; }
        public string SINISMES_COD_PRODUTO { get; set; }
        public string COSHISSI_NUM_SINISTRO { get; set; }

        public static R0500_00_SELECT_SINISMES_DB_SELECT_1_Query1 Execute(R0500_00_SELECT_SINISMES_DB_SELECT_1_Query1 r0500_00_SELECT_SINISMES_DB_SELECT_1_Query1)
        {
            var ths = r0500_00_SELECT_SINISMES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0500_00_SELECT_SINISMES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0500_00_SELECT_SINISMES_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISMES_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SINISMES_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}