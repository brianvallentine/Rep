using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB2005B
{
    public class R3500_10_INSERT_DB_INSERT_1_Insert1 : QueryBasis<R3500_10_INSERT_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.PARCEL_FED_CAP_VA
            ( NRTITFDCAP ,
            NUM_PARCELA ,
            VAL_CUSTO_TITULO ,
            DTFATUR ,
            DATA_MOVIMENTO ,
            SITUACAO ,
            NRMFDCAP ,
            TIMESTAMP )
            VALUES
            ( :MOVFEDCA-NRTITFDCAP ,
            0,
            :V1BILC-VALMAX,
            :V1SIST-DTMOVABE,
            :V1SIST-DTMOVABE,
            '1' ,
            0 ,
            CURRENT TIMESTAMP )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PARCEL_FED_CAP_VA ( NRTITFDCAP , NUM_PARCELA , VAL_CUSTO_TITULO , DTFATUR , DATA_MOVIMENTO , SITUACAO , NRMFDCAP , TIMESTAMP ) VALUES ( {FieldThreatment(this.MOVFEDCA_NRTITFDCAP)} , 0, {FieldThreatment(this.V1BILC_VALMAX)}, {FieldThreatment(this.V1SIST_DTMOVABE)}, {FieldThreatment(this.V1SIST_DTMOVABE)}, '1' , 0 , CURRENT TIMESTAMP )";

            return query;
        }
        public string MOVFEDCA_NRTITFDCAP { get; set; }
        public string V1BILC_VALMAX { get; set; }
        public string V1SIST_DTMOVABE { get; set; }

        public static void Execute(R3500_10_INSERT_DB_INSERT_1_Insert1 r3500_10_INSERT_DB_INSERT_1_Insert1)
        {
            var ths = r3500_10_INSERT_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3500_10_INSERT_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}