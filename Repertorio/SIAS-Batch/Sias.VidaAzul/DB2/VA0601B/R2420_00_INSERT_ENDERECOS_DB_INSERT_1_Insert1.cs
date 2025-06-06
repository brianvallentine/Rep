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
    public class R2420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1 : QueryBasis<R2420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.ENDERECOS
            VALUES (:DCLCLIENTES.COD-CLIENTE,
            2,
            :DCLENDERECOS.ENDERECO-OCORR-ENDERECO,
            :DCLPESSOA-ENDERECO.ENDERECO,
            :DCLPESSOA-ENDERECO.BAIRRO,
            :DCLPESSOA-ENDERECO.CIDADE,
            :DCLPESSOA-ENDERECO.SIGLA-UF,
            :DCLPESSOA-ENDERECO.CEP,
            :WHOST-DDD,
            :WHOST-FONE,
            :WHOST-FAX,
            :WHOST-TELEX,
            '0' ,
            NULL ,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.ENDERECOS VALUES ({FieldThreatment(this.COD_CLIENTE)}, 2, {FieldThreatment(this.ENDERECO_OCORR_ENDERECO)}, {FieldThreatment(this.ENDERECO)}, {FieldThreatment(this.BAIRRO)}, {FieldThreatment(this.CIDADE)}, {FieldThreatment(this.SIGLA_UF)}, {FieldThreatment(this.CEP)}, {FieldThreatment(this.WHOST_DDD)}, {FieldThreatment(this.WHOST_FONE)}, {FieldThreatment(this.WHOST_FAX)}, {FieldThreatment(this.WHOST_TELEX)}, '0' , NULL , NULL)";

            return query;
        }
        public string COD_CLIENTE { get; set; }
        public string ENDERECO_OCORR_ENDERECO { get; set; }
        public string ENDERECO { get; set; }
        public string BAIRRO { get; set; }
        public string CIDADE { get; set; }
        public string SIGLA_UF { get; set; }
        public string CEP { get; set; }
        public string WHOST_DDD { get; set; }
        public string WHOST_FONE { get; set; }
        public string WHOST_FAX { get; set; }
        public string WHOST_TELEX { get; set; }

        public static void Execute(R2420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1 r2420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1)
        {
            var ths = r2420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}