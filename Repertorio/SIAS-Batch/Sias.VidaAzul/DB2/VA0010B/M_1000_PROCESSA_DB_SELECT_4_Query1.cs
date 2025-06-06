using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0010B
{
    public class M_1000_PROCESSA_DB_SELECT_4_Query1 : QueryBasis<M_1000_PROCESSA_DB_SELECT_4_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OPCAOCAP,
            COD_AGENCIA,
            NUM_CTA_CORRENTE,
            DAC_CTA_CORRENTE,
            DIA_DEBITO
            INTO :V0CCOR-OPCAOCAP:V0CCOR-OPCAOCAP-I,
            :V0CCOR-COD-AGENCIA,
            :V0CCOR-NUM-CTA-CORRENTE,
            :V0CCOR-DAC-CTA-CORRENTE,
            :V0CCOR-DIA-DEBITO:V0CCOR-DIA-DEBITO-I
            FROM SEGUROS.V0CONTACOR
            WHERE
            NUM_CERTIFICADO = :V1SEGV-NRCERTIF
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT OPCAOCAP
							,
											COD_AGENCIA
							,
											NUM_CTA_CORRENTE
							,
											DAC_CTA_CORRENTE
							,
											DIA_DEBITO
											FROM SEGUROS.V0CONTACOR
											WHERE
											NUM_CERTIFICADO = '{this.V1SEGV_NRCERTIF}'";

            return query;
        }
        public string V0CCOR_OPCAOCAP { get; set; }
        public string V0CCOR_OPCAOCAP_I { get; set; }
        public string V0CCOR_COD_AGENCIA { get; set; }
        public string V0CCOR_NUM_CTA_CORRENTE { get; set; }
        public string V0CCOR_DAC_CTA_CORRENTE { get; set; }
        public string V0CCOR_DIA_DEBITO { get; set; }
        public string V0CCOR_DIA_DEBITO_I { get; set; }
        public string V1SEGV_NRCERTIF { get; set; }

        public static M_1000_PROCESSA_DB_SELECT_4_Query1 Execute(M_1000_PROCESSA_DB_SELECT_4_Query1 m_1000_PROCESSA_DB_SELECT_4_Query1)
        {
            var ths = m_1000_PROCESSA_DB_SELECT_4_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1000_PROCESSA_DB_SELECT_4_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1000_PROCESSA_DB_SELECT_4_Query1();
            var i = 0;
            dta.V0CCOR_OPCAOCAP = result[i++].Value?.ToString();
            dta.V0CCOR_OPCAOCAP_I = string.IsNullOrWhiteSpace(dta.V0CCOR_OPCAOCAP) ? "-1" : "0";
            dta.V0CCOR_COD_AGENCIA = result[i++].Value?.ToString();
            dta.V0CCOR_NUM_CTA_CORRENTE = result[i++].Value?.ToString();
            dta.V0CCOR_DAC_CTA_CORRENTE = result[i++].Value?.ToString();
            dta.V0CCOR_DIA_DEBITO = result[i++].Value?.ToString();
            dta.V0CCOR_DIA_DEBITO_I = string.IsNullOrWhiteSpace(dta.V0CCOR_DIA_DEBITO) ? "-1" : "0";
            return dta;
        }

    }
}