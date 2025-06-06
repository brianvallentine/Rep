using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.PTACOM2S
{
    public class R1200_00_INCLUI_DOCTO_ACOMP_DB_INSERT_1_Insert1 : QueryBasis<R1200_00_INCLUI_DOCTO_ACOMP_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.SI_DOCUMENTO_ACOMP
            (COD_FONTE,
            NUM_PROTOCOLO_SINI,
            DAC_PROTOCOLO_SINI,
            COD_DOCUMENTO,
            NUM_OCORR_DOCACO,
            COD_PRODUTO,
            COD_GRUPO_CAUSA,
            COD_SUBGRUPO_CAUSA,
            DATA_INIVIG_DOCPAR,
            COD_EVENTO,
            DATA_MOVTO_DOCACO,
            DESCR_COMPLEMENTAR,
            NUM_CARTA,
            COD_USUARIO,
            TIMESTAMP)
            VALUES (:SIDOCACO-COD-FONTE,
            :SIDOCACO-NUM-PROTOCOLO-SINI,
            :SIDOCACO-DAC-PROTOCOLO-SINI,
            :SIDOCACO-COD-DOCUMENTO,
            :SIDOCACO-NUM-OCORR-DOCACO,
            :SIDOCACO-COD-PRODUTO,
            :SIDOCACO-COD-GRUPO-CAUSA,
            :SIDOCACO-COD-SUBGRUPO-CAUSA,
            :SIDOCACO-DATA-INIVIG-DOCPAR,
            :SIDOCACO-COD-EVENTO,
            :SIDOCACO-DATA-MOVTO-DOCACO,
            :SIDOCACO-DESCR-COMPLEMENTAR,
            :SIDOCACO-NUM-CARTA:VIND-NUM-CARTA,
            :SIDOCACO-COD-USUARIO,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.SI_DOCUMENTO_ACOMP (COD_FONTE, NUM_PROTOCOLO_SINI, DAC_PROTOCOLO_SINI, COD_DOCUMENTO, NUM_OCORR_DOCACO, COD_PRODUTO, COD_GRUPO_CAUSA, COD_SUBGRUPO_CAUSA, DATA_INIVIG_DOCPAR, COD_EVENTO, DATA_MOVTO_DOCACO, DESCR_COMPLEMENTAR, NUM_CARTA, COD_USUARIO, TIMESTAMP) VALUES ({FieldThreatment(this.SIDOCACO_COD_FONTE)}, {FieldThreatment(this.SIDOCACO_NUM_PROTOCOLO_SINI)}, {FieldThreatment(this.SIDOCACO_DAC_PROTOCOLO_SINI)}, {FieldThreatment(this.SIDOCACO_COD_DOCUMENTO)}, {FieldThreatment(this.SIDOCACO_NUM_OCORR_DOCACO)}, {FieldThreatment(this.SIDOCACO_COD_PRODUTO)}, {FieldThreatment(this.SIDOCACO_COD_GRUPO_CAUSA)}, {FieldThreatment(this.SIDOCACO_COD_SUBGRUPO_CAUSA)}, {FieldThreatment(this.SIDOCACO_DATA_INIVIG_DOCPAR)}, {FieldThreatment(this.SIDOCACO_COD_EVENTO)}, {FieldThreatment(this.SIDOCACO_DATA_MOVTO_DOCACO)}, {FieldThreatment(this.SIDOCACO_DESCR_COMPLEMENTAR)},  {FieldThreatment((this.VIND_NUM_CARTA?.ToInt() == -1 ? null : this.SIDOCACO_NUM_CARTA))}, {FieldThreatment(this.SIDOCACO_COD_USUARIO)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string SIDOCACO_COD_FONTE { get; set; }
        public string SIDOCACO_NUM_PROTOCOLO_SINI { get; set; }
        public string SIDOCACO_DAC_PROTOCOLO_SINI { get; set; }
        public string SIDOCACO_COD_DOCUMENTO { get; set; }
        public string SIDOCACO_NUM_OCORR_DOCACO { get; set; }
        public string SIDOCACO_COD_PRODUTO { get; set; }
        public string SIDOCACO_COD_GRUPO_CAUSA { get; set; }
        public string SIDOCACO_COD_SUBGRUPO_CAUSA { get; set; }
        public string SIDOCACO_DATA_INIVIG_DOCPAR { get; set; }
        public string SIDOCACO_COD_EVENTO { get; set; }
        public string SIDOCACO_DATA_MOVTO_DOCACO { get; set; }
        public string SIDOCACO_DESCR_COMPLEMENTAR { get; set; }
        public string SIDOCACO_NUM_CARTA { get; set; }
        public string VIND_NUM_CARTA { get; set; }
        public string SIDOCACO_COD_USUARIO { get; set; }

        public static void Execute(R1200_00_INCLUI_DOCTO_ACOMP_DB_INSERT_1_Insert1 r1200_00_INCLUI_DOCTO_ACOMP_DB_INSERT_1_Insert1)
        {
            var ths = r1200_00_INCLUI_DOCTO_ACOMP_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1200_00_INCLUI_DOCTO_ACOMP_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}