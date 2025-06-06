using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG9521B
{
    public class R0060_09_CRIA_CLIENTE_DB_INSERT_2_Insert1 : QueryBasis<R0060_09_CRIA_CLIENTE_DB_INSERT_2_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO
            SEGUROS.ENDERECOS
            ( COD_CLIENTE,
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
            VALUES (:SEGURVGA-COD-CLIENTE,
            1,
            1,
            :ENDERECO-ENDERECO,
            :ENDERECO-BAIRRO,
            :ENDERECO-CIDADE,
            :ENDERECO-SIGLA-UF,
            :ENDERECO-CEP,
            0,
            0,
            0,
            0,
            '0' ,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.ENDERECOS ( COD_CLIENTE, COD_ENDERECO, OCORR_ENDERECO, ENDERECO, BAIRRO, CIDADE, SIGLA_UF, CEP, DDD, TELEFONE, FAX, TELEX, SIT_REGISTRO, COD_EMPRESA) VALUES ({FieldThreatment(this.SEGURVGA_COD_CLIENTE)}, 1, 1, {FieldThreatment(this.ENDERECO_ENDERECO)}, {FieldThreatment(this.ENDERECO_BAIRRO)}, {FieldThreatment(this.ENDERECO_CIDADE)}, {FieldThreatment(this.ENDERECO_SIGLA_UF)}, {FieldThreatment(this.ENDERECO_CEP)}, 0, 0, 0, 0, '0' , NULL)";

            return query;
        }
        public string SEGURVGA_COD_CLIENTE { get; set; }
        public string ENDERECO_ENDERECO { get; set; }
        public string ENDERECO_BAIRRO { get; set; }
        public string ENDERECO_CIDADE { get; set; }
        public string ENDERECO_SIGLA_UF { get; set; }
        public string ENDERECO_CEP { get; set; }

        public static void Execute(R0060_09_CRIA_CLIENTE_DB_INSERT_2_Insert1 r0060_09_CRIA_CLIENTE_DB_INSERT_2_Insert1)
        {
            var ths = r0060_09_CRIA_CLIENTE_DB_INSERT_2_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0060_09_CRIA_CLIENTE_DB_INSERT_2_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}