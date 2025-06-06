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
    public class M_8230_INCLUI_REPASSE_CDG_DB_INSERT_1_Insert1 : QueryBasis<M_8230_INCLUI_REPASSE_CDG_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0REPASSECDG
            VALUES (:PROPVA-CODCLIEN,
            :REPCDG-DTREF,
            :COBERP-VLCUSTCDG,
            :PROPVA-NRCERTIF,
            1,
            '0' ,
            :SISTEMA-DTMOVABE,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0REPASSECDG VALUES ({FieldThreatment(this.PROPVA_CODCLIEN)}, {FieldThreatment(this.REPCDG_DTREF)}, {FieldThreatment(this.COBERP_VLCUSTCDG)}, {FieldThreatment(this.PROPVA_NRCERTIF)}, 1, '0' , {FieldThreatment(this.SISTEMA_DTMOVABE)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string PROPVA_CODCLIEN { get; set; }
        public string REPCDG_DTREF { get; set; }
        public string COBERP_VLCUSTCDG { get; set; }
        public string PROPVA_NRCERTIF { get; set; }
        public string SISTEMA_DTMOVABE { get; set; }

        public static void Execute(M_8230_INCLUI_REPASSE_CDG_DB_INSERT_1_Insert1 m_8230_INCLUI_REPASSE_CDG_DB_INSERT_1_Insert1)
        {
            var ths = m_8230_INCLUI_REPASSE_CDG_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_8230_INCLUI_REPASSE_CDG_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}