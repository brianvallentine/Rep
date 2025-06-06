using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.PTACOMOS
{
    public class R1400_00_INCLUI_SIPARTIC_DB_INSERT_1_Insert1 : QueryBasis<R1400_00_INCLUI_SIPARTIC_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.SI_PARTICIPANTE
            (COD_FONTE,
            NUM_PROTOCOLO_SINI,
            DAC_PROTOCOLO_SINI,
            NUM_PARTICIPANTE,
            COD_CLIENTE,
            SIT_PARTICIPANTE,
            COD_USUARIO,
            TIMESTAMP)
            VALUES
            (:SISINACO-COD-FONTE,
            :SISINACO-NUM-PROTOCOLO-SINI,
            :SISINACO-DAC-PROTOCOLO-SINI,
            3,
            :SIMOVSIN-COD-ESTIPULANTE,
            'A' ,
            :SISINACO-COD-USUARIO,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.SI_PARTICIPANTE (COD_FONTE, NUM_PROTOCOLO_SINI, DAC_PROTOCOLO_SINI, NUM_PARTICIPANTE, COD_CLIENTE, SIT_PARTICIPANTE, COD_USUARIO, TIMESTAMP) VALUES ({FieldThreatment(this.SISINACO_COD_FONTE)}, {FieldThreatment(this.SISINACO_NUM_PROTOCOLO_SINI)}, {FieldThreatment(this.SISINACO_DAC_PROTOCOLO_SINI)}, 3, {FieldThreatment(this.SIMOVSIN_COD_ESTIPULANTE)}, 'A' , {FieldThreatment(this.SISINACO_COD_USUARIO)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string SISINACO_COD_FONTE { get; set; }
        public string SISINACO_NUM_PROTOCOLO_SINI { get; set; }
        public string SISINACO_DAC_PROTOCOLO_SINI { get; set; }
        public string SIMOVSIN_COD_ESTIPULANTE { get; set; }
        public string SISINACO_COD_USUARIO { get; set; }

        public static void Execute(R1400_00_INCLUI_SIPARTIC_DB_INSERT_1_Insert1 r1400_00_INCLUI_SIPARTIC_DB_INSERT_1_Insert1)
        {
            var ths = r1400_00_INCLUI_SIPARTIC_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1400_00_INCLUI_SIPARTIC_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}