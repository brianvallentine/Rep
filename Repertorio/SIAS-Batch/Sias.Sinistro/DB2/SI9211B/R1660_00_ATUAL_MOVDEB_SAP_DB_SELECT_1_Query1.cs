using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9211B
{
    public class R1660_00_ATUAL_MOVDEB_SAP_DB_SELECT_1_Query1 : QueryBasis<R1660_00_ATUAL_MOVDEB_SAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*), 0)
            INTO :HOST-COUNT
            FROM SEGUROS.GE_MOVDEBCE_SAP
            WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE
            AND NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO
            AND NUM_PARCELA = :MOVDEBCE-NUM-PARCELA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							, 0)
											FROM SEGUROS.GE_MOVDEBCE_SAP
											WHERE NUM_APOLICE = '{this.MOVDEBCE_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.MOVDEBCE_NUM_ENDOSSO}'
											AND NUM_PARCELA = '{this.MOVDEBCE_NUM_PARCELA}'";

            return query;
        }
        public string HOST_COUNT { get; set; }
        public string MOVDEBCE_NUM_APOLICE { get; set; }
        public string MOVDEBCE_NUM_ENDOSSO { get; set; }
        public string MOVDEBCE_NUM_PARCELA { get; set; }

        public static R1660_00_ATUAL_MOVDEB_SAP_DB_SELECT_1_Query1 Execute(R1660_00_ATUAL_MOVDEB_SAP_DB_SELECT_1_Query1 r1660_00_ATUAL_MOVDEB_SAP_DB_SELECT_1_Query1)
        {
            var ths = r1660_00_ATUAL_MOVDEB_SAP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1660_00_ATUAL_MOVDEB_SAP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1660_00_ATUAL_MOVDEB_SAP_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_COUNT = result[i++].Value?.ToString();
            return dta;
        }

    }
}