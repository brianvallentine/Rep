using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0118B
{
    public class R7771_00_LER_PROP_SIVPF_DB_SELECT_1_Query1 : QueryBasis<R7771_00_LER_PROP_SIVPF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_IDENTIFICACAO,
            NUM_SICOB,
            SIT_PROPOSTA,
            DTQITBCO,
            VAL_PAGO,
            DATA_CREDITO,
            OPCAO_COBER,
            COD_PLANO
            INTO :SIVPF-NR-IDENTIFI,
            :SIVPF-NR-SICOB,
            :SIVPF-SIT-PROPOSTA,
            :SIVPF-DTQITBCO,
            :SIVPF-VAL-PAGO,
            :SIVPF-DATA-CREDITO,
            :SIVPF-OPCAO-COBER,
            :SIVPF-COD-PLANO
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE NUM_PROPOSTA_SIVPF = :SIVPF-NR-PROPOSTA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_IDENTIFICACAO
							,
											NUM_SICOB
							,
											SIT_PROPOSTA
							,
											DTQITBCO
							,
											VAL_PAGO
							,
											DATA_CREDITO
							,
											OPCAO_COBER
							,
											COD_PLANO
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_PROPOSTA_SIVPF = '{this.SIVPF_NR_PROPOSTA}'";

            return query;
        }
        public string SIVPF_NR_IDENTIFI { get; set; }
        public string SIVPF_NR_SICOB { get; set; }
        public string SIVPF_SIT_PROPOSTA { get; set; }
        public string SIVPF_DTQITBCO { get; set; }
        public string SIVPF_VAL_PAGO { get; set; }
        public string SIVPF_DATA_CREDITO { get; set; }
        public string SIVPF_OPCAO_COBER { get; set; }
        public string SIVPF_COD_PLANO { get; set; }
        public string SIVPF_NR_PROPOSTA { get; set; }

        public static R7771_00_LER_PROP_SIVPF_DB_SELECT_1_Query1 Execute(R7771_00_LER_PROP_SIVPF_DB_SELECT_1_Query1 r7771_00_LER_PROP_SIVPF_DB_SELECT_1_Query1)
        {
            var ths = r7771_00_LER_PROP_SIVPF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R7771_00_LER_PROP_SIVPF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R7771_00_LER_PROP_SIVPF_DB_SELECT_1_Query1();
            var i = 0;
            dta.SIVPF_NR_IDENTIFI = result[i++].Value?.ToString();
            dta.SIVPF_NR_SICOB = result[i++].Value?.ToString();
            dta.SIVPF_SIT_PROPOSTA = result[i++].Value?.ToString();
            dta.SIVPF_DTQITBCO = result[i++].Value?.ToString();
            dta.SIVPF_VAL_PAGO = result[i++].Value?.ToString();
            dta.SIVPF_DATA_CREDITO = result[i++].Value?.ToString();
            dta.SIVPF_OPCAO_COBER = result[i++].Value?.ToString();
            dta.SIVPF_COD_PLANO = result[i++].Value?.ToString();
            return dta;
        }

    }
}