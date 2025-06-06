using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0103B
{
    public class R0792_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1_Query1 : QueryBasis<R0792_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_SICOB ,
            AGEPGTO ,
            DATA_OPERACAO,
            DATA_QUITACAO,
            VAL_RCAP
            INTO :DCLCONVERSAO-SICOB.NUM-SICOB ,
            :DCLCONVERSAO-SICOB.AGEPGTO ,
            :DCLCONVERSAO-SICOB.DATA-OPERACAO,
            :DCLCONVERSAO-SICOB.DATA-QUITACAO,
            :DCLCONVERSAO-SICOB.VAL-RCAP
            FROM SEGUROS.CONVERSAO_SICOB
            WHERE NUM_PROPOSTA_SIVPF =
            :DCLCONVERSAO-SICOB.NUM-PROPOSTA-SIVPF
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_SICOB 
							,
											AGEPGTO 
							,
											DATA_OPERACAO
							,
											DATA_QUITACAO
							,
											VAL_RCAP
											FROM SEGUROS.CONVERSAO_SICOB
											WHERE NUM_PROPOSTA_SIVPF =
											'{this.NUM_PROPOSTA_SIVPF}'
											WITH UR";

            return query;
        }
        public string NUM_SICOB { get; set; }
        public string AGEPGTO { get; set; }
        public string DATA_OPERACAO { get; set; }
        public string DATA_QUITACAO { get; set; }
        public string VAL_RCAP { get; set; }
        public string NUM_PROPOSTA_SIVPF { get; set; }

        public static R0792_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1_Query1 Execute(R0792_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1_Query1 r0792_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1_Query1)
        {
            var ths = r0792_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0792_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0792_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1_Query1();
            var i = 0;
            dta.NUM_SICOB = result[i++].Value?.ToString();
            dta.AGEPGTO = result[i++].Value?.ToString();
            dta.DATA_OPERACAO = result[i++].Value?.ToString();
            dta.DATA_QUITACAO = result[i++].Value?.ToString();
            dta.VAL_RCAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}