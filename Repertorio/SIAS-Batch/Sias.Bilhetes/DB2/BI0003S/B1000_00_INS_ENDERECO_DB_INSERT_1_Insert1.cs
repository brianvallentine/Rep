using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0003S
{
    public class B1000_00_INS_ENDERECO_DB_INSERT_1_Insert1 : QueryBasis<B1000_00_INS_ENDERECO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.PESSOA_ENDERECO
            VALUES (:WS-COD-PES-ATU,
            :WS-MAX-OCO-END,
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
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PESSOA_ENDERECO VALUES ({FieldThreatment(this.WS_COD_PES_ATU)}, {FieldThreatment(this.WS_MAX_OCO_END)}, {FieldThreatment(this.ENDERECO)}, {FieldThreatment(this.TIPO_ENDER)}, NULL, {FieldThreatment(this.BAIRRO)}, {FieldThreatment(this.CEP)}, {FieldThreatment(this.CIDADE)}, {FieldThreatment(this.SIGLA_UF)}, {FieldThreatment(this.SITUACAO_ENDERECO)}, {FieldThreatment(this.COD_USUARIO)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string WS_COD_PES_ATU { get; set; }
        public string WS_MAX_OCO_END { get; set; }
        public string ENDERECO { get; set; }
        public string TIPO_ENDER { get; set; }
        public string BAIRRO { get; set; }
        public string CEP { get; set; }
        public string CIDADE { get; set; }
        public string SIGLA_UF { get; set; }
        public string SITUACAO_ENDERECO { get; set; }
        public string COD_USUARIO { get; set; }

        public static void Execute(B1000_00_INS_ENDERECO_DB_INSERT_1_Insert1 b1000_00_INS_ENDERECO_DB_INSERT_1_Insert1)
        {
            var ths = b1000_00_INS_ENDERECO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override B1000_00_INS_ENDERECO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}