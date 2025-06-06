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
    public class M_1100_GERA_1A_PARCELA_DB_INSERT_3_Insert1 : QueryBasis<M_1100_GERA_1A_PARCELA_DB_INSERT_3_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0COMPTITVA
            VALUES (:CEDENT-NRTIT,
            :PROPVA-NRPARCEL,
            0,
            :COBERP-PRMVG,
            :COBERP-PRMAP,
            :SISTEMA-DTMOVABE,
            'VF0118B' ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0COMPTITVA VALUES ({FieldThreatment(this.CEDENT_NRTIT)}, {FieldThreatment(this.PROPVA_NRPARCEL)}, 0, {FieldThreatment(this.COBERP_PRMVG)}, {FieldThreatment(this.COBERP_PRMAP)}, {FieldThreatment(this.SISTEMA_DTMOVABE)}, 'VF0118B' , CURRENT TIMESTAMP)";

            return query;
        }
        public string CEDENT_NRTIT { get; set; }
        public string PROPVA_NRPARCEL { get; set; }
        public string COBERP_PRMVG { get; set; }
        public string COBERP_PRMAP { get; set; }
        public string SISTEMA_DTMOVABE { get; set; }

        public static void Execute(M_1100_GERA_1A_PARCELA_DB_INSERT_3_Insert1 m_1100_GERA_1A_PARCELA_DB_INSERT_3_Insert1)
        {
            var ths = m_1100_GERA_1A_PARCELA_DB_INSERT_3_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1100_GERA_1A_PARCELA_DB_INSERT_3_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}