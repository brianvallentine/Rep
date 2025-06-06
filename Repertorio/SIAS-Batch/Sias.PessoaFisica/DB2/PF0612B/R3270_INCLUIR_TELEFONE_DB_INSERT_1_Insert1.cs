using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0612B
{
    public class R3270_INCLUIR_TELEFONE_DB_INSERT_1_Insert1 : QueryBasis<R3270_INCLUIR_TELEFONE_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.PESSOA_TELEFONE VALUES
            (:DCLPESSOA-TELEFONE.COD-PESSOA,
            :DCLPESSOA-TELEFONE.TIPO-FONE,
            :DCLPESSOA-TELEFONE.SEQ-FONE,
            :DCLPESSOA-TELEFONE.DDI,
            :DCLPESSOA-TELEFONE.DDD,
            :DCLPESSOA-TELEFONE.NUM-FONE,
            :DCLPESSOA-TELEFONE.SITUACAO-FONE,
            :DCLPESSOA-TELEFONE.COD-USUARIO,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PESSOA_TELEFONE VALUES ({FieldThreatment(this.COD_PESSOA)}, {FieldThreatment(this.TIPO_FONE)}, {FieldThreatment(this.SEQ_FONE)}, {FieldThreatment(this.DDI)}, {FieldThreatment(this.DDD)}, {FieldThreatment(this.NUM_FONE)}, {FieldThreatment(this.SITUACAO_FONE)}, {FieldThreatment(this.COD_USUARIO)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string COD_PESSOA { get; set; }
        public string TIPO_FONE { get; set; }
        public string SEQ_FONE { get; set; }
        public string DDI { get; set; }
        public string DDD { get; set; }
        public string NUM_FONE { get; set; }
        public string SITUACAO_FONE { get; set; }
        public string COD_USUARIO { get; set; }

        public static void Execute(R3270_INCLUIR_TELEFONE_DB_INSERT_1_Insert1 r3270_INCLUIR_TELEFONE_DB_INSERT_1_Insert1)
        {
            var ths = r3270_INCLUIR_TELEFONE_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3270_INCLUIR_TELEFONE_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}