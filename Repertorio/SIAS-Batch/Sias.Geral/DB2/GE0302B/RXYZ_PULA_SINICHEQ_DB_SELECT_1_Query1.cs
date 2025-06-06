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
    public class RXYZ_PULA_SINICHEQ_DB_SELECT_1_Query1 : QueryBasis<RXYZ_PULA_SINICHEQ_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CONVENIO
            INTO :GE094-COD-CONVENIO
            FROM SEGUROS.GE_MOVDEBCE_SAP
            WHERE NUM_OCORR_MOVTO = :GE100-NUM-OCORR-MOVTO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_CONVENIO
											FROM SEGUROS.GE_MOVDEBCE_SAP
											WHERE NUM_OCORR_MOVTO = '{this.GE100_NUM_OCORR_MOVTO}'";

            return query;
        }
        public string GE094_COD_CONVENIO { get; set; }
        public string GE100_NUM_OCORR_MOVTO { get; set; }

        public static RXYZ_PULA_SINICHEQ_DB_SELECT_1_Query1 Execute(RXYZ_PULA_SINICHEQ_DB_SELECT_1_Query1 rXYZ_PULA_SINICHEQ_DB_SELECT_1_Query1)
        {
            var ths = rXYZ_PULA_SINICHEQ_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override RXYZ_PULA_SINICHEQ_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new RXYZ_PULA_SINICHEQ_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE094_COD_CONVENIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}