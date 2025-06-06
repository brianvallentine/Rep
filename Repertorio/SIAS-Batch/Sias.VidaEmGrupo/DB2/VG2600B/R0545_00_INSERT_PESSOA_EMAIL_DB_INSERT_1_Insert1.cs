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
    public class R0545_00_INSERT_PESSOA_EMAIL_DB_INSERT_1_Insert1 : QueryBasis<R0545_00_INSERT_PESSOA_EMAIL_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.PESSOA_EMAIL
            VALUES (:DCLPESSOA.PESSOA-COD-PESSOA ,
            :SEQ-EMAIL ,
            :EMAIL ,
            :SITUACAO-EMAIL ,
            'VG2600B' ,
            CURRENT_TIMESTAMP )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PESSOA_EMAIL VALUES ({FieldThreatment(this.PESSOA_COD_PESSOA)} , {FieldThreatment(this.SEQ_EMAIL)} , {FieldThreatment(this.EMAIL)} , {FieldThreatment(this.SITUACAO_EMAIL)} , 'VG2600B' , CURRENT_TIMESTAMP )";

            return query;
        }
        public string PESSOA_COD_PESSOA { get; set; }
        public string SEQ_EMAIL { get; set; }
        public string EMAIL { get; set; }
        public string SITUACAO_EMAIL { get; set; }

        public static void Execute(R0545_00_INSERT_PESSOA_EMAIL_DB_INSERT_1_Insert1 r0545_00_INSERT_PESSOA_EMAIL_DB_INSERT_1_Insert1)
        {
            var ths = r0545_00_INSERT_PESSOA_EMAIL_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0545_00_INSERT_PESSOA_EMAIL_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}