using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG9550B
{
    public class R0060_00_CANCELA_SEGURO_DB_SELECT_5_Query1 : QueryBasis<R0060_00_CANCELA_SEGURO_DB_SELECT_5_Query1>
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
            WHERE NUM_CERTIFICADO = :SEGURVGA-NUM-CERTIFICADO
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_AGENCIA
							,
											NUM_CTA_CORRENTE
							,
											DAC_CTA_CORRENTE
											FROM SEGUROS.CONTA_CORRENTE
											WHERE NUM_CERTIFICADO = '{this.SEGURVGA_NUM_CERTIFICADO}'";

            return query;
        }
        public string CONTACOR_COD_AGENCIA { get; set; }
        public string CONTACOR_NUM_CTA_CORRENTE { get; set; }
        public string CONTACOR_DAC_CTA_CORRENTE { get; set; }
        public string SEGURVGA_NUM_CERTIFICADO { get; set; }

        public static R0060_00_CANCELA_SEGURO_DB_SELECT_5_Query1 Execute(R0060_00_CANCELA_SEGURO_DB_SELECT_5_Query1 r0060_00_CANCELA_SEGURO_DB_SELECT_5_Query1)
        {
            var ths = r0060_00_CANCELA_SEGURO_DB_SELECT_5_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0060_00_CANCELA_SEGURO_DB_SELECT_5_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0060_00_CANCELA_SEGURO_DB_SELECT_5_Query1();
            var i = 0;
            dta.CONTACOR_COD_AGENCIA = result[i++].Value?.ToString();
            dta.CONTACOR_NUM_CTA_CORRENTE = result[i++].Value?.ToString();
            dta.CONTACOR_DAC_CTA_CORRENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}