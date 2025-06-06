using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0100B
{
    public class R5500_00_INSERT_V0SOLICITAFAT_DB_INSERT_1_Insert1 : QueryBasis<R5500_00_INSERT_V0SOLICITAFAT_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0SOLICITAFAT
            VALUES (:W1SOLF-NUM-APOL ,
            :W1SOLF-COD-SUBG ,
            :V0SOLF-NUM-FATUR ,
            0 ,
            0 ,
            100 ,
            '3' ,
            NULL ,
            NULL ,
            :V1SIST-DTMOVABE ,
            CURRENT TIMESTAMP ,
            '9999' ,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0SOLICITAFAT VALUES ({FieldThreatment(this.W1SOLF_NUM_APOL)} , {FieldThreatment(this.W1SOLF_COD_SUBG)} , {FieldThreatment(this.V0SOLF_NUM_FATUR)} , 0 , 0 , 100 , '3' , NULL , NULL , {FieldThreatment(this.V1SIST_DTMOVABE)} , CURRENT TIMESTAMP , '9999' , NULL)";

            return query;
        }
        public string W1SOLF_NUM_APOL { get; set; }
        public string W1SOLF_COD_SUBG { get; set; }
        public string V0SOLF_NUM_FATUR { get; set; }
        public string V1SIST_DTMOVABE { get; set; }

        public static void Execute(R5500_00_INSERT_V0SOLICITAFAT_DB_INSERT_1_Insert1 r5500_00_INSERT_V0SOLICITAFAT_DB_INSERT_1_Insert1)
        {
            var ths = r5500_00_INSERT_V0SOLICITAFAT_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R5500_00_INSERT_V0SOLICITAFAT_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}