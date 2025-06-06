using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0874B
{
    public class R1810_BUSCA_SIVAT_DB_SELECT_1_Query1 : QueryBasis<R1810_BUSCA_SIVAT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_CHEQUE_INTERNO,
            NUMERO_SIVAT,
            DV_SIVAT,
            DATA_SIVAT
            INTO :RALCHEDO-NUM-CHEQUE-INTERNO,
            :RALCHEDO-NUMERO-SIVAT,
            :RALCHEDO-DV-SIVAT,
            :RALCHEDO-DATA-SIVAT
            FROM SEGUROS.RALACAO_CHEQ_DOCTO
            WHERE NUMDOC_NUM01 = :SINISHIS-NUM-APOL-SINISTRO
            AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_CHEQUE_INTERNO
							,
											NUMERO_SIVAT
							,
											DV_SIVAT
							,
											DATA_SIVAT
											FROM SEGUROS.RALACAO_CHEQ_DOCTO
											WHERE NUMDOC_NUM01 = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND OCORR_HISTORICO = '{this.SINISHIS_OCORR_HISTORICO}'
											WITH UR";

            return query;
        }
        public string RALCHEDO_NUM_CHEQUE_INTERNO { get; set; }
        public string RALCHEDO_NUMERO_SIVAT { get; set; }
        public string RALCHEDO_DV_SIVAT { get; set; }
        public string RALCHEDO_DATA_SIVAT { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }

        public static R1810_BUSCA_SIVAT_DB_SELECT_1_Query1 Execute(R1810_BUSCA_SIVAT_DB_SELECT_1_Query1 r1810_BUSCA_SIVAT_DB_SELECT_1_Query1)
        {
            var ths = r1810_BUSCA_SIVAT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1810_BUSCA_SIVAT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1810_BUSCA_SIVAT_DB_SELECT_1_Query1();
            var i = 0;
            dta.RALCHEDO_NUM_CHEQUE_INTERNO = result[i++].Value?.ToString();
            dta.RALCHEDO_NUMERO_SIVAT = result[i++].Value?.ToString();
            dta.RALCHEDO_DV_SIVAT = result[i++].Value?.ToString();
            dta.RALCHEDO_DATA_SIVAT = result[i++].Value?.ToString();
            return dta;
        }

    }
}