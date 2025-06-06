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
    public class R3300_00_INSERT_DB_INSERT_1_Insert1 : QueryBasis<R3300_00_INSERT_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.TITULOS_FED_CAP_VA
            ( NRTITFDCAP ,
            NUM_CERTIFICADO ,
            DATA_INIVIGENCIA ,
            DATA_TERVIGENCIA ,
            NRSORTEIO ,
            VAL_CUSTO_TITULO ,
            NRPARCEL ,
            NRMFDCAPF ,
            SITUACAO ,
            SIT_RELAT ,
            DATA_MOVIMENTO ,
            TIMESTAMP ,
            NRMFDCAPR ,
            NRTITREN )
            VALUES
            ( :MOVFEDCA-NRTITFDCAP ,
            :V0BILH-NUMBIL ,
            :TITFEDCA-DATA-INIVIGENCIA ,
            :TITFEDCA-DATA-TERVIGENCIA ,
            :TITFEDCA-NRSORTEIO ,
            :V1BILC-VALMAX,
            0,
            0,
            '0' ,
            '1' ,
            :V1SIST-DTMOVABE ,
            CURRENT TIMESTAMP ,
            0,
            0 )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.TITULOS_FED_CAP_VA ( NRTITFDCAP , NUM_CERTIFICADO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , NRSORTEIO , VAL_CUSTO_TITULO , NRPARCEL , NRMFDCAPF , SITUACAO , SIT_RELAT , DATA_MOVIMENTO , TIMESTAMP , NRMFDCAPR , NRTITREN ) VALUES ( {FieldThreatment(this.MOVFEDCA_NRTITFDCAP)} , {FieldThreatment(this.V0BILH_NUMBIL)} , {FieldThreatment(this.TITFEDCA_DATA_INIVIGENCIA)} , {FieldThreatment(this.TITFEDCA_DATA_TERVIGENCIA)} , {FieldThreatment(this.TITFEDCA_NRSORTEIO)} , {FieldThreatment(this.V1BILC_VALMAX)}, 0, 0, '0' , '1' , {FieldThreatment(this.V1SIST_DTMOVABE)} , CURRENT TIMESTAMP , 0, 0 )";

            return query;
        }
        public string MOVFEDCA_NRTITFDCAP { get; set; }
        public string V0BILH_NUMBIL { get; set; }
        public string TITFEDCA_DATA_INIVIGENCIA { get; set; }
        public string TITFEDCA_DATA_TERVIGENCIA { get; set; }
        public string TITFEDCA_NRSORTEIO { get; set; }
        public string V1BILC_VALMAX { get; set; }
        public string V1SIST_DTMOVABE { get; set; }

        public static void Execute(R3300_00_INSERT_DB_INSERT_1_Insert1 r3300_00_INSERT_DB_INSERT_1_Insert1)
        {
            var ths = r3300_00_INSERT_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3300_00_INSERT_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}