using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0414B
{
    public class R1940_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 : QueryBasis<R1940_00_SELECT_HISCOBPR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IMPSEGUR ,
            QUANT_VIDAS,
            VLPREMIO
            INTO :HISCOBPR-IMPSEGUR ,
            :HISCOBPR-QUANT-VIDAS,
            :HISCOBPR-VLPREMIO
            FROM SEGUROS.HIS_COBER_PROPOST
            WHERE NUM_CERTIFICADO = :VGCOMTRO-NUM-PROPOSTA-SIVPF
            AND DATA_TERVIGENCIA = '9999-12-31'
            ORDER BY OCORR_HISTORICO DESC
            FETCH FIRST 1 ROWS ONLY
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IMPSEGUR 
							,
											QUANT_VIDAS
							,
											VLPREMIO
											FROM SEGUROS.HIS_COBER_PROPOST
											WHERE NUM_CERTIFICADO = '{this.VGCOMTRO_NUM_PROPOSTA_SIVPF}'
											AND DATA_TERVIGENCIA = '9999-12-31'
											ORDER BY OCORR_HISTORICO DESC
											FETCH FIRST 1 ROWS ONLY";

            return query;
        }
        public string HISCOBPR_IMPSEGUR { get; set; }
        public string HISCOBPR_QUANT_VIDAS { get; set; }
        public string HISCOBPR_VLPREMIO { get; set; }
        public string VGCOMTRO_NUM_PROPOSTA_SIVPF { get; set; }

        public static R1940_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 Execute(R1940_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 r1940_00_SELECT_HISCOBPR_DB_SELECT_1_Query1)
        {
            var ths = r1940_00_SELECT_HISCOBPR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1940_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1940_00_SELECT_HISCOBPR_DB_SELECT_1_Query1();
            var i = 0;
            dta.HISCOBPR_IMPSEGUR = result[i++].Value?.ToString();
            dta.HISCOBPR_QUANT_VIDAS = result[i++].Value?.ToString();
            dta.HISCOBPR_VLPREMIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}