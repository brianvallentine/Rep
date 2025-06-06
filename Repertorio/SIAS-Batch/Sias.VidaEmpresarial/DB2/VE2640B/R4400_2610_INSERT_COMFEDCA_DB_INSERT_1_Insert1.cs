using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class R4400_2610_INSERT_COMFEDCA_DB_INSERT_1_Insert1 : QueryBasis<R4400_2610_INSERT_COMFEDCA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.COMUNIC_FED_CAP_VA
            ( NUM_CERTIFICADO ,
            SITUACAO ,
            DATA_MOVIMENTO ,
            TIMESTAMP )
            VALUES
            ( :TERMOADE-NUM-TERMO ,
            '0' ,
            :H-DT-MOV-ABERTO-2610 ,
            CURRENT TIMESTAMP )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.COMUNIC_FED_CAP_VA ( NUM_CERTIFICADO , SITUACAO , DATA_MOVIMENTO , TIMESTAMP ) VALUES ( {FieldThreatment(this.TERMOADE_NUM_TERMO)} , '0' , {FieldThreatment(this.H_DT_MOV_ABERTO_2610)} , CURRENT TIMESTAMP )";

            return query;
        }
        public string TERMOADE_NUM_TERMO { get; set; }
        public string H_DT_MOV_ABERTO_2610 { get; set; }

        public static void Execute(R4400_2610_INSERT_COMFEDCA_DB_INSERT_1_Insert1 r4400_2610_INSERT_COMFEDCA_DB_INSERT_1_Insert1)
        {
            var ths = r4400_2610_INSERT_COMFEDCA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4400_2610_INSERT_COMFEDCA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}