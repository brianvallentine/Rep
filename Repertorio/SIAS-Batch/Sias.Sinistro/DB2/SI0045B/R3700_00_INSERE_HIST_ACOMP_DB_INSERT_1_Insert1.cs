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
    public class R3700_00_INSERE_HIST_ACOMP_DB_INSERT_1_Insert1 : QueryBasis<R3700_00_INSERE_HIST_ACOMP_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.SI_HIST_ACOMP
            (COD_FONTE,
            NUM_PROTOCOLO_SINI,
            DAC_PROTOCOLO_SINI,
            OCORR_HISTORICO,
            NUM_APOL_SINISTRO,
            OCORR_HIST,
            COD_OPERACAO)
            VALUES (:SIHISACM-COD-FONTE,
            :SIHISACM-NUM-PROTOCOLO-SINI,
            :SIHISACM-DAC-PROTOCOLO-SINI,
            :SIHISACM-OCORR-HISTORICO,
            :SIHISACM-NUM-APOL-SINISTRO,
            :SIHISACM-OCORR-HIST,
            :SIHISACM-COD-OPERACAO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.SI_HIST_ACOMP (COD_FONTE, NUM_PROTOCOLO_SINI, DAC_PROTOCOLO_SINI, OCORR_HISTORICO, NUM_APOL_SINISTRO, OCORR_HIST, COD_OPERACAO) VALUES ({FieldThreatment(this.SIHISACM_COD_FONTE)}, {FieldThreatment(this.SIHISACM_NUM_PROTOCOLO_SINI)}, {FieldThreatment(this.SIHISACM_DAC_PROTOCOLO_SINI)}, {FieldThreatment(this.SIHISACM_OCORR_HISTORICO)}, {FieldThreatment(this.SIHISACM_NUM_APOL_SINISTRO)}, {FieldThreatment(this.SIHISACM_OCORR_HIST)}, {FieldThreatment(this.SIHISACM_COD_OPERACAO)})";

            return query;
        }
        public string SIHISACM_COD_FONTE { get; set; }
        public string SIHISACM_NUM_PROTOCOLO_SINI { get; set; }
        public string SIHISACM_DAC_PROTOCOLO_SINI { get; set; }
        public string SIHISACM_OCORR_HISTORICO { get; set; }
        public string SIHISACM_NUM_APOL_SINISTRO { get; set; }
        public string SIHISACM_OCORR_HIST { get; set; }
        public string SIHISACM_COD_OPERACAO { get; set; }

        public static void Execute(R3700_00_INSERE_HIST_ACOMP_DB_INSERT_1_Insert1 r3700_00_INSERE_HIST_ACOMP_DB_INSERT_1_Insert1)
        {
            var ths = r3700_00_INSERE_HIST_ACOMP_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3700_00_INSERE_HIST_ACOMP_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}