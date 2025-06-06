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
    public class R3000_00_INSERE_HIST_ACOMP_DB_INSERT_1_Insert1 : QueryBasis<R3000_00_INSERE_HIST_ACOMP_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.SI_HIST_ACOMPANHA
            (COD_FONTE,
            NUM_PROTOCOLO_SINI,
            DAC_PROTOCOLO_SINI,
            NUM_OCORR_SINIACO,
            NUM_APOL_SINISTRO,
            COD_OPERACAO,
            OCORR_HISTORICO)
            VALUES (:SIHISACO-COD-FONTE,
            :SIHISACO-NUM-PROTOCOLO-SINI,
            :SIHISACO-DAC-PROTOCOLO-SINI,
            :SIHISACO-NUM-OCORR-SINIACO,
            :SIHISACO-NUM-APOL-SINISTRO,
            :SIHISACO-COD-OPERACAO,
            :SIHISACO-OCORR-HISTORICO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.SI_HIST_ACOMPANHA (COD_FONTE, NUM_PROTOCOLO_SINI, DAC_PROTOCOLO_SINI, NUM_OCORR_SINIACO, NUM_APOL_SINISTRO, COD_OPERACAO, OCORR_HISTORICO) VALUES ({FieldThreatment(this.SIHISACO_COD_FONTE)}, {FieldThreatment(this.SIHISACO_NUM_PROTOCOLO_SINI)}, {FieldThreatment(this.SIHISACO_DAC_PROTOCOLO_SINI)}, {FieldThreatment(this.SIHISACO_NUM_OCORR_SINIACO)}, {FieldThreatment(this.SIHISACO_NUM_APOL_SINISTRO)}, {FieldThreatment(this.SIHISACO_COD_OPERACAO)}, {FieldThreatment(this.SIHISACO_OCORR_HISTORICO)})";

            return query;
        }
        public string SIHISACO_COD_FONTE { get; set; }
        public string SIHISACO_NUM_PROTOCOLO_SINI { get; set; }
        public string SIHISACO_DAC_PROTOCOLO_SINI { get; set; }
        public string SIHISACO_NUM_OCORR_SINIACO { get; set; }
        public string SIHISACO_NUM_APOL_SINISTRO { get; set; }
        public string SIHISACO_COD_OPERACAO { get; set; }
        public string SIHISACO_OCORR_HISTORICO { get; set; }

        public static void Execute(R3000_00_INSERE_HIST_ACOMP_DB_INSERT_1_Insert1 r3000_00_INSERE_HIST_ACOMP_DB_INSERT_1_Insert1)
        {
            var ths = r3000_00_INSERE_HIST_ACOMP_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3000_00_INSERE_HIST_ACOMP_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}