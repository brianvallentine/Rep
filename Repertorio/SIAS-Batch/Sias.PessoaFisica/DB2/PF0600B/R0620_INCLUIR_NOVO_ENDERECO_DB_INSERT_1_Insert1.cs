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
    public class R0620_INCLUIR_NOVO_ENDERECO_DB_INSERT_1_Insert1 : QueryBasis<R0620_INCLUIR_NOVO_ENDERECO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.PESSOA_ENDERECO VALUES
            (:DCLPESSOA-ENDERECO.COD-PESSOA,
            :DCLPESSOA-ENDERECO.OCORR-ENDERECO,
            :DCLPESSOA-ENDERECO.ENDERECO,
            :DCLPESSOA-ENDERECO.TIPO-ENDER,
            NULL,
            :DCLPESSOA-ENDERECO.BAIRRO,
            :DCLPESSOA-ENDERECO.CEP,
            :DCLPESSOA-ENDERECO.CIDADE,
            :DCLPESSOA-ENDERECO.SIGLA-UF,
            :DCLPESSOA-ENDERECO.SITUACAO-ENDERECO,
            :DCLPESSOA-ENDERECO.COD-USUARIO,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PESSOA_ENDERECO VALUES ({FieldThreatment(this.COD_PESSOA)}, {FieldThreatment(this.OCORR_ENDERECO)}, {FieldThreatment(this.ENDERECO)}, {FieldThreatment(this.TIPO_ENDER)}, NULL, {FieldThreatment(this.BAIRRO)}, {FieldThreatment(this.CEP)}, {FieldThreatment(this.CIDADE)}, {FieldThreatment(this.SIGLA_UF)}, {FieldThreatment(this.SITUACAO_ENDERECO)}, {FieldThreatment(this.COD_USUARIO)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string COD_PESSOA { get; set; }
        public string OCORR_ENDERECO { get; set; }
        public string ENDERECO { get; set; }
        public string TIPO_ENDER { get; set; }
        public string BAIRRO { get; set; }
        public string CEP { get; set; }
        public string CIDADE { get; set; }
        public string SIGLA_UF { get; set; }
        public string SITUACAO_ENDERECO { get; set; }
        public string COD_USUARIO { get; set; }

        public static void Execute(R0620_INCLUIR_NOVO_ENDERECO_DB_INSERT_1_Insert1 r0620_INCLUIR_NOVO_ENDERECO_DB_INSERT_1_Insert1)
        {
            var ths = r0620_INCLUIR_NOVO_ENDERECO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0620_INCLUIR_NOVO_ENDERECO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}