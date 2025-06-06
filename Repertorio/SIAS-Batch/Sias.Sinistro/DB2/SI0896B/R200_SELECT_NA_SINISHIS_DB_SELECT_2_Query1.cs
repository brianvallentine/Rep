using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0896B
{
    public class R200_SELECT_NA_SINISHIS_DB_SELECT_2_Query1 : QueryBasis<R200_SELECT_NA_SINISHIS_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NUMERO_SIVAT,
            VALUE(A.DATA_SIVAT,DATE( '9999-12-31' ))
            INTO :RALCHEDO-NUMERO-SIVAT,
            :RALCHEDO-DATA-SIVAT
            FROM SEGUROS.RALACAO_CHEQ_DOCTO A,
            SEGUROS.SINISTRO_HISTORICO B
            WHERE A.NUMDOC_NUM01 = :SINIPLAN-NUM-APOL-SINISTRO
            AND A.NUMDOC_NUM01 = B.NUM_APOL_SINISTRO
            AND A.OCORR_HISTORICO = B.OCORR_HISTORICO
            AND B.COD_OPERACAO = 1050
            AND B.OCORR_HISTORICO =
            (SELECT VALUE(MAX(C.OCORR_HISTORICO),0)
            FROM SEGUROS.SINISTRO_HISTORICO C
            WHERE C.NUM_APOL_SINISTRO = :SINIPLAN-NUM-APOL-SINISTRO
            AND C.COD_OPERACAO = 1050)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.NUMERO_SIVAT
							,
											VALUE(A.DATA_SIVAT
							,DATE( '9999-12-31' ))
											FROM SEGUROS.RALACAO_CHEQ_DOCTO A
							,
											SEGUROS.SINISTRO_HISTORICO B
											WHERE A.NUMDOC_NUM01 = '{this.SINIPLAN_NUM_APOL_SINISTRO}'
											AND A.NUMDOC_NUM01 = B.NUM_APOL_SINISTRO
											AND A.OCORR_HISTORICO = B.OCORR_HISTORICO
											AND B.COD_OPERACAO = 1050
											AND B.OCORR_HISTORICO =
											(SELECT VALUE(MAX(C.OCORR_HISTORICO)
							,0)
											FROM SEGUROS.SINISTRO_HISTORICO C
											WHERE C.NUM_APOL_SINISTRO = '{this.SINIPLAN_NUM_APOL_SINISTRO}'
											AND C.COD_OPERACAO = 1050)";

            return query;
        }
        public string RALCHEDO_NUMERO_SIVAT { get; set; }
        public string RALCHEDO_DATA_SIVAT { get; set; }
        public string SINIPLAN_NUM_APOL_SINISTRO { get; set; }

        public static R200_SELECT_NA_SINISHIS_DB_SELECT_2_Query1 Execute(R200_SELECT_NA_SINISHIS_DB_SELECT_2_Query1 r200_SELECT_NA_SINISHIS_DB_SELECT_2_Query1)
        {
            var ths = r200_SELECT_NA_SINISHIS_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R200_SELECT_NA_SINISHIS_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R200_SELECT_NA_SINISHIS_DB_SELECT_2_Query1();
            var i = 0;
            dta.RALCHEDO_NUMERO_SIVAT = result[i++].Value?.ToString();
            dta.RALCHEDO_DATA_SIVAT = result[i++].Value?.ToString();
            return dta;
        }

    }
}