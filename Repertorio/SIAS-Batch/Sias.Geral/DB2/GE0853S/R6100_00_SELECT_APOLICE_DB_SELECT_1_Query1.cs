using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0853S
{
    public class R6100_00_SELECT_APOLICE_DB_SELECT_1_Query1 : QueryBasis<R6100_00_SELECT_APOLICE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_MODALIDADE
            INTO :APOLICES-COD-MODALIDADE
            FROM SEGUROS.APOLICES
            WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_MODALIDADE
											FROM SEGUROS.APOLICES
											WHERE NUM_APOLICE = '{this.V0PROP_NUM_APOLICE}'
											WITH UR";

            return query;
        }
        public string APOLICES_COD_MODALIDADE { get; set; }
        public string V0PROP_NUM_APOLICE { get; set; }

        public static R6100_00_SELECT_APOLICE_DB_SELECT_1_Query1 Execute(R6100_00_SELECT_APOLICE_DB_SELECT_1_Query1 r6100_00_SELECT_APOLICE_DB_SELECT_1_Query1)
        {
            var ths = r6100_00_SELECT_APOLICE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R6100_00_SELECT_APOLICE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R6100_00_SELECT_APOLICE_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICES_COD_MODALIDADE = result[i++].Value?.ToString();
            return dta;
        }

    }
}