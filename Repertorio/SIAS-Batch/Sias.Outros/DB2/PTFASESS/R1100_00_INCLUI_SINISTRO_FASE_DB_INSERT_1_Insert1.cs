using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.PTFASESS
{
    public class R1100_00_INCLUI_SINISTRO_FASE_DB_INSERT_1_Insert1 : QueryBasis<R1100_00_INCLUI_SINISTRO_FASE_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.SI_SINISTRO_FASE
            (COD_FONTE,
            NUM_PROTOCOLO_SINI,
            DAC_PROTOCOLO_SINI,
            COD_FASE,
            COD_EVENTO,
            NUM_OCORR_SINIACO,
            DATA_INIVIG_REFAEV,
            DATA_ABERTURA_SIFA,
            DATA_FECHA_SIFA,
            TIMESTAMP)
            VALUES (:SISINFAS-COD-FONTE,
            :SISINFAS-NUM-PROTOCOLO-SINI,
            :SISINFAS-DAC-PROTOCOLO-SINI,
            :SISINFAS-COD-FASE,
            :SISINFAS-COD-EVENTO,
            :SISINFAS-NUM-OCORR-SINIACO,
            :SISINFAS-DATA-INIVIG-REFAEV,
            :SISINFAS-DATA-ABERTURA-SIFA,
            :SISINFAS-DATA-FECHA-SIFA,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.SI_SINISTRO_FASE (COD_FONTE, NUM_PROTOCOLO_SINI, DAC_PROTOCOLO_SINI, COD_FASE, COD_EVENTO, NUM_OCORR_SINIACO, DATA_INIVIG_REFAEV, DATA_ABERTURA_SIFA, DATA_FECHA_SIFA, TIMESTAMP) VALUES ({FieldThreatment(this.SISINFAS_COD_FONTE)}, {FieldThreatment(this.SISINFAS_NUM_PROTOCOLO_SINI)}, {FieldThreatment(this.SISINFAS_DAC_PROTOCOLO_SINI)}, {FieldThreatment(this.SISINFAS_COD_FASE)}, {FieldThreatment(this.SISINFAS_COD_EVENTO)}, {FieldThreatment(this.SISINFAS_NUM_OCORR_SINIACO)}, {FieldThreatment(this.SISINFAS_DATA_INIVIG_REFAEV)}, {FieldThreatment(this.SISINFAS_DATA_ABERTURA_SIFA)}, {FieldThreatment(this.SISINFAS_DATA_FECHA_SIFA)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string SISINFAS_COD_FONTE { get; set; }
        public string SISINFAS_NUM_PROTOCOLO_SINI { get; set; }
        public string SISINFAS_DAC_PROTOCOLO_SINI { get; set; }
        public string SISINFAS_COD_FASE { get; set; }
        public string SISINFAS_COD_EVENTO { get; set; }
        public string SISINFAS_NUM_OCORR_SINIACO { get; set; }
        public string SISINFAS_DATA_INIVIG_REFAEV { get; set; }
        public string SISINFAS_DATA_ABERTURA_SIFA { get; set; }
        public string SISINFAS_DATA_FECHA_SIFA { get; set; }

        public static void Execute(R1100_00_INCLUI_SINISTRO_FASE_DB_INSERT_1_Insert1 r1100_00_INCLUI_SINISTRO_FASE_DB_INSERT_1_Insert1)
        {
            var ths = r1100_00_INCLUI_SINISTRO_FASE_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1100_00_INCLUI_SINISTRO_FASE_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}