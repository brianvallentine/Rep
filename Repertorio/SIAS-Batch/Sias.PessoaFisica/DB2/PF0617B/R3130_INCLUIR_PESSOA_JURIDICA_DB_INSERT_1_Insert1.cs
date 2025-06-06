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
    public class R3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1_Insert1 : QueryBasis<R3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.PESSOA_JURIDICA VALUES
            (:DCLPESSOA-JURIDICA.COD-PESSOA,
            :DCLPESSOA-JURIDICA.CGC,
            :DCLPESSOA-JURIDICA.NOME-FANTASIA,
            :DCLPESSOA-JURIDICA.COD-USUARIO,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PESSOA_JURIDICA VALUES ({FieldThreatment(this.COD_PESSOA)}, {FieldThreatment(this.CGC)}, {FieldThreatment(this.NOME_FANTASIA)}, {FieldThreatment(this.COD_USUARIO)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string COD_PESSOA { get; set; }
        public string CGC { get; set; }
        public string NOME_FANTASIA { get; set; }
        public string COD_USUARIO { get; set; }

        public static void Execute(R3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1_Insert1 r3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1_Insert1)
        {
            var ths = r3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}