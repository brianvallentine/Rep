using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class R0894_2600_INSERE_PESSOFIS_DB_INSERT_1_Insert1 : QueryBasis<R0894_2600_INSERE_PESSOFIS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.PESSOA_FISICA
            (COD_PESSOA,
            CPF,
            DATA_NASCIMENTO,
            SEXO,
            COD_USUARIO,
            ESTADO_CIVIL,
            TIMESTAMP,
            NUM_IDENTIDADE,
            ORGAO_EXPEDIDOR,
            UF_EXPEDIDORA,
            DATA_EXPEDICAO,
            COD_CBO,
            TIPO_IDENT_SIVPF)
            VALUES
            (:PESSOFIS-COD-PESSOA,
            :PESSOFIS-CPF,
            CURRENT DATE,
            :PESSOFIS-SEXO,
            :PESSOFIS-COD-USUARIO,
            :PESSOFIS-ESTADO-CIVIL,
            CURRENT TIMESTAMP,
            :PESSOFIS-NUM-IDENTIDADE,
            :PESSOFIS-ORGAO-EXPEDIDOR,
            :PESSOFIS-UF-EXPEDIDORA,
            CURRENT DATE,
            :PESSOFIS-COD-CBO,
            :PESSOFIS-TIPO-IDENT-SIVPF)
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PESSOA_FISICA (COD_PESSOA, CPF, DATA_NASCIMENTO, SEXO, COD_USUARIO, ESTADO_CIVIL, TIMESTAMP, NUM_IDENTIDADE, ORGAO_EXPEDIDOR, UF_EXPEDIDORA, DATA_EXPEDICAO, COD_CBO, TIPO_IDENT_SIVPF) VALUES ({FieldThreatment(this.PESSOFIS_COD_PESSOA)}, {FieldThreatment(this.PESSOFIS_CPF)}, CURRENT DATE, {FieldThreatment(this.PESSOFIS_SEXO)}, {FieldThreatment(this.PESSOFIS_COD_USUARIO)}, {FieldThreatment(this.PESSOFIS_ESTADO_CIVIL)}, CURRENT TIMESTAMP, {FieldThreatment(this.PESSOFIS_NUM_IDENTIDADE)}, {FieldThreatment(this.PESSOFIS_ORGAO_EXPEDIDOR)}, {FieldThreatment(this.PESSOFIS_UF_EXPEDIDORA)}, CURRENT DATE, {FieldThreatment(this.PESSOFIS_COD_CBO)}, {FieldThreatment(this.PESSOFIS_TIPO_IDENT_SIVPF)})";

            return query;
        }
        public string PESSOFIS_COD_PESSOA { get; set; }
        public string PESSOFIS_CPF { get; set; }
        public string PESSOFIS_SEXO { get; set; }
        public string PESSOFIS_COD_USUARIO { get; set; }
        public string PESSOFIS_ESTADO_CIVIL { get; set; }
        public string PESSOFIS_NUM_IDENTIDADE { get; set; }
        public string PESSOFIS_ORGAO_EXPEDIDOR { get; set; }
        public string PESSOFIS_UF_EXPEDIDORA { get; set; }
        public string PESSOFIS_COD_CBO { get; set; }
        public string PESSOFIS_TIPO_IDENT_SIVPF { get; set; }

        public static void Execute(R0894_2600_INSERE_PESSOFIS_DB_INSERT_1_Insert1 r0894_2600_INSERE_PESSOFIS_DB_INSERT_1_Insert1)
        {
            var ths = r0894_2600_INSERE_PESSOFIS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0894_2600_INSERE_PESSOFIS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}