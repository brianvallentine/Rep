using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI2010B
{
    public class R0620_00_LER_SI_DOCUMENTO_DB_SELECT_1_Query1 : QueryBasis<R0620_00_LER_SI_DOCUMENTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_DOCF_INTERNO
            ,MAX(OCORR_HISTORICO)
            INTO :SIPADOFI-NUM-DOCF-INTERNO
            ,:SIPADOFI-OCORR-HISTORICO
            FROM SEGUROS.SI_PAGA_DOC_FISCAL
            WHERE NUM_APOL_SINISTRO = :SIPADOFI-NUM-APOL-SINISTRO
            AND COD_OPERACAO = :SIPADOFI-COD-OPERACAO
            GROUP BY NUM_DOCF_INTERNO
            ORDER BY NUM_DOCF_INTERNO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_DOCF_INTERNO
											,MAX(OCORR_HISTORICO)
											FROM SEGUROS.SI_PAGA_DOC_FISCAL
											WHERE NUM_APOL_SINISTRO = '{this.SIPADOFI_NUM_APOL_SINISTRO}'
											AND COD_OPERACAO = '{this.SIPADOFI_COD_OPERACAO}'
											GROUP BY NUM_DOCF_INTERNO
											ORDER BY NUM_DOCF_INTERNO
											WITH UR";

            return query;
        }
        public string SIPADOFI_NUM_DOCF_INTERNO { get; set; }
        public string SIPADOFI_OCORR_HISTORICO { get; set; }
        public string SIPADOFI_NUM_APOL_SINISTRO { get; set; }
        public string SIPADOFI_COD_OPERACAO { get; set; }

        public static R0620_00_LER_SI_DOCUMENTO_DB_SELECT_1_Query1 Execute(R0620_00_LER_SI_DOCUMENTO_DB_SELECT_1_Query1 r0620_00_LER_SI_DOCUMENTO_DB_SELECT_1_Query1)
        {
            var ths = r0620_00_LER_SI_DOCUMENTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0620_00_LER_SI_DOCUMENTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0620_00_LER_SI_DOCUMENTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.SIPADOFI_NUM_DOCF_INTERNO = result[i++].Value?.ToString();
            dta.SIPADOFI_OCORR_HISTORICO = result[i++].Value?.ToString();
            return dta;
        }

    }
}