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
    public class R0525_INCLUIR_PESSOA_FISICA_DB_INSERT_1_Insert1 : QueryBasis<R0525_INCLUIR_PESSOA_FISICA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.PESSOA_FISICA VALUES
            (:DCLPESSOA-FISICA.COD-PESSOA,
            :DCLPESSOA-FISICA.CPF,
            :DCLPESSOA-FISICA.DATA-NASCIMENTO,
            :DCLPESSOA-FISICA.SEXO,
            :DCLPESSOA-FISICA.COD-USUARIO,
            :DCLPESSOA-FISICA.ESTADO-CIVIL,
            CURRENT TIMESTAMP,
            :DCLPESSOA-FISICA.NUM-IDENTIDADE,
            :DCLPESSOA-FISICA.ORGAO-EXPEDIDOR,
            :DCLPESSOA-FISICA.UF-EXPEDIDORA,
            :DCLPESSOA-FISICA.DATA-EXPEDICAO:VIND-DTEXPEDI,
            :DCLPESSOA-FISICA.COD-CBO,
            :DCLPESSOA-FISICA.TIPO-IDENT-SIVPF)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PESSOA_FISICA VALUES ({FieldThreatment(this.COD_PESSOA)}, {FieldThreatment(this.CPF)}, {FieldThreatment(this.DATA_NASCIMENTO)}, {FieldThreatment(this.SEXO)}, {FieldThreatment(this.COD_USUARIO)}, {FieldThreatment(this.ESTADO_CIVIL)}, CURRENT TIMESTAMP, {FieldThreatment(this.NUM_IDENTIDADE)}, {FieldThreatment(this.ORGAO_EXPEDIDOR)}, {FieldThreatment(this.UF_EXPEDIDORA)},  {FieldThreatment((this.VIND_DTEXPEDI?.ToInt() == -1 ? null : this.DATA_EXPEDICAO))}, {FieldThreatment(this.COD_CBO)}, {FieldThreatment(this.TIPO_IDENT_SIVPF)})";

            return query;
        }
        public string COD_PESSOA { get; set; }
        public string CPF { get; set; }
        public string DATA_NASCIMENTO { get; set; }
        public string SEXO { get; set; }
        public string COD_USUARIO { get; set; }
        public string ESTADO_CIVIL { get; set; }
        public string NUM_IDENTIDADE { get; set; }
        public string ORGAO_EXPEDIDOR { get; set; }
        public string UF_EXPEDIDORA { get; set; }
        public string DATA_EXPEDICAO { get; set; }
        public string VIND_DTEXPEDI { get; set; }
        public string COD_CBO { get; set; }
        public string TIPO_IDENT_SIVPF { get; set; }

        public static void Execute(R0525_INCLUIR_PESSOA_FISICA_DB_INSERT_1_Insert1 r0525_INCLUIR_PESSOA_FISICA_DB_INSERT_1_Insert1)
        {
            var ths = r0525_INCLUIR_PESSOA_FISICA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0525_INCLUIR_PESSOA_FISICA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}