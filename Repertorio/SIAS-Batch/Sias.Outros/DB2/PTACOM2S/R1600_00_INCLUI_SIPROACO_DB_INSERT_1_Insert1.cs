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
    public class R1600_00_INCLUI_SIPROACO_DB_INSERT_1_Insert1 : QueryBasis<R1600_00_INCLUI_SIPROACO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.SI_PROTOCOLO_ACOMP
            (COD_FONTE,
            NUM_PROTOCOLO_SINI,
            DAC_PROTOCOLO_SINI,
            OCORR_HISTORICO,
            DATA_INIVIGENCIA,
            DATA_MOVIMENTO,
            COD_PRODUTO,
            COD_GRUPO_CAUSA,
            COD_SUBGRUPO_CAUSA,
            NUM_PARTICIPANTE,
            COD_CLIENTE,
            COD_DOCUMENTO,
            COD_FASE,
            COD_EVENTO,
            NUM_CARTA,
            OCORR_HIST_PAI,
            COD_USUARIO,
            TIMESTAMP,
            NOM_SISTEMA_ORIGEM,
            NOM_PROGRAMA,
            STA_INTEGRA_AMSS)
            VALUES
            (:SIDOCACO-COD-FONTE,
            :SIDOCACO-NUM-PROTOCOLO-SINI,
            :SIDOCACO-DAC-PROTOCOLO-SINI,
            :SIPROACO-OCORR-HISTORICO,
            :SICHEPAR-DATA-INIVIGENCIA,
            :SIDOCACO-DATA-MOVTO-DOCACO,
            :SIDOCACO-COD-PRODUTO,
            :SIDOCACO-COD-GRUPO-CAUSA,
            :SIDOCACO-COD-SUBGRUPO-CAUSA,
            3,
            :SIMOVSIN-COD-ESTIPULANTE,
            :SIDOCACO-COD-DOCUMENTO,
            :SIPROACO-COD-FASE,
            :SIDOCACO-COD-EVENTO,
            :SIDOCACO-NUM-CARTA:VIND-NUM-CARTA,
            :SIPROACO-OCORR-HISTORICO,
            :SIDOCACO-COD-USUARIO,
            CURRENT TIMESTAMP,
            'SISWEB' ,
            'PTACOM2S' ,
            'N' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.SI_PROTOCOLO_ACOMP (COD_FONTE, NUM_PROTOCOLO_SINI, DAC_PROTOCOLO_SINI, OCORR_HISTORICO, DATA_INIVIGENCIA, DATA_MOVIMENTO, COD_PRODUTO, COD_GRUPO_CAUSA, COD_SUBGRUPO_CAUSA, NUM_PARTICIPANTE, COD_CLIENTE, COD_DOCUMENTO, COD_FASE, COD_EVENTO, NUM_CARTA, OCORR_HIST_PAI, COD_USUARIO, TIMESTAMP, NOM_SISTEMA_ORIGEM, NOM_PROGRAMA, STA_INTEGRA_AMSS) VALUES ({FieldThreatment(this.SIDOCACO_COD_FONTE)}, {FieldThreatment(this.SIDOCACO_NUM_PROTOCOLO_SINI)}, {FieldThreatment(this.SIDOCACO_DAC_PROTOCOLO_SINI)}, {FieldThreatment(this.SIPROACO_OCORR_HISTORICO)}, {FieldThreatment(this.SICHEPAR_DATA_INIVIGENCIA)}, {FieldThreatment(this.SIDOCACO_DATA_MOVTO_DOCACO)}, {FieldThreatment(this.SIDOCACO_COD_PRODUTO)}, {FieldThreatment(this.SIDOCACO_COD_GRUPO_CAUSA)}, {FieldThreatment(this.SIDOCACO_COD_SUBGRUPO_CAUSA)}, 3, {FieldThreatment(this.SIMOVSIN_COD_ESTIPULANTE)}, {FieldThreatment(this.SIDOCACO_COD_DOCUMENTO)}, {FieldThreatment(this.SIPROACO_COD_FASE)}, {FieldThreatment(this.SIDOCACO_COD_EVENTO)},  {FieldThreatment((this.VIND_NUM_CARTA?.ToInt() == -1 ? null : this.SIDOCACO_NUM_CARTA))}, {FieldThreatment(this.SIPROACO_OCORR_HISTORICO)}, {FieldThreatment(this.SIDOCACO_COD_USUARIO)}, CURRENT TIMESTAMP, 'SISWEB' , 'PTACOM2S' , 'N' )";

            return query;
        }
        public string SIDOCACO_COD_FONTE { get; set; }
        public string SIDOCACO_NUM_PROTOCOLO_SINI { get; set; }
        public string SIDOCACO_DAC_PROTOCOLO_SINI { get; set; }
        public string SIPROACO_OCORR_HISTORICO { get; set; }
        public string SICHEPAR_DATA_INIVIGENCIA { get; set; }
        public string SIDOCACO_DATA_MOVTO_DOCACO { get; set; }
        public string SIDOCACO_COD_PRODUTO { get; set; }
        public string SIDOCACO_COD_GRUPO_CAUSA { get; set; }
        public string SIDOCACO_COD_SUBGRUPO_CAUSA { get; set; }
        public string SIMOVSIN_COD_ESTIPULANTE { get; set; }
        public string SIDOCACO_COD_DOCUMENTO { get; set; }
        public string SIPROACO_COD_FASE { get; set; }
        public string SIDOCACO_COD_EVENTO { get; set; }
        public string SIDOCACO_NUM_CARTA { get; set; }
        public string VIND_NUM_CARTA { get; set; }
        public string SIDOCACO_COD_USUARIO { get; set; }

        public static void Execute(R1600_00_INCLUI_SIPROACO_DB_INSERT_1_Insert1 r1600_00_INCLUI_SIPROACO_DB_INSERT_1_Insert1)
        {
            var ths = r1600_00_INCLUI_SIPROACO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1600_00_INCLUI_SIPROACO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}