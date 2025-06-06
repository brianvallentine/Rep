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
    public class R1200_00_INCLUI_SINI_ACOMP_DB_INSERT_1_Insert1 : QueryBasis<R1200_00_INCLUI_SINI_ACOMP_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.SI_SINISTRO_ACOMP
            (COD_FONTE,
            NUM_PROTOCOLO_SINI,
            DAC_PROTOCOLO_SINI,
            NUM_OCORR_SINIACO,
            COD_EVENTO,
            DATA_MOVTO_SINIACO,
            DESCR_COMPLEMENTAR,
            COD_USUARIO,
            TIMESTAMP,
            NUM_CARTA)
            VALUES (:SISINACO-COD-FONTE,
            :SISINACO-NUM-PROTOCOLO-SINI,
            :SISINACO-DAC-PROTOCOLO-SINI,
            :SISINACO-NUM-OCORR-SINIACO,
            :SISINACO-COD-EVENTO,
            :SISINACO-DATA-MOVTO-SINIACO,
            :SISINACO-DESCR-COMPLEMENTAR,
            :SISINACO-COD-USUARIO,
            CURRENT TIMESTAMP,
            :SISINACO-NUM-CARTA:IND-NUM-CARTA)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.SI_SINISTRO_ACOMP (COD_FONTE, NUM_PROTOCOLO_SINI, DAC_PROTOCOLO_SINI, NUM_OCORR_SINIACO, COD_EVENTO, DATA_MOVTO_SINIACO, DESCR_COMPLEMENTAR, COD_USUARIO, TIMESTAMP, NUM_CARTA) VALUES ({FieldThreatment(this.SISINACO_COD_FONTE)}, {FieldThreatment(this.SISINACO_NUM_PROTOCOLO_SINI)}, {FieldThreatment(this.SISINACO_DAC_PROTOCOLO_SINI)}, {FieldThreatment(this.SISINACO_NUM_OCORR_SINIACO)}, {FieldThreatment(this.SISINACO_COD_EVENTO)}, {FieldThreatment(this.SISINACO_DATA_MOVTO_SINIACO)}, {FieldThreatment(this.SISINACO_DESCR_COMPLEMENTAR)}, {FieldThreatment(this.SISINACO_COD_USUARIO)}, CURRENT TIMESTAMP,  {FieldThreatment((this.IND_NUM_CARTA?.ToInt() == -1 ? null : this.SISINACO_NUM_CARTA))})";

            return query;
        }
        public string SISINACO_COD_FONTE { get; set; }
        public string SISINACO_NUM_PROTOCOLO_SINI { get; set; }
        public string SISINACO_DAC_PROTOCOLO_SINI { get; set; }
        public string SISINACO_NUM_OCORR_SINIACO { get; set; }
        public string SISINACO_COD_EVENTO { get; set; }
        public string SISINACO_DATA_MOVTO_SINIACO { get; set; }
        public string SISINACO_DESCR_COMPLEMENTAR { get; set; }
        public string SISINACO_COD_USUARIO { get; set; }
        public string SISINACO_NUM_CARTA { get; set; }
        public string IND_NUM_CARTA { get; set; }

        public static void Execute(R1200_00_INCLUI_SINI_ACOMP_DB_INSERT_1_Insert1 r1200_00_INCLUI_SINI_ACOMP_DB_INSERT_1_Insert1)
        {
            var ths = r1200_00_INCLUI_SINI_ACOMP_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1200_00_INCLUI_SINI_ACOMP_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}