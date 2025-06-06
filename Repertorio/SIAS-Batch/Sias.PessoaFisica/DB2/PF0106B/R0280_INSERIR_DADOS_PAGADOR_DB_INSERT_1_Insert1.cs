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
    public class R0280_INSERIR_DADOS_PAGADOR_DB_INSERT_1_Insert1 : QueryBasis<R0280_INSERIR_DADOS_PAGADOR_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.PF_PAGADOR_SIVPF VALUES
            (:PF039-NUM-CGC-CPF ,
            :PF039-NOM-PAGADOR ,
            :PF039-DTH-NASCIMENTO,
            :PF039-NUM-TELEFONE)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PF_PAGADOR_SIVPF VALUES ({FieldThreatment(this.PF039_NUM_CGC_CPF)} , {FieldThreatment(this.PF039_NOM_PAGADOR)} , {FieldThreatment(this.PF039_DTH_NASCIMENTO)}, {FieldThreatment(this.PF039_NUM_TELEFONE)})";

            return query;
        }
        public string PF039_NUM_CGC_CPF { get; set; }
        public string PF039_NOM_PAGADOR { get; set; }
        public string PF039_DTH_NASCIMENTO { get; set; }
        public string PF039_NUM_TELEFONE { get; set; }

        public static void Execute(R0280_INSERIR_DADOS_PAGADOR_DB_INSERT_1_Insert1 r0280_INSERIR_DADOS_PAGADOR_DB_INSERT_1_Insert1)
        {
            var ths = r0280_INSERIR_DADOS_PAGADOR_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0280_INSERIR_DADOS_PAGADOR_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}