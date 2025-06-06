using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0602B
{
    public class R4510_00_INS_ENDERECO_JUR_DB_INSERT_1_Insert1 : QueryBasis<R4510_00_INS_ENDERECO_JUR_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.ENDERECOS
            VALUES (:DCLCLIENTES.COD-CLIENTE ,
            2 ,
            1 ,
            :ENDERECO-ENDERECO ,
            :ENDERECO-BAIRRO ,
            :ENDERECO-CIDADE ,
            :ENDERECO-SIGLA-UF ,
            :ENDERECO-CEP ,
            :ENDERECO-DDD ,
            :ENDERECO-TELEFONE ,
            0 ,
            0 ,
            '0' ,
            NULL ,
            NULL )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.ENDERECOS VALUES ({FieldThreatment(this.COD_CLIENTE)} , 2 , 1 , {FieldThreatment(this.ENDERECO_ENDERECO)} , {FieldThreatment(this.ENDERECO_BAIRRO)} , {FieldThreatment(this.ENDERECO_CIDADE)} , {FieldThreatment(this.ENDERECO_SIGLA_UF)} , {FieldThreatment(this.ENDERECO_CEP)} , {FieldThreatment(this.ENDERECO_DDD)} , {FieldThreatment(this.ENDERECO_TELEFONE)} , 0 , 0 , '0' , NULL , NULL )";

            return query;
        }
        public string COD_CLIENTE { get; set; }
        public string ENDERECO_ENDERECO { get; set; }
        public string ENDERECO_BAIRRO { get; set; }
        public string ENDERECO_CIDADE { get; set; }
        public string ENDERECO_SIGLA_UF { get; set; }
        public string ENDERECO_CEP { get; set; }
        public string ENDERECO_DDD { get; set; }
        public string ENDERECO_TELEFONE { get; set; }

        public static void Execute(R4510_00_INS_ENDERECO_JUR_DB_INSERT_1_Insert1 r4510_00_INS_ENDERECO_JUR_DB_INSERT_1_Insert1)
        {
            var ths = r4510_00_INS_ENDERECO_JUR_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4510_00_INS_ENDERECO_JUR_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}