using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0600B
{
    public class R9971_LER_RCAP_DB_SELECT_1_Query1 : QueryBasis<R9971_LER_RCAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_FONTE,
            NUM_RCAP,
            VAL_RCAP,
            AGE_COBRANCA
            INTO :DCLRCAPS.RCAPS-COD-FONTE,
            :DCLRCAPS.RCAPS-NUM-RCAP,
            :DCLRCAPS.RCAPS-VAL-RCAP,
            :DCLRCAPS.RCAPS-AGE-COBRANCA:VIND-RCAPS-AGE
            FROM SEGUROS.RCAPS
            WHERE NUM_CERTIFICADO =:DCLRCAPS.RCAPS-NUM-CERTIFICADO
            AND COD_OPERACAO BETWEEN 100 AND 199
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_FONTE
							,
											NUM_RCAP
							,
											VAL_RCAP
							,
											AGE_COBRANCA
											FROM SEGUROS.RCAPS
											WHERE NUM_CERTIFICADO ='{this.RCAPS_NUM_CERTIFICADO}'
											AND COD_OPERACAO BETWEEN 100 AND 199
											WITH UR";

            return query;
        }
        public string RCAPS_COD_FONTE { get; set; }
        public string RCAPS_NUM_RCAP { get; set; }
        public string RCAPS_VAL_RCAP { get; set; }
        public string RCAPS_AGE_COBRANCA { get; set; }
        public string VIND_RCAPS_AGE { get; set; }
        public string RCAPS_NUM_CERTIFICADO { get; set; }

        public static R9971_LER_RCAP_DB_SELECT_1_Query1 Execute(R9971_LER_RCAP_DB_SELECT_1_Query1 r9971_LER_RCAP_DB_SELECT_1_Query1)
        {
            var ths = r9971_LER_RCAP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R9971_LER_RCAP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R9971_LER_RCAP_DB_SELECT_1_Query1();
            var i = 0;
            dta.RCAPS_COD_FONTE = result[i++].Value?.ToString();
            dta.RCAPS_NUM_RCAP = result[i++].Value?.ToString();
            dta.RCAPS_VAL_RCAP = result[i++].Value?.ToString();
            dta.RCAPS_AGE_COBRANCA = result[i++].Value?.ToString();
            dta.VIND_RCAPS_AGE = string.IsNullOrWhiteSpace(dta.RCAPS_AGE_COBRANCA) ? "-1" : "0";
            return dta;
        }

    }
}