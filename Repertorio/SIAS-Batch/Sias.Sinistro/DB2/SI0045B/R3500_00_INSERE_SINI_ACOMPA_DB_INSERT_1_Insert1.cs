using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0045B
{
    public class R3500_00_INSERE_SINI_ACOMPA_DB_INSERT_1_Insert1 : QueryBasis<R3500_00_INSERE_SINI_ACOMPA_DB_INSERT_1_Insert1>
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
            VALUES (:SINISACO-COD-FONTE,
            :SINISACO-NUM-PROTOCOLO-SINI,
            :SINISACO-DAC-PROTOCOLO-SINI,
            :SINISACO-COD-OPERACAO,
            :SINISACO-DATA-OPERACAO,
            :SINISACO-HORA-OPERACAO,
            :SINISACO-OCORR-HISTORICO,
            :SINISACO-COD-USUARIO,
            :SINISACO-COD-EMPRESA,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.SINISTRO_ACOMPANHA (COD_FONTE, NUM_PROTOCOLO_SINI, DAC_PROTOCOLO_SINI, COD_OPERACAO, DATA_OPERACAO, HORA_OPERACAO, OCORR_HISTORICO, COD_USUARIO, COD_EMPRESA, TIMESTAMP) VALUES ({FieldThreatment(this.SINISACO_COD_FONTE)}, {FieldThreatment(this.SINISACO_NUM_PROTOCOLO_SINI)}, {FieldThreatment(this.SINISACO_DAC_PROTOCOLO_SINI)}, {FieldThreatment(this.SINISACO_COD_OPERACAO)}, {FieldThreatment(this.SINISACO_DATA_OPERACAO)}, {FieldThreatment(this.SINISACO_HORA_OPERACAO)}, {FieldThreatment(this.SINISACO_OCORR_HISTORICO)}, {FieldThreatment(this.SINISACO_COD_USUARIO)}, {FieldThreatment(this.SINISACO_COD_EMPRESA)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string SINISACO_COD_FONTE { get; set; }
        public string SINISACO_NUM_PROTOCOLO_SINI { get; set; }
        public string SINISACO_DAC_PROTOCOLO_SINI { get; set; }
        public string SINISACO_COD_OPERACAO { get; set; }
        public string SINISACO_DATA_OPERACAO { get; set; }
        public string SINISACO_HORA_OPERACAO { get; set; }
        public string SINISACO_OCORR_HISTORICO { get; set; }
        public string SINISACO_COD_USUARIO { get; set; }
        public string SINISACO_COD_EMPRESA { get; set; }

        public static void Execute(R3500_00_INSERE_SINI_ACOMPA_DB_INSERT_1_Insert1 r3500_00_INSERE_SINI_ACOMPA_DB_INSERT_1_Insert1)
        {
            var ths = r3500_00_INSERE_SINI_ACOMPA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3500_00_INSERE_SINI_ACOMPA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}