using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2600B
{
    public class R0543_00_INSERT_PESSOA_END_DB_INSERT_1_Insert1 : QueryBasis<R0543_00_INSERT_PESSOA_END_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.PESSOA_ENDERECO
            VALUES (:DCLPESSOA.PESSOA-COD-PESSOA ,
            :DCLPESSOA-ENDERECO.OCORR-ENDERECO ,
            :DCLPESSOA-ENDERECO.ENDERECO ,
            :DCLPESSOA-ENDERECO.TIPO-ENDER ,
            :DCLPESSOA-ENDERECO.COMPL-ENDER ,
            :DCLPESSOA-ENDERECO.BAIRRO ,
            :DCLPESSOA-ENDERECO.CEP ,
            :DCLPESSOA-ENDERECO.CIDADE ,
            :DCLPESSOA-ENDERECO.SIGLA-UF ,
            :DCLPESSOA-ENDERECO.SITUACAO-ENDERECO ,
            :DCLPESSOA-ENDERECO.COD-USUARIO ,
            CURRENT_TIMESTAMP )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PESSOA_ENDERECO VALUES ({FieldThreatment(this.PESSOA_COD_PESSOA)} , {FieldThreatment(this.OCORR_ENDERECO)} , {FieldThreatment(this.ENDERECO)} , {FieldThreatment(this.TIPO_ENDER)} , {FieldThreatment(this.COMPL_ENDER)} , {FieldThreatment(this.BAIRRO)} , {FieldThreatment(this.CEP)} , {FieldThreatment(this.CIDADE)} , {FieldThreatment(this.SIGLA_UF)} , {FieldThreatment(this.SITUACAO_ENDERECO)} , {FieldThreatment(this.COD_USUARIO)} , CURRENT_TIMESTAMP )";

            return query;
        }
        public string PESSOA_COD_PESSOA { get; set; }
        public string OCORR_ENDERECO { get; set; }
        public string ENDERECO { get; set; }
        public string TIPO_ENDER { get; set; }
        public string COMPL_ENDER { get; set; }
        public string BAIRRO { get; set; }
        public string CEP { get; set; }
        public string CIDADE { get; set; }
        public string SIGLA_UF { get; set; }
        public string SITUACAO_ENDERECO { get; set; }
        public string COD_USUARIO { get; set; }

        public static void Execute(R0543_00_INSERT_PESSOA_END_DB_INSERT_1_Insert1 r0543_00_INSERT_PESSOA_END_DB_INSERT_1_Insert1)
        {
            var ths = r0543_00_INSERT_PESSOA_END_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0543_00_INSERT_PESSOA_END_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}