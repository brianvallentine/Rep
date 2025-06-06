using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM8020B
{
    public class R0450_00_SELECT_SIARDEVC_DB_SELECT_1_Query1 : QueryBasis<R0450_00_SELECT_SIARDEVC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CONTA ,
            DV_CONTA
            INTO :SIARDEVC-COD-CONTA ,
            :SIARDEVC-DV-CONTA
            FROM SEGUROS.SI_AR_DETALHE_VC
            WHERE NUM_APOL_SINISTRO =
            :SIARDEVC-NUM-APOL-SINISTRO
            AND OCORR_HISTORICO =
            :SIARDEVC-OCORR-HISTORICO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_CONTA 
							,
											DV_CONTA
											FROM SEGUROS.SI_AR_DETALHE_VC
											WHERE NUM_APOL_SINISTRO =
											'{this.SIARDEVC_NUM_APOL_SINISTRO}'
											AND OCORR_HISTORICO =
											'{this.SIARDEVC_OCORR_HISTORICO}'
											WITH UR";

            return query;
        }
        public string SIARDEVC_COD_CONTA { get; set; }
        public string SIARDEVC_DV_CONTA { get; set; }
        public string SIARDEVC_NUM_APOL_SINISTRO { get; set; }
        public string SIARDEVC_OCORR_HISTORICO { get; set; }

        public static R0450_00_SELECT_SIARDEVC_DB_SELECT_1_Query1 Execute(R0450_00_SELECT_SIARDEVC_DB_SELECT_1_Query1 r0450_00_SELECT_SIARDEVC_DB_SELECT_1_Query1)
        {
            var ths = r0450_00_SELECT_SIARDEVC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0450_00_SELECT_SIARDEVC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0450_00_SELECT_SIARDEVC_DB_SELECT_1_Query1();
            var i = 0;
            dta.SIARDEVC_COD_CONTA = result[i++].Value?.ToString();
            dta.SIARDEVC_DV_CONTA = result[i++].Value?.ToString();
            return dta;
        }

    }
}