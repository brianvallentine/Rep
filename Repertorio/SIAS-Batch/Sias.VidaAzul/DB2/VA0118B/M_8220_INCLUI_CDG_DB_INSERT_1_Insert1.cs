using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0118B
{
    public class M_8220_INCLUI_CDG_DB_INSERT_1_Insert1 : QueryBasis<M_8220_INCLUI_CDG_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0CDGCOBER
            VALUES (:PROPVA-CODCLIEN,
            :PROPVA-DTINICDG,
            '9999-12-31' ,
            :COBERP-IMPSEGCDG,
            :COBERP-VLCUSTCDG,
            :PROPVA-NRCERTIF,
            :PROPVA-OCORHIST,
            '0' ,
            'VA0118B' ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0CDGCOBER VALUES ({FieldThreatment(this.PROPVA_CODCLIEN)}, {FieldThreatment(this.PROPVA_DTINICDG)}, '9999-12-31' , {FieldThreatment(this.COBERP_IMPSEGCDG)}, {FieldThreatment(this.COBERP_VLCUSTCDG)}, {FieldThreatment(this.PROPVA_NRCERTIF)}, {FieldThreatment(this.PROPVA_OCORHIST)}, '0' , 'VA0118B' , CURRENT TIMESTAMP)";

            return query;
        }
        public string PROPVA_CODCLIEN { get; set; }
        public string PROPVA_DTINICDG { get; set; }
        public string COBERP_IMPSEGCDG { get; set; }
        public string COBERP_VLCUSTCDG { get; set; }
        public string PROPVA_NRCERTIF { get; set; }
        public string PROPVA_OCORHIST { get; set; }

        public static void Execute(M_8220_INCLUI_CDG_DB_INSERT_1_Insert1 m_8220_INCLUI_CDG_DB_INSERT_1_Insert1)
        {
            var ths = m_8220_INCLUI_CDG_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_8220_INCLUI_CDG_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}