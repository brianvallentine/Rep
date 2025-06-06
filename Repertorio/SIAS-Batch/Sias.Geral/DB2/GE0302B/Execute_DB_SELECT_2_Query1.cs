using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0302B
{
    public class Execute_DB_SELECT_2_Query1 : QueryBasis<Execute_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CHR_USO_EMPRESA
            INTO :GE113-CHR-USO-EMPRESA
            FROM SEGUROS.GE_FEBRABAN_USO_EMPRESA
            WHERE NUM_OCORR_MOVTO = :GE100-NUM-OCORR-MOVTO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CHR_USO_EMPRESA
											FROM SEGUROS.GE_FEBRABAN_USO_EMPRESA
											WHERE NUM_OCORR_MOVTO = '{this.GE100_NUM_OCORR_MOVTO}'";

            return query;
        }
        public string GE113_CHR_USO_EMPRESA { get; set; }
        public string GE100_NUM_OCORR_MOVTO { get; set; }

        public static Execute_DB_SELECT_2_Query1 Execute(Execute_DB_SELECT_2_Query1 execute_DB_SELECT_2_Query1)
        {
            var ths = execute_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override Execute_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new Execute_DB_SELECT_2_Query1();
            var i = 0;
            dta.GE113_CHR_USO_EMPRESA = result[i++].Value?.ToString();
            return dta;
        }

    }
}