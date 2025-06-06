using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9109B
{
    public class R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1 : QueryBasis<R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_SINISTRO_VC,
            NUM_EXPEDIENTE_VC,
            COD_COBERTURA
            INTO :HOST-NUM-SINISTRO-VC,
            :HOST-NUM-EXPEDIENTE-VC,
            :HOST-COD-COBERTURA
            FROM SEGUROS.SI_AR_DETALHE_VC
            WHERE NUM_APOL_SINISTRO = :SIARDEVC-NUM-APOL-SINISTRO
            AND COD_OPERACAO = 101
            AND STA_PROCESSAMENTO = '1'
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_SINISTRO_VC
							,
											NUM_EXPEDIENTE_VC
							,
											COD_COBERTURA
											FROM SEGUROS.SI_AR_DETALHE_VC
											WHERE NUM_APOL_SINISTRO = '{this.SIARDEVC_NUM_APOL_SINISTRO}'
											AND COD_OPERACAO = 101
											AND STA_PROCESSAMENTO = '1'";

            return query;
        }
        public string HOST_NUM_SINISTRO_VC { get; set; }
        public string HOST_NUM_EXPEDIENTE_VC { get; set; }
        public string HOST_COD_COBERTURA { get; set; }
        public string SIARDEVC_NUM_APOL_SINISTRO { get; set; }

        public static R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1 Execute(R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1 r1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1)
        {
            var ths = r1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_NUM_SINISTRO_VC = result[i++].Value?.ToString();
            dta.HOST_NUM_EXPEDIENTE_VC = result[i++].Value?.ToString();
            dta.HOST_COD_COBERTURA = result[i++].Value?.ToString();
            return dta;
        }

    }
}