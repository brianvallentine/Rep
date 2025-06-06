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
    public class M_8320_INCLUI_SAF_DB_INSERT_1_Insert1 : QueryBasis<M_8320_INCLUI_SAF_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0SAFCOBER
            VALUES (:PROPVA-CODCLIEN,
            :PROPVA-DTINISAF,
            '9999-12-31' ,
            :COBERP-IMPSEGAUXF,
            :COBERP-VLCUSTAUXF,
            :PROPVA-NRCERTIF,
            :PROPVA-OCORHIST,
            '0' ,
            'VA0118B' ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0SAFCOBER VALUES ({FieldThreatment(this.PROPVA_CODCLIEN)}, {FieldThreatment(this.PROPVA_DTINISAF)}, '9999-12-31' , {FieldThreatment(this.COBERP_IMPSEGAUXF)}, {FieldThreatment(this.COBERP_VLCUSTAUXF)}, {FieldThreatment(this.PROPVA_NRCERTIF)}, {FieldThreatment(this.PROPVA_OCORHIST)}, '0' , 'VA0118B' , CURRENT TIMESTAMP)";

            return query;
        }
        public string PROPVA_CODCLIEN { get; set; }
        public string PROPVA_DTINISAF { get; set; }
        public string COBERP_IMPSEGAUXF { get; set; }
        public string COBERP_VLCUSTAUXF { get; set; }
        public string PROPVA_NRCERTIF { get; set; }
        public string PROPVA_OCORHIST { get; set; }

        public static void Execute(M_8320_INCLUI_SAF_DB_INSERT_1_Insert1 m_8320_INCLUI_SAF_DB_INSERT_1_Insert1)
        {
            var ths = m_8320_INCLUI_SAF_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_8320_INCLUI_SAF_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}