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
    public class R0520_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1 : QueryBasis<R0520_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.PESSOA VALUES
            (:DCLPESSOA.PESSOA-COD-PESSOA,
            :DCLPESSOA.PESSOA-NOME-PESSOA,
            CURRENT TIMESTAMP,
            :DCLPESSOA.PESSOA-COD-USUARIO,
            :DCLPESSOA.PESSOA-TIPO-PESSOA,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PESSOA VALUES ({FieldThreatment(this.PESSOA_COD_PESSOA)}, {FieldThreatment(this.PESSOA_NOME_PESSOA)}, CURRENT TIMESTAMP, {FieldThreatment(this.PESSOA_COD_USUARIO)}, {FieldThreatment(this.PESSOA_TIPO_PESSOA)}, NULL)";

            return query;
        }
        public string PESSOA_COD_PESSOA { get; set; }
        public string PESSOA_NOME_PESSOA { get; set; }
        public string PESSOA_COD_USUARIO { get; set; }
        public string PESSOA_TIPO_PESSOA { get; set; }

        public static void Execute(R0520_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1 r0520_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1)
        {
            var ths = r0520_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0520_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}