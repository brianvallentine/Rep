using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0121B
{
    public class M_0450_020_ACESSA_CTA_CORRENTE_DB_SELECT_1_Query1 : QueryBasis<M_0450_020_ACESSA_CTA_CORRENTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT COD_BANCO ,
            COD_AGENCIA ,
            NUM_CTA_CORRENTE ,
            DAC_CTA_CORRENTE
            INTO :CONTACOR-BANCO ,
            :CONTACOR-AGENCIA ,
            :CONTACOR-CTA-COR ,
            :CONTACOR-DAC
            FROM SEGUROS.V0CONTACOR
            WHERE NUM_APOLICE = :SEGURAVG-NUM-APOL
            AND NUM_CERTIFICADO = :SEGURAVG-NUM-CERT
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_BANCO 
							,
											COD_AGENCIA 
							,
											NUM_CTA_CORRENTE 
							,
											DAC_CTA_CORRENTE
											FROM SEGUROS.V0CONTACOR
											WHERE NUM_APOLICE = '{this.SEGURAVG_NUM_APOL}'
											AND NUM_CERTIFICADO = '{this.SEGURAVG_NUM_CERT}'";

            return query;
        }
        public string CONTACOR_BANCO { get; set; }
        public string CONTACOR_AGENCIA { get; set; }
        public string CONTACOR_CTA_COR { get; set; }
        public string CONTACOR_DAC { get; set; }
        public string SEGURAVG_NUM_APOL { get; set; }
        public string SEGURAVG_NUM_CERT { get; set; }

        public static M_0450_020_ACESSA_CTA_CORRENTE_DB_SELECT_1_Query1 Execute(M_0450_020_ACESSA_CTA_CORRENTE_DB_SELECT_1_Query1 m_0450_020_ACESSA_CTA_CORRENTE_DB_SELECT_1_Query1)
        {
            var ths = m_0450_020_ACESSA_CTA_CORRENTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0450_020_ACESSA_CTA_CORRENTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0450_020_ACESSA_CTA_CORRENTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.CONTACOR_BANCO = result[i++].Value?.ToString();
            dta.CONTACOR_AGENCIA = result[i++].Value?.ToString();
            dta.CONTACOR_CTA_COR = result[i++].Value?.ToString();
            dta.CONTACOR_DAC = result[i++].Value?.ToString();
            return dta;
        }

    }
}