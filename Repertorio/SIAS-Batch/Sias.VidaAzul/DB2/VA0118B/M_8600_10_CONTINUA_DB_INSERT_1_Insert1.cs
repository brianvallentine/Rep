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
    public class M_8600_10_CONTINUA_DB_INSERT_1_Insert1 : QueryBasis<M_8600_10_CONTINUA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0PARCELVA
            VALUES (:PROPVA-NRCERTIF,
            1,
            :HISTCB-DTVENCTO,
            :COBERP-PRMVG,
            :COBERP-PRMAP,
            0,
            :OPCAOP-OPCAOPAG,
            ' ' ,
            :PARCEL-OCORHIST,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0PARCELVA VALUES ({FieldThreatment(this.PROPVA_NRCERTIF)}, 1, {FieldThreatment(this.HISTCB_DTVENCTO)}, {FieldThreatment(this.COBERP_PRMVG)}, {FieldThreatment(this.COBERP_PRMAP)}, 0, {FieldThreatment(this.OPCAOP_OPCAOPAG)}, ' ' , {FieldThreatment(this.PARCEL_OCORHIST)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string PROPVA_NRCERTIF { get; set; }
        public string HISTCB_DTVENCTO { get; set; }
        public string COBERP_PRMVG { get; set; }
        public string COBERP_PRMAP { get; set; }
        public string OPCAOP_OPCAOPAG { get; set; }
        public string PARCEL_OCORHIST { get; set; }

        public static void Execute(M_8600_10_CONTINUA_DB_INSERT_1_Insert1 m_8600_10_CONTINUA_DB_INSERT_1_Insert1)
        {
            var ths = m_8600_10_CONTINUA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_8600_10_CONTINUA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}