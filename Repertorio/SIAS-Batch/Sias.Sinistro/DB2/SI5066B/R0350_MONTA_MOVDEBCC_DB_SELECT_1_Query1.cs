using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI5066B
{
    public class R0350_MONTA_MOVDEBCC_DB_SELECT_1_Query1 : QueryBasis<R0350_MONTA_MOVDEBCC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_BANCO,
            COD_AGENCIA_SASS,
            OPER_CONTA_SASS,
            NUM_CONTA_SASS,
            DIG_CONTA_SASS
            INTO :PARAMCON-COD-BANCO,
            :PARAMCON-COD-AGENCIA-SASS,
            :PARAMCON-OPER-CONTA-SASS,
            :PARAMCON-NUM-CONTA-SASS,
            :PARAMCON-DIG-CONTA-SASS
            FROM SEGUROS.PARAM_CONTACEF
            WHERE COD_CONVENIO = 43350
            AND COD_PRODUTO = (SELECT MAX(COD_PRODUTO)
            FROM SEGUROS.PARAM_CONTACEF
            WHERE COD_CONVENIO = 43350)
            AND SIT_REGISTRO = 'A'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_BANCO
							,
											COD_AGENCIA_SASS
							,
											OPER_CONTA_SASS
							,
											NUM_CONTA_SASS
							,
											DIG_CONTA_SASS
											FROM SEGUROS.PARAM_CONTACEF
											WHERE COD_CONVENIO = 43350
											AND COD_PRODUTO =
							(SELECT  MAX(COD_PRODUTO)
											FROM SEGUROS.PARAM_CONTACEF
											WHERE COD_CONVENIO = 43350)
											AND SIT_REGISTRO = 'A'";

            return query;
        }
        public string PARAMCON_COD_BANCO { get; set; }
        public string PARAMCON_COD_AGENCIA_SASS { get; set; }
        public string PARAMCON_OPER_CONTA_SASS { get; set; }
        public string PARAMCON_NUM_CONTA_SASS { get; set; }
        public string PARAMCON_DIG_CONTA_SASS { get; set; }

        public static R0350_MONTA_MOVDEBCC_DB_SELECT_1_Query1 Execute(R0350_MONTA_MOVDEBCC_DB_SELECT_1_Query1 r0350_MONTA_MOVDEBCC_DB_SELECT_1_Query1)
        {
            var ths = r0350_MONTA_MOVDEBCC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0350_MONTA_MOVDEBCC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0350_MONTA_MOVDEBCC_DB_SELECT_1_Query1();
            var i = 0;
            dta.PARAMCON_COD_BANCO = result[i++].Value?.ToString();
            dta.PARAMCON_COD_AGENCIA_SASS = result[i++].Value?.ToString();
            dta.PARAMCON_OPER_CONTA_SASS = result[i++].Value?.ToString();
            dta.PARAMCON_NUM_CONTA_SASS = result[i++].Value?.ToString();
            dta.PARAMCON_DIG_CONTA_SASS = result[i++].Value?.ToString();
            return dta;
        }

    }
}