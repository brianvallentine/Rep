using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0106B
{
    public class R0260_LER_DADOS_PAGADOR_DB_SELECT_1_Query1 : QueryBasis<R0260_LER_DADOS_PAGADOR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_CGC_CPF ,
            NOM_PAGADOR ,
            DTH_NASCIMENTO,
            NUM_TELEFONE
            INTO :PF039-NUM-CGC-CPF ,
            :PF039-NOM-PAGADOR ,
            :PF039-DTH-NASCIMENTO,
            :PF039-NUM-TELEFONE
            FROM SEGUROS.PF_PAGADOR_SIVPF
            WHERE NUM_CGC_CPF = :PF039-NUM-CGC-CPF
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_CGC_CPF 
							,
											NOM_PAGADOR 
							,
											DTH_NASCIMENTO
							,
											NUM_TELEFONE
											FROM SEGUROS.PF_PAGADOR_SIVPF
											WHERE NUM_CGC_CPF = '{this.PF039_NUM_CGC_CPF}'
											WITH UR";

            return query;
        }
        public string PF039_NUM_CGC_CPF { get; set; }
        public string PF039_NOM_PAGADOR { get; set; }
        public string PF039_DTH_NASCIMENTO { get; set; }
        public string PF039_NUM_TELEFONE { get; set; }

        public static R0260_LER_DADOS_PAGADOR_DB_SELECT_1_Query1 Execute(R0260_LER_DADOS_PAGADOR_DB_SELECT_1_Query1 r0260_LER_DADOS_PAGADOR_DB_SELECT_1_Query1)
        {
            var ths = r0260_LER_DADOS_PAGADOR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0260_LER_DADOS_PAGADOR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0260_LER_DADOS_PAGADOR_DB_SELECT_1_Query1();
            var i = 0;
            dta.PF039_NUM_CGC_CPF = result[i++].Value?.ToString();
            dta.PF039_NOM_PAGADOR = result[i++].Value?.ToString();
            dta.PF039_DTH_NASCIMENTO = result[i++].Value?.ToString();
            dta.PF039_NUM_TELEFONE = result[i++].Value?.ToString();
            return dta;
        }

    }
}