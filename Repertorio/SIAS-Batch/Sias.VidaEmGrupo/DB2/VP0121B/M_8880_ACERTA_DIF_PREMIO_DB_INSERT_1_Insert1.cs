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
    public class M_8880_ACERTA_DIF_PREMIO_DB_INSERT_1_Insert1 : QueryBasis<M_8880_ACERTA_DIF_PREMIO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0DIFPARCELVA
            VALUES (:PROPVA-NRCERTIF,
            9999,
            1,
            :DIFPAR-CODOPER,
            :PROPVA-DTQITBCO,
            :COBERP-VLPREMIO,
            0,
            :V0HCOB-VLPRMTOT,
            0,
            :DIFPAR-PRMVG,
            0,
            0,
            ' ' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0DIFPARCELVA VALUES ({FieldThreatment(this.PROPVA_NRCERTIF)}, 9999, 1, {FieldThreatment(this.DIFPAR_CODOPER)}, {FieldThreatment(this.PROPVA_DTQITBCO)}, {FieldThreatment(this.COBERP_VLPREMIO)}, 0, {FieldThreatment(this.V0HCOB_VLPRMTOT)}, 0, {FieldThreatment(this.DIFPAR_PRMVG)}, 0, 0, ' ' )";

            return query;
        }
        public string PROPVA_NRCERTIF { get; set; }
        public string DIFPAR_CODOPER { get; set; }
        public string PROPVA_DTQITBCO { get; set; }
        public string COBERP_VLPREMIO { get; set; }
        public string V0HCOB_VLPRMTOT { get; set; }
        public string DIFPAR_PRMVG { get; set; }

        public static void Execute(M_8880_ACERTA_DIF_PREMIO_DB_INSERT_1_Insert1 m_8880_ACERTA_DIF_PREMIO_DB_INSERT_1_Insert1)
        {
            var ths = m_8880_ACERTA_DIF_PREMIO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_8880_ACERTA_DIF_PREMIO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}