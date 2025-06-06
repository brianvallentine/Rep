using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA5419B
{
    public class R2000_00_GERA_RELATORIO_DB_INSERT_1_Insert1 : QueryBasis<R2000_00_GERA_RELATORIO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0HISTREPSAF
            VALUES (:V0RSAF-CODCLIEN-ANT,
            :WHOST-DTREF,
            0,
            0,
            0,
            :WHOST-VLCUSTAUXF,
            1800,
            '1' ,
            '0' ,
            0,
            :WHOST-QTVIDAS,
            'VA5419B' ,
            CURRENT TIMESTAMP,
            :WHOST-DTREF:VIND-DTMOVTO1)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0HISTREPSAF VALUES ({FieldThreatment(this.V0RSAF_CODCLIEN_ANT)}, {FieldThreatment(this.WHOST_DTREF)}, 0, 0, 0, {FieldThreatment(this.WHOST_VLCUSTAUXF)}, 1800, '1' , '0' , 0, {FieldThreatment(this.WHOST_QTVIDAS)}, 'VA5419B' , CURRENT TIMESTAMP,  {FieldThreatment((this.VIND_DTMOVTO1?.ToInt() == -1 ? null : this.WHOST_DTREF))})";

            return query;
        }
        public string V0RSAF_CODCLIEN_ANT { get; set; }
        public string WHOST_DTREF { get; set; }
        public string WHOST_VLCUSTAUXF { get; set; }
        public string WHOST_QTVIDAS { get; set; }
        public string VIND_DTMOVTO1 { get; set; }

        public static void Execute(R2000_00_GERA_RELATORIO_DB_INSERT_1_Insert1 r2000_00_GERA_RELATORIO_DB_INSERT_1_Insert1)
        {
            var ths = r2000_00_GERA_RELATORIO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2000_00_GERA_RELATORIO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}