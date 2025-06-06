using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0121B
{
    public class M_8600_10_CONTINUA_DB_INSERT_3_Insert1 : QueryBasis<M_8600_10_CONTINUA_DB_INSERT_3_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0DIFPARCELVA
            VALUES (:PROPVA-NRCERTIF,
            1,
            1,
            680,
            :HISTCB-DTVENCTO,
            0,
            0,
            0,
            0,
            :DESCON-PRMVG,
            :DESCON-PRMAP,
            0,
            ' ' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0DIFPARCELVA VALUES ({FieldThreatment(this.PROPVA_NRCERTIF)}, 1, 1, 680, {FieldThreatment(this.HISTCB_DTVENCTO)}, 0, 0, 0, 0, {FieldThreatment(this.DESCON_PRMVG)}, {FieldThreatment(this.DESCON_PRMAP)}, 0, ' ' )";

            return query;
        }
        public string PROPVA_NRCERTIF { get; set; }
        public string HISTCB_DTVENCTO { get; set; }
        public string DESCON_PRMVG { get; set; }
        public string DESCON_PRMAP { get; set; }

        public static void Execute(M_8600_10_CONTINUA_DB_INSERT_3_Insert1 m_8600_10_CONTINUA_DB_INSERT_3_Insert1)
        {
            var ths = m_8600_10_CONTINUA_DB_INSERT_3_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_8600_10_CONTINUA_DB_INSERT_3_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}