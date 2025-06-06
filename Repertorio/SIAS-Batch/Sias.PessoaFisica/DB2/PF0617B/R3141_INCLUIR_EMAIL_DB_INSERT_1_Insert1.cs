using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0617B
{
    public class R3141_INCLUIR_EMAIL_DB_INSERT_1_Insert1 : QueryBasis<R3141_INCLUIR_EMAIL_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.PESSOA_EMAIL VALUES
            (:DCLPESSOA-EMAIL.COD-PESSOA,
            :DCLPESSOA-EMAIL.SEQ-EMAIL,
            :DCLPESSOA-EMAIL.EMAIL,
            :DCLPESSOA-EMAIL.SITUACAO-EMAIL,
            :DCLPESSOA-EMAIL.COD-USUARIO,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PESSOA_EMAIL VALUES ({FieldThreatment(this.COD_PESSOA)}, {FieldThreatment(this.SEQ_EMAIL)}, {FieldThreatment(this.EMAIL)}, {FieldThreatment(this.SITUACAO_EMAIL)}, {FieldThreatment(this.COD_USUARIO)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string COD_PESSOA { get; set; }
        public string SEQ_EMAIL { get; set; }
        public string EMAIL { get; set; }
        public string SITUACAO_EMAIL { get; set; }
        public string COD_USUARIO { get; set; }

        public static void Execute(R3141_INCLUIR_EMAIL_DB_INSERT_1_Insert1 r3141_INCLUIR_EMAIL_DB_INSERT_1_Insert1)
        {
            var ths = r3141_INCLUIR_EMAIL_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3141_INCLUIR_EMAIL_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}