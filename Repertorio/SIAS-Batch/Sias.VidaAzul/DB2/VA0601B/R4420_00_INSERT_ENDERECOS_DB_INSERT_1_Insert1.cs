using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0601B
{
    public class R4420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1 : QueryBasis<R4420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.ENDERECOS
            VALUES (:WHOST-COD-CLIENTE,
            2,
            :WHOST-OCORR-ENDERECO,
            :WHOST-ENDERECO,
            :WHOST-BAIRRO,
            :WHOST-CIDADE,
            :WHOST-SIGLA-UF,
            :WHOST-CEP,
            :WHOST-DDD,
            :WHOST-FONE,
            0,
            0,
            '0' ,
            NULL ,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.ENDERECOS VALUES ({FieldThreatment(this.WHOST_COD_CLIENTE)}, 2, {FieldThreatment(this.WHOST_OCORR_ENDERECO)}, {FieldThreatment(this.WHOST_ENDERECO)}, {FieldThreatment(this.WHOST_BAIRRO)}, {FieldThreatment(this.WHOST_CIDADE)}, {FieldThreatment(this.WHOST_SIGLA_UF)}, {FieldThreatment(this.WHOST_CEP)}, {FieldThreatment(this.WHOST_DDD)}, {FieldThreatment(this.WHOST_FONE)}, 0, 0, '0' , NULL , NULL)";

            return query;
        }
        public string WHOST_COD_CLIENTE { get; set; }
        public string WHOST_OCORR_ENDERECO { get; set; }
        public string WHOST_ENDERECO { get; set; }
        public string WHOST_BAIRRO { get; set; }
        public string WHOST_CIDADE { get; set; }
        public string WHOST_SIGLA_UF { get; set; }
        public string WHOST_CEP { get; set; }
        public string WHOST_DDD { get; set; }
        public string WHOST_FONE { get; set; }

        public static void Execute(R4420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1 r4420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1)
        {
            var ths = r4420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}