using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA4002B
{
    public class M_3830_CONTA_CORRENTE_DB_SELECT_1_Query1 : QueryBasis<M_3830_CONTA_CORRENTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_AGENCIA,
            NUM_CTA_CORRENTE,
            DAC_CTA_CORRENTE
            INTO :CONTACOR-COD-AGENCIA,
            :CONTACOR-NUM-CTA-CORRENTE,
            :CONTACOR-DAC-CTA-CORRENTE
            FROM SEGUROS.CONTA_CORRENTE
            WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_AGENCIA
							,
											NUM_CTA_CORRENTE
							,
											DAC_CTA_CORRENTE
											FROM SEGUROS.CONTA_CORRENTE
											WHERE NUM_CERTIFICADO = '{this.PROPVA_NRCERTIF}'";

            return query;
        }
        public string CONTACOR_COD_AGENCIA { get; set; }
        public string CONTACOR_NUM_CTA_CORRENTE { get; set; }
        public string CONTACOR_DAC_CTA_CORRENTE { get; set; }
        public string PROPVA_NRCERTIF { get; set; }

        public static M_3830_CONTA_CORRENTE_DB_SELECT_1_Query1 Execute(M_3830_CONTA_CORRENTE_DB_SELECT_1_Query1 m_3830_CONTA_CORRENTE_DB_SELECT_1_Query1)
        {
            var ths = m_3830_CONTA_CORRENTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_3830_CONTA_CORRENTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_3830_CONTA_CORRENTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.CONTACOR_COD_AGENCIA = result[i++].Value?.ToString();
            dta.CONTACOR_NUM_CTA_CORRENTE = result[i++].Value?.ToString();
            dta.CONTACOR_DAC_CTA_CORRENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}