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
    public class R1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_2_Query1 : QueryBasis<R1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*), 0)
            INTO :HOST-COUNT
            FROM SEGUROS.SINISTRO_HISTORICO
            WHERE NUM_APOL_SINISTRO = :SIARDEVC-NUM-APOL-SINISTRO
            AND OCORR_HISTORICO = :SIARDEVC-OCORR-HISTORICO
            AND COD_OPERACAO = :SIARDEVC-COD-OPERACAO
            AND SIT_CONTABIL = '1'
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							, 0)
											FROM SEGUROS.SINISTRO_HISTORICO
											WHERE NUM_APOL_SINISTRO = '{this.SIARDEVC_NUM_APOL_SINISTRO}'
											AND OCORR_HISTORICO = '{this.SIARDEVC_OCORR_HISTORICO}'
											AND COD_OPERACAO = '{this.SIARDEVC_COD_OPERACAO}'
											AND SIT_CONTABIL = '1'";

            return query;
        }
        public string HOST_COUNT { get; set; }
        public string SIARDEVC_NUM_APOL_SINISTRO { get; set; }
        public string SIARDEVC_OCORR_HISTORICO { get; set; }
        public string SIARDEVC_COD_OPERACAO { get; set; }

        public static R1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_2_Query1 Execute(R1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_2_Query1 r1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_2_Query1)
        {
            var ths = r1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_2_Query1();
            var i = 0;
            dta.HOST_COUNT = result[i++].Value?.ToString();
            return dta;
        }

    }
}