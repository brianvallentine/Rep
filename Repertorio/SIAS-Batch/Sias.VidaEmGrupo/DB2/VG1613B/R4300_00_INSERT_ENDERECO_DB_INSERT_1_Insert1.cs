using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1613B
{
    public class R4300_00_INSERT_ENDERECO_DB_INSERT_1_Insert1 : QueryBasis<R4300_00_INSERT_ENDERECO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.ENDERECOS
            (COD_CLIENTE,
            COD_ENDERECO,
            OCORR_ENDERECO,
            ENDERECO,
            BAIRRO,
            CIDADE,
            SIGLA_UF,
            CEP,
            DDD,
            TELEFONE,
            FAX,
            TELEX,
            SIT_REGISTRO,
            COD_EMPRESA)
            VALUES (:CLIENTES-COD-CLIENTE,
            :ENDERECO-COD-ENDERECO,
            :ENDERECO-OCORR-ENDERECO,
            :ENDERECO-ENDERECO,
            :ENDERECO-BAIRRO,
            :ENDERECO-CIDADE,
            :ENDERECO-SIGLA-UF,
            :ENDERECO-CEP,
            :ENDERECO-DDD,
            :ENDERECO-TELEFONE,
            :ENDERECO-FAX,
            :ENDERECO-TELEX,
            :ENDERECO-SIT-REGISTRO,
            :ENDERECO-COD-EMPRESA)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.ENDERECOS (COD_CLIENTE, COD_ENDERECO, OCORR_ENDERECO, ENDERECO, BAIRRO, CIDADE, SIGLA_UF, CEP, DDD, TELEFONE, FAX, TELEX, SIT_REGISTRO, COD_EMPRESA) VALUES ({FieldThreatment(this.CLIENTES_COD_CLIENTE)}, {FieldThreatment(this.ENDERECO_COD_ENDERECO)}, {FieldThreatment(this.ENDERECO_OCORR_ENDERECO)}, {FieldThreatment(this.ENDERECO_ENDERECO)}, {FieldThreatment(this.ENDERECO_BAIRRO)}, {FieldThreatment(this.ENDERECO_CIDADE)}, {FieldThreatment(this.ENDERECO_SIGLA_UF)}, {FieldThreatment(this.ENDERECO_CEP)}, {FieldThreatment(this.ENDERECO_DDD)}, {FieldThreatment(this.ENDERECO_TELEFONE)}, {FieldThreatment(this.ENDERECO_FAX)}, {FieldThreatment(this.ENDERECO_TELEX)}, {FieldThreatment(this.ENDERECO_SIT_REGISTRO)}, {FieldThreatment(this.ENDERECO_COD_EMPRESA)})";

            return query;
        }
        public string CLIENTES_COD_CLIENTE { get; set; }
        public string ENDERECO_COD_ENDERECO { get; set; }
        public string ENDERECO_OCORR_ENDERECO { get; set; }
        public string ENDERECO_ENDERECO { get; set; }
        public string ENDERECO_BAIRRO { get; set; }
        public string ENDERECO_CIDADE { get; set; }
        public string ENDERECO_SIGLA_UF { get; set; }
        public string ENDERECO_CEP { get; set; }
        public string ENDERECO_DDD { get; set; }
        public string ENDERECO_TELEFONE { get; set; }
        public string ENDERECO_FAX { get; set; }
        public string ENDERECO_TELEX { get; set; }
        public string ENDERECO_SIT_REGISTRO { get; set; }
        public string ENDERECO_COD_EMPRESA { get; set; }

        public static void Execute(R4300_00_INSERT_ENDERECO_DB_INSERT_1_Insert1 r4300_00_INSERT_ENDERECO_DB_INSERT_1_Insert1)
        {
            var ths = r4300_00_INSERT_ENDERECO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4300_00_INSERT_ENDERECO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}