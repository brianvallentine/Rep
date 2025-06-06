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
    public class M_2420_GERA_EVENTO_DB_INSERT_1_Insert1 : QueryBasis<M_2420_GERA_EVENTO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0EVENTOSVF
            VALUES (:PLCOM-CODPDT,
            :PDTVF-OCORHIST,
            0,
            :PROPVA-NRCERTIF,
            1,
            3,
            102,
            :SISTEMA-DTMOVABE,
            :SISTEMA-DTMOVABE,
            '0' ,
            :COBERP-VLPREMIO,
            0,
            'VF0118B' ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0EVENTOSVF VALUES ({FieldThreatment(this.PLCOM_CODPDT)}, {FieldThreatment(this.PDTVF_OCORHIST)}, 0, {FieldThreatment(this.PROPVA_NRCERTIF)}, 1, 3, 102, {FieldThreatment(this.SISTEMA_DTMOVABE)}, {FieldThreatment(this.SISTEMA_DTMOVABE)}, '0' , {FieldThreatment(this.COBERP_VLPREMIO)}, 0, 'VF0118B' , CURRENT TIMESTAMP)";

            return query;
        }
        public string PLCOM_CODPDT { get; set; }
        public string PDTVF_OCORHIST { get; set; }
        public string PROPVA_NRCERTIF { get; set; }
        public string SISTEMA_DTMOVABE { get; set; }
        public string COBERP_VLPREMIO { get; set; }

        public static void Execute(M_2420_GERA_EVENTO_DB_INSERT_1_Insert1 m_2420_GERA_EVENTO_DB_INSERT_1_Insert1)
        {
            var ths = m_2420_GERA_EVENTO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_2420_GERA_EVENTO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}