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
    public class R0794_GERA_DE_PARA_NR_SICOB_DB_INSERT_1_Insert1 : QueryBasis<R0794_GERA_DE_PARA_NR_SICOB_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.CONVERSAO_SICOB VALUES
            (:DCLCONVERSAO-SICOB.NUM-PROPOSTA-SIVPF,
            :DCLCONVERSAO-SICOB.NUM-SICOB,
            :DCLCONVERSAO-SICOB.COD-EMPRESA-SIVPF,
            :DCLCONVERSAO-SICOB.PRODUTO-SIVPF,
            :DCLCONVERSAO-SICOB.AGEPGTO,
            :DCLCONVERSAO-SICOB.DATA-OPERACAO,
            :DCLCONVERSAO-SICOB.DATA-QUITACAO,
            :DCLCONVERSAO-SICOB.VAL-RCAP,
            :DCLCONVERSAO-SICOB.COD-USUARIO,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.CONVERSAO_SICOB VALUES ({FieldThreatment(this.NUM_PROPOSTA_SIVPF)}, {FieldThreatment(this.NUM_SICOB)}, {FieldThreatment(this.COD_EMPRESA_SIVPF)}, {FieldThreatment(this.PRODUTO_SIVPF)}, {FieldThreatment(this.AGEPGTO)}, {FieldThreatment(this.DATA_OPERACAO)}, {FieldThreatment(this.DATA_QUITACAO)}, {FieldThreatment(this.VAL_RCAP)}, {FieldThreatment(this.COD_USUARIO)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string NUM_PROPOSTA_SIVPF { get; set; }
        public string NUM_SICOB { get; set; }
        public string COD_EMPRESA_SIVPF { get; set; }
        public string PRODUTO_SIVPF { get; set; }
        public string AGEPGTO { get; set; }
        public string DATA_OPERACAO { get; set; }
        public string DATA_QUITACAO { get; set; }
        public string VAL_RCAP { get; set; }
        public string COD_USUARIO { get; set; }

        public static void Execute(R0794_GERA_DE_PARA_NR_SICOB_DB_INSERT_1_Insert1 r0794_GERA_DE_PARA_NR_SICOB_DB_INSERT_1_Insert1)
        {
            var ths = r0794_GERA_DE_PARA_NR_SICOB_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0794_GERA_DE_PARA_NR_SICOB_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}