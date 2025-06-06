using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG9550B
{
    public class R2070_00_INSERT_ENDERECO_SEG_DB_INSERT_1_Insert1 : QueryBasis<R2070_00_INSERT_ENDERECO_SEG_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.ENDERECOS
            VALUES (:SEGURVGA-COD-CLIENTE ,
            2 ,
            :WS-MAX-OCOREND ,
            :ENDERECO-ENDERECO ,
            :ENDERECO-BAIRRO ,
            :ENDERECO-CIDADE ,
            :ENDERECO-SIGLA-UF ,
            :ENDERECO-CEP ,
            :ENDERECO-DDD ,
            :ENDERECO-TELEFONE ,
            :ENDERECO-FAX ,
            :ENDERECO-TELEX ,
            '0' ,
            0 ,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.ENDERECOS VALUES ({FieldThreatment(this.SEGURVGA_COD_CLIENTE)} , 2 , {FieldThreatment(this.WS_MAX_OCOREND)} , {FieldThreatment(this.ENDERECO_ENDERECO)} , {FieldThreatment(this.ENDERECO_BAIRRO)} , {FieldThreatment(this.ENDERECO_CIDADE)} , {FieldThreatment(this.ENDERECO_SIGLA_UF)} , {FieldThreatment(this.ENDERECO_CEP)} , {FieldThreatment(this.ENDERECO_DDD)} , {FieldThreatment(this.ENDERECO_TELEFONE)} , {FieldThreatment(this.ENDERECO_FAX)} , {FieldThreatment(this.ENDERECO_TELEX)} , '0' , 0 , NULL)";

            return query;
        }
        public string SEGURVGA_COD_CLIENTE { get; set; }
        public string WS_MAX_OCOREND { get; set; }
        public string ENDERECO_ENDERECO { get; set; }
        public string ENDERECO_BAIRRO { get; set; }
        public string ENDERECO_CIDADE { get; set; }
        public string ENDERECO_SIGLA_UF { get; set; }
        public string ENDERECO_CEP { get; set; }
        public string ENDERECO_DDD { get; set; }
        public string ENDERECO_TELEFONE { get; set; }
        public string ENDERECO_FAX { get; set; }
        public string ENDERECO_TELEX { get; set; }

        public static void Execute(R2070_00_INSERT_ENDERECO_SEG_DB_INSERT_1_Insert1 r2070_00_INSERT_ENDERECO_SEG_DB_INSERT_1_Insert1)
        {
            var ths = r2070_00_INSERT_ENDERECO_SEG_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2070_00_INSERT_ENDERECO_SEG_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}