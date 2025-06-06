using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9101B
{
    public class R2300_00_INCLUI_SINISACO_DB_INSERT_1_Insert1 : QueryBasis<R2300_00_INCLUI_SINISACO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.SINISTRO_ACOMPANHA
            (COD_FONTE,
            NUM_PROTOCOLO_SINI,
            DAC_PROTOCOLO_SINI,
            COD_OPERACAO,
            DATA_OPERACAO,
            HORA_OPERACAO,
            OCORR_HISTORICO,
            COD_USUARIO,
            COD_EMPRESA,
            TIMESTAMP)
            VALUES (:ENDOSSOS-COD-FONTE,
            :SINISCON-NUM-PROTOCOLO-SINI,
            :SINISCON-DAC-PROTOCOLO-SINI,
            9020,
            :SISTEMAS-DATA-MOV-ABERTO,
            CURRENT TIME,
            1,
            'SI9101B' ,
            0,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.SINISTRO_ACOMPANHA (COD_FONTE, NUM_PROTOCOLO_SINI, DAC_PROTOCOLO_SINI, COD_OPERACAO, DATA_OPERACAO, HORA_OPERACAO, OCORR_HISTORICO, COD_USUARIO, COD_EMPRESA, TIMESTAMP) VALUES ({FieldThreatment(this.ENDOSSOS_COD_FONTE)}, {FieldThreatment(this.SINISCON_NUM_PROTOCOLO_SINI)}, {FieldThreatment(this.SINISCON_DAC_PROTOCOLO_SINI)}, 9020, {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)}, CURRENT TIME, 1, 'SI9101B' , 0, CURRENT TIMESTAMP)";

            return query;
        }
        public string ENDOSSOS_COD_FONTE { get; set; }
        public string SINISCON_NUM_PROTOCOLO_SINI { get; set; }
        public string SINISCON_DAC_PROTOCOLO_SINI { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }

        public static void Execute(R2300_00_INCLUI_SINISACO_DB_INSERT_1_Insert1 r2300_00_INCLUI_SINISACO_DB_INSERT_1_Insert1)
        {
            var ths = r2300_00_INCLUI_SINISACO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2300_00_INCLUI_SINISACO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}