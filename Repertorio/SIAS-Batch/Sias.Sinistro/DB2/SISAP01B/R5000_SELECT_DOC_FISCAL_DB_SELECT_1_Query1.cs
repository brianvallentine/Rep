using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SISAP01B
{
    public class R5000_SELECT_DOC_FISCAL_DB_SELECT_1_Query1 : QueryBasis<R5000_SELECT_DOC_FISCAL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            F.NUM_DOC_FISCAL
            , F.SERIE_DOC_FISCAL
            , F.DATA_EMISSAO_DOC
            INTO
            :FIPADOFI-NUM-DOC-FISCAL:NULL-NUM-DOC-FISCAL
            ,:FIPADOFI-SERIE-DOC-FISCAL:NULL-SERIE-DOC-FISCAL
            ,:FIPADOFI-DATA-EMISSAO-DOC:NULL-DATA-EMISSAO-DOC
            FROM SEGUROS.SI_PAGA_DOC_FISCAL A
            JOIN SEGUROS.FI_PAGA_DOC_FISCAL F
            ON F.NUM_DOCF_INTERNO = A.NUM_DOCF_INTERNO
            WHERE F.NUM_DOC_FISCAL > 0
            AND A.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND A.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											F.NUM_DOC_FISCAL
											, F.SERIE_DOC_FISCAL
											, F.DATA_EMISSAO_DOC
											FROM SEGUROS.SI_PAGA_DOC_FISCAL A
											JOIN SEGUROS.FI_PAGA_DOC_FISCAL F
											ON F.NUM_DOCF_INTERNO = A.NUM_DOCF_INTERNO
											WHERE F.NUM_DOC_FISCAL > 0
											AND A.NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND A.OCORR_HISTORICO = '{this.SINISHIS_OCORR_HISTORICO}'";

            return query;
        }
        public string FIPADOFI_NUM_DOC_FISCAL { get; set; }
        public string NULL_NUM_DOC_FISCAL { get; set; }
        public string FIPADOFI_SERIE_DOC_FISCAL { get; set; }
        public string NULL_SERIE_DOC_FISCAL { get; set; }
        public string FIPADOFI_DATA_EMISSAO_DOC { get; set; }
        public string NULL_DATA_EMISSAO_DOC { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }

        public static R5000_SELECT_DOC_FISCAL_DB_SELECT_1_Query1 Execute(R5000_SELECT_DOC_FISCAL_DB_SELECT_1_Query1 r5000_SELECT_DOC_FISCAL_DB_SELECT_1_Query1)
        {
            var ths = r5000_SELECT_DOC_FISCAL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R5000_SELECT_DOC_FISCAL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R5000_SELECT_DOC_FISCAL_DB_SELECT_1_Query1();
            var i = 0;
            dta.FIPADOFI_NUM_DOC_FISCAL = result[i++].Value?.ToString();
            dta.NULL_NUM_DOC_FISCAL = string.IsNullOrWhiteSpace(dta.FIPADOFI_NUM_DOC_FISCAL) ? "-1" : "0";
            dta.FIPADOFI_SERIE_DOC_FISCAL = result[i++].Value?.ToString();
            dta.NULL_SERIE_DOC_FISCAL = string.IsNullOrWhiteSpace(dta.FIPADOFI_SERIE_DOC_FISCAL) ? "-1" : "0";
            dta.FIPADOFI_DATA_EMISSAO_DOC = result[i++].Value?.ToString();
            dta.NULL_DATA_EMISSAO_DOC = string.IsNullOrWhiteSpace(dta.FIPADOFI_DATA_EMISSAO_DOC) ? "-1" : "0";
            return dta;
        }

    }
}