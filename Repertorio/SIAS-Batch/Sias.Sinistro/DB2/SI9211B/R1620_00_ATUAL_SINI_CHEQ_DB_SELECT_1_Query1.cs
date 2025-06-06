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
    public class R1620_00_ATUAL_SINI_CHEQ_DB_SELECT_1_Query1 : QueryBasis<R1620_00_ATUAL_SINI_CHEQ_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*), 0)
            INTO :HOST-COUNT
            FROM SEGUROS.SI_SINI_CHEQUE
            WHERE NUM_APOL_SINISTRO = :SIARDEVC-NUM-APOL-SINISTRO
            AND OCORR_HISTORICO = :SIARDEVC-OCORR-HISTORICO
            AND COD_OPERACAO = :SIARDEVC-COD-OPERACAO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							, 0)
											FROM SEGUROS.SI_SINI_CHEQUE
											WHERE NUM_APOL_SINISTRO = '{this.SIARDEVC_NUM_APOL_SINISTRO}'
											AND OCORR_HISTORICO = '{this.SIARDEVC_OCORR_HISTORICO}'
											AND COD_OPERACAO = '{this.SIARDEVC_COD_OPERACAO}'";

            return query;
        }
        public string HOST_COUNT { get; set; }
        public string SIARDEVC_NUM_APOL_SINISTRO { get; set; }
        public string SIARDEVC_OCORR_HISTORICO { get; set; }
        public string SIARDEVC_COD_OPERACAO { get; set; }

        public static R1620_00_ATUAL_SINI_CHEQ_DB_SELECT_1_Query1 Execute(R1620_00_ATUAL_SINI_CHEQ_DB_SELECT_1_Query1 r1620_00_ATUAL_SINI_CHEQ_DB_SELECT_1_Query1)
        {
            var ths = r1620_00_ATUAL_SINI_CHEQ_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1620_00_ATUAL_SINI_CHEQ_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1620_00_ATUAL_SINI_CHEQ_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_COUNT = result[i++].Value?.ToString();
            return dta;
        }

    }
}