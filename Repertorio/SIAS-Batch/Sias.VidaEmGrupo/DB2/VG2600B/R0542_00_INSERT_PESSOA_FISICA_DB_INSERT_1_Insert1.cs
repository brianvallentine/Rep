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
    public class R0542_00_INSERT_PESSOA_FISICA_DB_INSERT_1_Insert1 : QueryBasis<R0542_00_INSERT_PESSOA_FISICA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.PESSOA_FISICA
            VALUES (:DCLPESSOA.PESSOA-COD-PESSOA ,
            :DCLPESSOA-FISICA.CPF ,
            :DCLPESSOA-FISICA.DATA-NASCIMENTO ,
            :DCLPESSOA-FISICA.SEXO ,
            :DCLPESSOA-FISICA.COD-USUARIO ,
            :DCLPESSOA-FISICA.ESTADO-CIVIL ,
            CURRENT_TIMESTAMP ,
            NULL ,
            NULL ,
            NULL ,
            NULL ,
            :DCLPESSOA-FISICA.COD-CBO ,
            NULL )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PESSOA_FISICA VALUES ({FieldThreatment(this.PESSOA_COD_PESSOA)} , {FieldThreatment(this.CPF)} , {FieldThreatment(this.DATA_NASCIMENTO)} , {FieldThreatment(this.SEXO)} , {FieldThreatment(this.COD_USUARIO)} , {FieldThreatment(this.ESTADO_CIVIL)} , CURRENT_TIMESTAMP , NULL , NULL , NULL , NULL , {FieldThreatment(this.COD_CBO)} , NULL )";

            return query;
        }
        public string PESSOA_COD_PESSOA { get; set; }
        public string CPF { get; set; }
        public string DATA_NASCIMENTO { get; set; }
        public string SEXO { get; set; }
        public string COD_USUARIO { get; set; }
        public string ESTADO_CIVIL { get; set; }
        public string COD_CBO { get; set; }

        public static void Execute(R0542_00_INSERT_PESSOA_FISICA_DB_INSERT_1_Insert1 r0542_00_INSERT_PESSOA_FISICA_DB_INSERT_1_Insert1)
        {
            var ths = r0542_00_INSERT_PESSOA_FISICA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0542_00_INSERT_PESSOA_FISICA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}