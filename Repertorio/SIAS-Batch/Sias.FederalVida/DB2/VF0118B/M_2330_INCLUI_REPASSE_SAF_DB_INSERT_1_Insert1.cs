using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0118B
{
    public class M_2330_INCLUI_REPASSE_SAF_DB_INSERT_1_Insert1 : QueryBasis<M_2330_INCLUI_REPASSE_SAF_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0HISTREPSAF
            VALUES (:PROPVA-CODCLIEN,
            :REPSAF-DTREF,
            :PROPVA-NRCERTIF,
            1,
            0,
            :COBERP-VLCUSTAUXF,
            102,
            '0' ,
            '0' ,
            0,
            0,
            'VF0118B' ,
            CURRENT TIMESTAMP,
            :SISTEMA-DTINISAF:VIND-DTMOVTO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0HISTREPSAF VALUES ({FieldThreatment(this.PROPVA_CODCLIEN)}, {FieldThreatment(this.REPSAF_DTREF)}, {FieldThreatment(this.PROPVA_NRCERTIF)}, 1, 0, {FieldThreatment(this.COBERP_VLCUSTAUXF)}, 102, '0' , '0' , 0, 0, 'VF0118B' , CURRENT TIMESTAMP,  {FieldThreatment((this.VIND_DTMOVTO?.ToInt() == -1 ? null : this.SISTEMA_DTINISAF))})";

            return query;
        }
        public string PROPVA_CODCLIEN { get; set; }
        public string REPSAF_DTREF { get; set; }
        public string PROPVA_NRCERTIF { get; set; }
        public string COBERP_VLCUSTAUXF { get; set; }
        public string SISTEMA_DTINISAF { get; set; }
        public string VIND_DTMOVTO { get; set; }

        public static void Execute(M_2330_INCLUI_REPASSE_SAF_DB_INSERT_1_Insert1 m_2330_INCLUI_REPASSE_SAF_DB_INSERT_1_Insert1)
        {
            var ths = m_2330_INCLUI_REPASSE_SAF_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_2330_INCLUI_REPASSE_SAF_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}