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
    public class M_1300_GERA_AJUSTE_DB_INSERT_1_Insert1 : QueryBasis<M_1300_GERA_AJUSTE_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0DIFPARCELVA
            VALUES (:PROPVA-NRCERTIF,
            9999,
            1,
            401,
            :PROPVA-DTQITBCO,
            :COBERP-PRMVG,
            :COBERP-PRMAP,
            :PROPVF-PRMVGPGO,
            :PROPVF-PRMAPPGO,
            :DIFPAR-PRMVGDIF,
            :DIFPAR-PRMAPDIF,
            0,
            ' ' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0DIFPARCELVA VALUES ({FieldThreatment(this.PROPVA_NRCERTIF)}, 9999, 1, 401, {FieldThreatment(this.PROPVA_DTQITBCO)}, {FieldThreatment(this.COBERP_PRMVG)}, {FieldThreatment(this.COBERP_PRMAP)}, {FieldThreatment(this.PROPVF_PRMVGPGO)}, {FieldThreatment(this.PROPVF_PRMAPPGO)}, {FieldThreatment(this.DIFPAR_PRMVGDIF)}, {FieldThreatment(this.DIFPAR_PRMAPDIF)}, 0, ' ' )";

            return query;
        }
        public string PROPVA_NRCERTIF { get; set; }
        public string PROPVA_DTQITBCO { get; set; }
        public string COBERP_PRMVG { get; set; }
        public string COBERP_PRMAP { get; set; }
        public string PROPVF_PRMVGPGO { get; set; }
        public string PROPVF_PRMAPPGO { get; set; }
        public string DIFPAR_PRMVGDIF { get; set; }
        public string DIFPAR_PRMAPDIF { get; set; }

        public static void Execute(M_1300_GERA_AJUSTE_DB_INSERT_1_Insert1 m_1300_GERA_AJUSTE_DB_INSERT_1_Insert1)
        {
            var ths = m_1300_GERA_AJUSTE_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1300_GERA_AJUSTE_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}